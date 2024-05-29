using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.Certificate;
using WebApplicationAPI.Service.Interfaces;
using WebApplicationAPI.ViewModels;
using System.Security.Cryptography;



namespace WebApplicationAPI.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="appDbContext2"></param>
    /// <param name="configuration"></param>
    public class EmployeeService(AppDbContext context,
        AppDbContext2 appDbContext2,
        IConfiguration configuration) : IEmployeeService
    {
        private readonly AppDbContext _context = context;
        private readonly AppDbContext2 _context2 = appDbContext2;
        private readonly IConfiguration _configuration = configuration;
        /// <summary>
        /// Get User Before Loading
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="password"></param>
        /// <returns>List user</returns>
        public async Task<List<UserBeforeLoading>> GetUserBeforeLoding_loding(string employeeNo, string password)
        {
            var parameters = new[]
            {
                    new SqlParameter(SystemConstants.Parametters.EmployeeNo, employeeNo),
                    new SqlParameter(SystemConstants.Parametters.Password, password)
            };

            using var connection = new SqlConnection(SystemConstants.AppSetting.ConnectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(SystemConstants.StoreProceduces.CheckLogin, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            using var reader = await command.ExecuteReaderAsync();
            var result = new List<UserBeforeLoading>();

            while (await reader.ReadAsync())
            {
                var user = new UserBeforeLoading
                {
                    EmployeeNo = reader[SystemConstants.Parametters.empNo].ToString(),
                    Password = reader[SystemConstants.Parametters.pass].ToString(),
                };

                result.Add(user);
            }
            return result;
        }
        /// <summary>
        /// Xác thực thông tin đăng nhập
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResult<string>> Authenticate(LoginDTO model)
        {
            // Gọi stored procedure từ DbContext
             var user = await GetUserBeforeLoding_loding(model.UserName ?? string.Empty, model.Password ?? string.Empty);
            var userID = await _context2.UserBeforeLoding
                                   .Where(x => x.EmployeeNo == model.UserName)
                                   .Select(x => x.UserBeforeLodingID)
                                   .FirstOrDefaultAsync();
            if (user == null || user.Count == 0)
            {
                return new ApiErrorResult<string>("Login Error : User or pass incorect");
            }

            var userInfoResult = user.FirstOrDefault();
            var userInfo = new LoginDTO
            {
                UserName = userInfoResult?.EmployeeNo,
                Password = userInfoResult?.Password,
                RememberMe = model.RememberMe,
            };
            var token = GenerateJwtToken(userInfo).Result;
            var refreshToken = GenerateRefreshToken();
           
            // Lưu refresh token vào cơ sở dữ liệu
             var newRefreshToken = await SaveRefreshToken(userID, refreshToken, model.RememberMe);
            if(newRefreshToken == null)
            {
                return new ApiErrorResult<string>("Login Error: Can't save refresh token");
            }
            return new ApiSuccessResult<string>(token,newRefreshToken,"Login successfuly");

        }
        private async Task<string> SaveRefreshToken(int userID, string newRefreshToken, bool remember)
        {
            var existingToken = await _context.UserToken
                                              .Where(x => x.UserID == userID)
                                              .SingleOrDefaultAsync();

            if (existingToken != null)
            {
                // Nếu token còn hạn, trả về token hiện tại
                if (existingToken.ExpiryDate > DateTime.UtcNow)
                {
                    return existingToken.RefreshToken ?? "";
                }

                // Nếu token hết hạn, xóa token hiện tại
                _context.UserToken.Remove(existingToken);
            }

            // Tạo và lưu refresh token mới
            var userToken = new UserToken
            {
                UserID = userID,
                RefreshToken = newRefreshToken,
                ExpiryDate = remember ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(3)
            };
            _context.UserToken.Add(userToken);
            await _context.SaveChangesAsync();

            return newRefreshToken;
        }


        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> GenerateJwtToken(LoginDTO model)
        {
            //ktra qua trinh dang nhap
            var userInfo = await _context2.UserBeforeLoding
                                   .Where(x => x.EmployeeNo == model.UserName)
                                   .Select(x => x.UserBeforeLodingID)
                                   .FirstOrDefaultAsync();
            var email = from e in _context2.UserBeforeLoding
                        where e.EmployeeNo == model.UserName
                        select e.Notes;
            var emailResult = await email.FirstOrDefaultAsync();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration[SystemConstants.AppSetting.TokenKey]!);
            var remember = model.RememberMe;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration[SystemConstants.AppSetting.TokenIssuer],
                Issuer = _configuration[SystemConstants.AppSetting.TokenIssuer],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, model.UserName ?? "Not given"),
                    new(ClaimTypes.NameIdentifier, userInfo.ToString() ),
                    new(ClaimTypes.Email,emailResult ?? "Not given")
                }),
                Expires = remember ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// refresh token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResult<string>> GetRefreshToken(LoginDTO model)
        {
            var user = await GetUserBeforeLoding_loding(model.UserName ?? string.Empty, model.Password ?? string.Empty);
            if (user == null || user.Count == 0)
            {
                return new ApiErrorResult<string>("Login Error: User or password incorrect");
            }

            var userID = await _context2.UserBeforeLoding
                                       .Where(x => x.EmployeeNo == model.UserName)
                                       .Select(x => x.UserBeforeLodingID)
                                       .FirstOrDefaultAsync();

            var refreshToken = await _context.UserToken
                                              .Where(x => x.UserID == userID && x.ExpiryDate > DateTime.UtcNow)
                                              .Select(x => x.RefreshToken)
                                              .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(refreshToken))
            {
                return new ApiErrorResult<string>("No valid refresh token found");
            }

            return new ApiSuccessResult<string>(refreshToken,"Ok");
        }

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CreateEmployee(EmployeeDTO employee)
        {
            var emp = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeNo == employee.EmployeeNo);
            if (emp != null)
            {
                throw new Exception(SystemConstants.MessageError.EmployeeErrorExist);
            }
            
            var newEmp = new Employee
            {
                EmployeeNo = employee.EmployeeNo,
                Password = employee.Password,
                EmployeeName = employee.EmployeeName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                IsDeleted = employee.IsDeleted,
                PhoneNumber = employee.PhoneNumber,
                CreateTime = DateTime.UtcNow,
                Company = employee.Company,
            };
            // Add the new employee to the context
            _context.Employee.Add(newEmp);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteEmployee(int id)
        {
            var emp = await _context.Employee.FindAsync(id);
            if (emp != null)
            {
                _context.Employee.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var emp = await _context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeID == id) 
                ?? throw new Exception(SystemConstants.MessageError.EmployeeErrorNotExist);
            var data = new EmployeeDTO
            {
                EmployeeID = emp.EmployeeID,
                EmployeeNo = emp.EmployeeNo,
                EmployeeName = emp.EmployeeName,
                Gender = emp.Gender,
                DateOfBirth = emp.DateOfBirth,
                Password = emp.Password,
                PhoneNumber = emp.PhoneNumber,
                Company = emp.Company,
                IsDeleted = emp.IsDeleted,
                CreatedDate = emp.CreateTime,
                EmpAddress = emp.EmpAddress
            };
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var query = _context.Employee.Select(e => new EmployeeDTO
            {
                EmployeeID = e.EmployeeID,
                EmployeeNo = e.EmployeeNo,
                EmployeeName = e.EmployeeName,
                Gender = e.Gender,
                DateOfBirth = e.DateOfBirth,
                Password = e.Password,
                PhoneNumber = e.PhoneNumber,
                Company = e.Company,
                IsDeleted = e.IsDeleted
            });
            var data = await query.ToListAsync();
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public async Task UpdateEmployee(int id, EmployeeDTO employee)
        {
            var emp = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (emp != null)
            {
                throw new AppException(SystemConstants.MessageError.EmployeeErrorNotExist);
            }
            var data = new Employee
            {
                EmployeeName = emp?.EmployeeName ,
                Company = emp?.Company,
                PhoneNumber= emp?.PhoneNumber,
                DateOfBirth = emp?.DateOfBirth ?? DateTime.MinValue,
                Password = emp?.Password,
                Gender= emp?.Gender,
            };
           
            _context.Employee.Update(data);
            await _context.SaveChangesAsync();

        }
    }
}

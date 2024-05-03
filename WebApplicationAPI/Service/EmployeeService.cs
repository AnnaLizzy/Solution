using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationAPI.Exceptions;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Models;
using WebApplicationAPI.Models.Certificate;
using WebApplicationAPI.Service.Interfaces;
using WebApplicationAPI.ViewModels;


namespace WebApplicationAPI.Service
{
    public class EmployeeService(AppDbContext context, IConfiguration configuration) : IEmployeeService
    {
        private readonly AppDbContext _context = context;

        private readonly IConfiguration _configuration = configuration;
        /// <summary>
        /// Get User Before Loading
        /// </summary>
        /// <param name="employeeNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

            // Kiểm tra kết quả trả về
            if (user == null || user.Count == 0)
            {
                return new ApiErrorResult<string>(SystemConstants.MessageError.LoginError);
            }

            var userInfo = user.FirstOrDefault();

            if (userInfo == null)
            {
                return new ApiErrorResult<string>(SystemConstants.MessageError.LoginError);
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration[SystemConstants.AppSetting.TokenKey]!);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration[SystemConstants.AppSetting.TokenIssuer],
                Issuer = _configuration[SystemConstants.AppSetting.TokenIssuer],
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.Name, userInfo.EmployeeNo?.ToString() ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new ApiSuccessResult<string>(tokenHandler.WriteToken(token));
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

        public async Task DeleteEmployee(int id)
        {
            var emp = await _context.Employee.FindAsync(id);
            if (emp != null)
            {
                _context.Employee.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

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
                IsDeleted = emp.IsDeleted
            };
            return data;
        }

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

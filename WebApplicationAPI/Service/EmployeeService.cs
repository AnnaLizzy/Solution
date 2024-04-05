using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationAPI.Constants;
using WebApplicationAPI.Data;
using WebApplicationAPI.DTOs;
using WebApplicationAPI.Exception;
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
        public async Task<List<UserBeforeLoading>> GetUserBeforeLoding_loding(string employeeNo, string password)
        {
            var parameters = new[]
            {
                    new SqlParameter("@EmployeeNo", employeeNo),
                    new SqlParameter("@password", password)
                };

            using var connection = new SqlConnection(SystemConstants.AppSetting.ConnectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand("UP_UserBeforeLoding_loding", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            using var reader = await command.ExecuteReaderAsync();
            var result = new List<UserBeforeLoading>();

            while (await reader.ReadAsync())
            {
                var user = new UserBeforeLoading
                {
                    EmployeeNo = reader["EmployeeNo"].ToString(),
                    Password = reader["Password"].ToString(),
                };

                result.Add(user);
            }

            return result;
        }
        public async Task<ApiResult<string>> Authenticate(LoginDTO model)
        {
            // Gọi stored procedure từ DbContext
            var user = await GetUserBeforeLoding_loding(model.UserName ?? string.Empty, model.Password ?? string.Empty);

            // Kiểm tra kết quả trả về
            if (user == null || user.Count == 0)
            {
                return new ApiErrorResult<string>("Không tìm thấy người dùng hoặc mật khẩu không chính xác");
            }

            var userInfo = user.FirstOrDefault();

            if (userInfo == null)
            {
                return new ApiErrorResult<string>("Không tìm thấy người dùng hoặc mật khẩu không chính xác");
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Tokens:Key"]!);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["Tokens:Issuer"],
                Issuer = _configuration["Tokens:Issuer"],
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
        public async Task CreateEmployee(EmployeeDTO employee)
        {
            var emp = await _context.Employee.FindAsync(employee.EmployeeID)
                ?? throw new AppException("da ton tai nhan vien trong he thong");
            emp.EmployeeID = employee.EmployeeID;
            emp.EmployeeNo = employee.EmployeeNo;
            emp.Password = employee.Password;
            emp.EmployeeName = employee.EmployeeName;
            emp.Gender = employee.Gender;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.IsDeleted = false;
            emp.PhoneNumber = employee.PhoneNumber;
            emp.Company = employee.Company;
           

            // Add the new employee to the context
            _context.Employee.Add(emp);
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
                .FirstOrDefaultAsync(e => e.EmployeeID == id) ?? throw new AppException("Employee not found");
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
            var emp = await _context.Employee.FindAsync(id) ?? throw new AppException("Employee not found");
            emp.EmployeeName = employee.EmployeeName;
            emp.PhoneNumber = employee.PhoneNumber;
            emp.Company = employee.Company;
            emp.Password = employee.Password;
            emp.Gender = employee.Gender;
            emp.DateOfBirth = employee.DateOfBirth;
            emp.Company = employee.Company;
            _context.Employee.Update(emp);
            await _context.SaveChangesAsync();

        }
    }
}

using ApiLibrary.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationAPI.Constants;
using WebApplicationAPI.DTOs;

namespace WebApplicationApp.Controllers
{
    public class AccountController(IAccountApiClient accountApi,IConfiguration configuration) : Controller
    {
        private readonly IAccountApiClient _accountApiClient = accountApi;
        private readonly IConfiguration _configuration = configuration;
        /// <summary>
        /// Login get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        /// <summary>
        /// Login post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO request, string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(request);
            }
            var result = await _accountApiClient.Authenticate(request);
            if (result == null || string.IsNullOrEmpty(result.ResultObj))
            {
                
                TempData["error"] = "Đăng nhập thất bại : Tài khoản hoặc mật khẩu không đúng";
                return View(request);
            }
            var userPrincipal = this.ValidateToken(result.ResultObj);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString(SystemConstants.AppSetting.Token, result.ResultObj);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);
            TempData["success"] = "Đăng nhập thành công";
            return LocalRedirect(returnUrl);
        }
        /// <summary>
        ///  Logout
        /// </summary>
        /// <returns></returns>      
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Home");
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            TokenValidationParameters validationParameters = new()
            {
                ValidateLifetime = true,

                ValidAudience = _configuration[SystemConstants.AppSetting.TokenIssuer],
                ValidIssuer = _configuration[SystemConstants.AppSetting.TokenIssuer],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[SystemConstants.AppSetting.TokenKey] ?? ""))
            };

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out _);

            return principal;
        }

    }
}

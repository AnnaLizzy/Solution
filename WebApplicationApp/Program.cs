﻿using Microsoft.EntityFrameworkCore;
using ApiLibrary;
using ApiLibrary.Interfaces;
using WebApplicationApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
//DI
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IWorkShiftApiClient, WorkShiftApiClient>();
builder.Services.AddScoped<IListLocationApiClient, ListLocationApiClient>();
builder.Services.AddScoped<IAreaApiClient, AreaApiClient>();
builder.Services.AddScoped<IWorkScheduleApiClient, WorkScheduleApiClient>();
builder.Services.AddScoped<IAccountApiClient, AccountApiClient>();
builder.Services.AddScoped<IRegionApiClient, RegionApiClient>();
builder.Services.AddScoped<IEmployeeApiClient, EmployeeApiClient>();
builder.Services.AddScoped<IUserBeforeLoadingApiClient, UserBeforeLoadingApiClient>();
//builder.Services.AddScoped<IMailSenderApiClient, IMailSenderApiClient>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
//use component razor page
builder.Services.AddRazorPages();
//CORs
// In your ConfigureServices method
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Index";
        options.AccessDeniedPath = "/User/Forbidden/";
        options.ExpireTimeSpan = TimeSpan.FromDays(5); // Thời gian sống của cookie
        options.SlidingExpiration = true; // Gia hạn thời gian sống của cookie khi người dùng hoạt động
        options.Cookie.HttpOnly = true;
    });
// add session and use session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// In your Configure method
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

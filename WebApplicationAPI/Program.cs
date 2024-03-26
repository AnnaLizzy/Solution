﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplicationAPI.Data;
using WebApplicationAPI.Service;
using WebApplicationAPI.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplicationAPI.Constants;
using Microsoft.OpenApi.Models;
using WebApplicationAPI.DTOs;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddDbContext<AppDbContext2>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database2Connection") ?? throw new InvalidOperationException("Connection string 'Database2Connection' not found.")));

// Add services to the container.
var secretKey = builder.Configuration.GetValue<string>("SecretKey") ?? "";
string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer") ?? "";
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key") ?? "";
byte[] signingKeyBytes = Encoding.UTF8.GetBytes(signingKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = issuer,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
        };
    });
builder.Services.AddControllers();
  

// Add security definition
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme\\r\\n\\r\\n\r\n " +
        "Enter 'Bearer' [space] and then your token in the text input below." +
        "\r\n\\r\\n\\r\\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "App test API",
        Description = "An ASP.NET Core Web API for managing App items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/tesxst")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

//DI
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IWorkScheduleService, WorkScheduleService>();
builder.Services.AddScoped<IListLocationService, ListLocationService>();
builder.Services.AddScoped<IWorkShiftService, WorkShiftService>();

//CORs
// In your ConfigureServices method
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(SystemConstants.Url.BaseUrl)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

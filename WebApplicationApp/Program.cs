using Microsoft.EntityFrameworkCore;
using ApiLibrary;
using ApiLibrary.Interfaces;
using WebApplicationApp.Data;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
//DI
builder.Services.AddScoped<IWorkShiftApiClient, WorkShiftApiClient>();
builder.Services.AddScoped<IListLocationApiClient, ListLocationApiClient>();
builder.Services.AddScoped<IAreaApiClient, AreaApiClient>();
builder.Services.AddScoped<IWorkScheduleApiClient, WorkScheduleApiClient>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

//CORs
// In your ConfigureServices method
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:44389")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
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
app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

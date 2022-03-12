using ConfArch.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter())).Services
    .AddRepositories()
    .AddConfArchDbContext(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        assembly =>
            assembly.MigrationsAssembly(typeof(Program).Assembly.FullName))
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error")
        .UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();
app.MapControllerRoute(
name: "default",
pattern: "{controller=Conference}/{action=Index}/{id?}");

app.Run();

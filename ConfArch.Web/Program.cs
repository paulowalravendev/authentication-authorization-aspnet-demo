using ConfArch.Data;
using ConfArch.Web.AuthenticationSchemes;
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
    .AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        // o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddCookie(ExternalAuthenticationDefaults.AuthenticationScheme)
    .AddGoogle(o =>
    {
        o.SignInScheme = ExternalAuthenticationDefaults.AuthenticationScheme;
        o.ClientId = builder.Configuration.GetValue<string>("GoogleAuthentication:ClientId");
        o.ClientSecret = builder.Configuration.GetValue<string>("GoogleAuthentication:ClientSecret");
    });
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

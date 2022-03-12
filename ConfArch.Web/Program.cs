using ConfArch.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().Services
    .AddRepositories()
    .AddConfArchDbContext(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        assembly =>
            assembly.MigrationsAssembly(typeof(Program).AssemblyQualifiedName));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

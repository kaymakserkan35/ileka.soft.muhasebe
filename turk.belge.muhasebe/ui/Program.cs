using business.DependencyServices;
using data.access.context;
using data.access.Dependencyresolver;

using entity;
using Microsoft.AspNetCore.Identity;
using service.DependencyResolver;
using service.Mapper;
using service.services.abstractions;
using ui.Mapper;
using ui.DependencyResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMyBusinessDependencies();
builder.Services.AddMyDataAccessDependencies();
builder.Services.AddMyServiceDependencies();
builder.Services.AddMyUiDependencies();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dev/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



// özellik ile action ları rename yaptığımda buradaki action=Login --> actionDegistirilmis=Login oluyor.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Developer}/{action=listuser}/{id?}");

app.Run();

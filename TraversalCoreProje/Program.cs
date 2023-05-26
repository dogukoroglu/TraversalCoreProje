using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});

// ******************* Identity Part **********************
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddEntityFrameworkStores<Context>();
// ******************* Identity Part **********************

// ******************* Ef Ba��ml�l���n� kald�rmak i�in gerekli 
builder.Services.ContainerDependencies();
// ******************* Ef Ba��ml�l���n� kald�rmak i�in gerekli 


// Add services to the container.
builder.Services.AddControllersWithViews();


// ******************* Identity Part **********************
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
// ******************* Identity Part **********************

//// ******************* Metin dosyas�na log ekleme *********************
//ILoggerFactory loggerFactory = new LoggerFactory();
//var path = Directory.GetCurrentDirectory();
//loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
//// ******************* Metin dosyas�na log ekleme *********************

var app = builder.Build();

// ******************* Metin dosyas�na log ekleme *********************
ILoggerFactory loggerFactory = new LoggerFactory();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");
// ******************* Metin dosyas�na log ekleme *********************

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
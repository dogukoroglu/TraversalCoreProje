using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Results.DestinationResults;
using TraversalCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

// ******************* Identity Part **********************
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)
    .AddEntityFrameworkStores<Context>();
// ******************* Identity Part **********************

builder.Services.AddHttpClient();



// ******************* Ef Ba��ml�l���n� kald�rmak i�in gerekli 
builder.Services.ContainerDependencies();
// ******************* Ef Ba��ml�l���n� kald�rmak i�in gerekli 

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.CustomerValidator();

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();


// ******************* Identity Part **********************
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

//builder.Services.AddLocalization(opt =>
//{
//    opt.ResourcesPath = "Resources";
//});

builder.Services.AddMvc();
	//.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

// e�er kullan�c� giri� yapmadan sayfay� a��yorsa login sayfas�na g�nderecek
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
});
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

//var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
//var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[4])
//    .AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
//app.UseRequestLocalization(localizationOptions);

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

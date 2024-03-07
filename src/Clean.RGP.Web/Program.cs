using Ardalis.GuardClauses;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Clean.RGP.Core;
using Clean.RGP.Core.PersonAggregate.Validators;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Infrastructure;
using Clean.RGP.Infrastructure.Data;
using FastEndpoints;
using FluentValidation;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IValidator<Person>, PersonValidator>();
builder.Services.AddTransient<IValidator<LandProperty>, LandPropertyValidator>();
builder.Services.AddTransient<IValidator<Plot>, PlotValidator>();
builder.Services.AddTransient<IValidator<LandType>, LandTypeValidator>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string? connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
Guard.Against.Null(connectionString);
builder.Services.AddApplicationDbContext(connectionString);


// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
});

var app = builder.Build();

var culture = new CultureInfo("lv-LV");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

app.UseStaticFiles();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=RGP}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
  app.UseDefaultExceptionHandler(); // from FastEndpoints
  app.UseHsts();
}

app.UseHttpsRedirection();

app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}

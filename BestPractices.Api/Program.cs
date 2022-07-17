using BestPractices.Api.BackgroundServices;
using BestPractices.Api.Extensions;
using BestPractices.Api.Logging;
using BestPractices.Api.Models;
using BestPractices.Api.Service;
using BestPractices.Api.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
IConfigurationRoot configurationManager = new ConfigurationManager().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{env}.json", true).AddEnvironmentVariables().Build();

builder.Host.UseSerilog();
// Add services to the container.
builder.WebHost.UseConfiguration(configurationManager);
builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();
builder.Services.ConfigureMapping();
builder.Services.AddHttpClient("api", config =>
{
    config.BaseAddress = new Uri("https://www.asdasd.com");
    config.DefaultRequestHeaders.Add("Authorization", "Bearer adasdad");
});
builder.Services.AddHostedService<DateTimeLogWriter>();
builder.Services.AddLogging();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();
app.UseCustomHealthCheck();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Log.Logger = new LoggerConfiguration().
    WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
    .WriteTo.File("Logs.txt")
    .CreateLogger();
app.Run();
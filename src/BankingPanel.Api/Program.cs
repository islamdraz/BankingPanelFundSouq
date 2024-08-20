using BankingPanel.Api.Controllers.Commons.Mapping;
using BankingPanel.Infrastructure;
using BankingPanel.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BankingPanel.Api.Controllers.Commons.Errors;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddMappings();

builder.Services.AddSingleton<ProblemDetailsFactory, BankingPanelProblemDetailsFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseExceptionHandler("/error");
app.UseAuthorization();

app.MapControllers();

app.Run();


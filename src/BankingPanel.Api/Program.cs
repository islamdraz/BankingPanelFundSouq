using BankingPanel.Api.Controllers.Commons.Mapping;
using BankingPanel.Infrastructure;
using BankingPanel.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BankingPanel.Api.Controllers.Commons.Errors;
using Serilog;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


// Add Serilog 
// load the configuration from settings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddMappings();



// Add Swagger generation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add the JWT Bearer token security definition
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by space and your JWT token.",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Configure Role-Based Authorization
builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("user"));

});

// replce the ProblemDetailsFactory default implimentaion with our custom BankingPanelProblemDetailsFactory
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

// add Exception handler middleware and route to error to return Problem 
app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


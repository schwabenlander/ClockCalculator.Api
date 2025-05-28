using ClockCalculator.Api.Services;
using ClockCalculator.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IClockCalculatorService, ClockCalculatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapClockCalculatorEndpoints();

app.Run();
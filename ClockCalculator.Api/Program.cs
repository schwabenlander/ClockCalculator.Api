using ClockCalculator.Api.Services;
using ClockCalculator.Api.Endpoints;
using ClockCalculator.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IClockCalculatorService, ClockCalculatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<RequestTimingMiddleware>();

app.MapClockCalculatorEndpoints();

app.Run();
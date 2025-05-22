using ClockCalculator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IClockCalculatorService, ClockCalculatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/calculatetimeangle",
        (int hours, int minutes, IClockCalculatorService clockCalculatorService) =>
            clockCalculatorService.CalculateTimeAngle(hours, minutes))
    .WithName("CalculateTimeAngle");

app.Run();
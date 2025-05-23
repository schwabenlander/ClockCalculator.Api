using ClockCalculator.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IClockCalculatorService, ClockCalculatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/calculatetimeangle",
        (int hours, int minutes, IClockCalculatorService clockCalculatorService) =>
            clockCalculatorService.CalculateTimeAngle(hours, minutes))
    .WithName("CalculateTimeAngle");

app.MapGet("/api/calculatetimeangle/{time}",
        (string time, IClockCalculatorService clockCalculatorService) =>
        {
            var parts = time.Split(':');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int hours) || !int.TryParse(parts[1], out int minutes))
            {
                return Results.BadRequest("Invalid time format. Use HH:MM format.");
            }
            return Results.Ok(clockCalculatorService.CalculateTimeAngle(hours, minutes));
        })
    .WithName("CalculateTimeAngleFromString");

app.Run();
namespace ClockCalculator.Api.Services;

public class ClockCalculatorService : IClockCalculatorService
{
    // This could (should) be made more precise by taking into account the minute angle
    // However, I would need to ask ChatGPT how to do that, so I'll keep it simple for now
    public double CalculateHourAngle(int hours)
    {
        // Each hour represents 30 degrees
        return hours * 30d;
    }
    

    public double CalculateMinuteAngle(int minutes)
    {
        // Each minute represents 6 degrees
        return minutes * 6d;
    }
    
    public double CalculateTimeAngle(int hours, int minutes)
    {
        var hourAngle = CalculateHourAngle(hours);
        var minuteAngle = CalculateMinuteAngle(minutes);
        return hourAngle + minuteAngle;
    }
}
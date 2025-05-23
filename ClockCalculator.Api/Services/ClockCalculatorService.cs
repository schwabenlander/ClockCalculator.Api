namespace ClockCalculator.Api.Services;

public class ClockCalculatorService : IClockCalculatorService
{
    public double CalculateHourAngle(int hours, int minutes)
    {
        // Each hour represents 30 degrees
        var angle = hours * 30d;
        
        // Each minute represents 0.5 degrees
        angle += minutes * 0.5d;

        return angle;
    }
    

    public double CalculateMinuteAngle(int minutes)
    {
        // Each minute represents 6 degrees
        return minutes * 6d;
    }
    
    public double CalculateTimeAngle(int hours, int minutes)
    {
        var hourAngle = CalculateHourAngle(hours, minutes);
        var minuteAngle = CalculateMinuteAngle(minutes);
        return hourAngle + minuteAngle;
    }
}
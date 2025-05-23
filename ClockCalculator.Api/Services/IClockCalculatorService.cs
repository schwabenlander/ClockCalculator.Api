namespace ClockCalculator.Api.Services;

public interface IClockCalculatorService
{
    double CalculateHourAngle(int hours, int minutes);
    
    double CalculateMinuteAngle(int minutes);
    
    double CalculateTimeAngle(int hours, int minutes);
}
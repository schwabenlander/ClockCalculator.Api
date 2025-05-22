using ClockCalculator.Api.Services;

namespace ClockCalculator.Tests;

public class ClockCalculatorService_Tests
{
    // System under test (SUT)
    private readonly ClockCalculatorService _service = new();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 30)]
    [InlineData(3, 90)]
    [InlineData(6, 180)]
    [InlineData(9, 270)]
    [InlineData(12, 360)]
    public void CalculateHourAngle_ReturnsCorrectAngle(int hours, double expectedAngle)
    {
        // Act
        var result = _service.CalculateHourAngle(hours);
        
        // Assert
        Assert.Equal(expectedAngle, result);
    }
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(15, 90)]
    [InlineData(30, 180)]
    [InlineData(45, 270)]
    [InlineData(60, 360)]
    public void CalculateMinuteAngle_ReturnsCorrectAngle(int minutes, double expectedAngle)
    {
        // Act
        var result = _service.CalculateMinuteAngle(minutes);
        
        // Assert
        Assert.Equal(expectedAngle, result);
    }
    
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 30)]
    [InlineData(0, 30, 180)]
    [InlineData(3, 15, 180)]
    [InlineData(6, 30, 360)]
    [InlineData(9, 45, 540)]
    [InlineData(12, 0, 360)]
    public void CalculateTimeAngle_ReturnsCorrectAngle(int hours, int minutes, double expectedAngle)
    {
        // Act
        var result = _service.CalculateTimeAngle(hours, minutes);
        
        // Assert
        Assert.Equal(expectedAngle, result);
    }
}
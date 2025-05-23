using ClockCalculator.Api.Services;

namespace ClockCalculator.Tests;

public class ClockCalculatorService_Tests
{
    // System under test (SUT)
    private readonly ClockCalculatorService _service = new();

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 30)]
    [InlineData(3, 0, 90)]
    [InlineData(6, 0, 180)]
    [InlineData(9, 0, 270)]
    [InlineData(12, 0, 360)]
    [InlineData(1, 30, 45)] // 30 + (0.5 * 30)
    [InlineData(3, 15, 97.5)] // 90 + (0.5 * 15)
    [InlineData(6, 45, 202.5)] // 180 + (0.5 * 45)
    public void CalculateHourAngle_ReturnsCorrectAngle(int hours, int minutes, double expectedAngle)
    {
        // Act
        var result = _service.CalculateHourAngle(hours, minutes);
        
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
    [InlineData(0, 30, 195)] // 0 + (0.5 * 30) + (30 * 6)
    [InlineData(3, 15, 187.5)] // 90 + (0.5 * 15) + (15 * 6)
    [InlineData(6, 30, 375)] // 180 + (0.5 * 30) + (30 * 6)
    [InlineData(9, 45, 562.5)] // 270 + (0.5 * 45) + (45 * 6)
    [InlineData(12, 0, 360)]
    public void CalculateTimeAngle_ReturnsCorrectAngle(int hours, int minutes, double expectedAngle)
    {
        // Act
        var result = _service.CalculateTimeAngle(hours, minutes);
        
        // Assert
        Assert.Equal(expectedAngle, result);
    }
}
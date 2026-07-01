using System.ComponentModel;
using ClockCalculator.Api.Services;
using ModelContextProtocol.Server;

namespace ClockCalculator.Api.MCP.Tools;

[McpServerToolType]
public class CalculateTimeAngleTool(IClockCalculatorService clockCalculatorService)
{
    [McpServerTool, Description("Calculate the time angle for a given time. Takes hours and minutes as input.")]
    public double CalculateAngle(
        [Description("Hour component, 0-12")] int hours,
        [Description("Minute component, 0-59")] int minutes)
    {
        var result = clockCalculatorService.CalculateTimeAngle(hours, minutes);
        return result;
    }
}
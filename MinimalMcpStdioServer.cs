#:package ModelContextProtocol@0.4.0-preview.3
#:package Microsoft.Extensions.Hosting@10.0.0-rc.2.25502.107

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<Tools>();

await builder.Build().RunAsync();

[McpServerToolType]
public class Tools
{
    [McpServerTool]
    [Description("Gets a weather forecast based on the city in JSON format.")]
    public async Task<string> GetWeatherForecast(
        [Description("Name of the city to get the weather forecast")] string city)
    {
        using var httpClient = new HttpClient();
        var url = $"https://wttr.in/{Uri.EscapeDataString(city)}?format=j1"; // Updated format for JSON response
        try
        {
            var response = await httpClient.GetStringAsync(url);
            return response;
        }
        catch (Exception ex)
        {
            return $"Error fetching weather data: {ex.Message}";
        }
    }
}
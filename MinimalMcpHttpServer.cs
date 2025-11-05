#:sdk Microsoft.NET.Sdk.Web

#:package ModelContextProtocol.AspNetCore@0.4.0-preview.3

using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithTools<Tools>();

var app = builder.Build();

app.MapMcp();

app.Run("http://localhost:5000");

[McpServerToolType]
public class Tools
{
    private readonly ILogger<Tools> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public Tools(ILogger<Tools> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
    
    [McpServerTool]
    [Description("Gets a weather forecast based on the city in JSON format.")]
    public async Task<string> GetWeatherForecast(
        [Description("Name of the city to get the weather forecast")] string city)
    {
        using var httpClient = _httpClientFactory.CreateClient();
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
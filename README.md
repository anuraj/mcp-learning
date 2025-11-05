# MCP Learning

A learning repository demonstrating the implementation of **Model Context Protocol (MCP)** servers in C# using the `ModelContextProtocol` NuGet packages. This repository contains examples of both HTTP and STDIO transport implementations.

## 🚀 Features

Both servers implement the same MCP functionality with different transport mechanisms:

### Common Features
- **Tools**: Executable functions exposed to MCP clients
  - `GetWeatherForecast` - Fetches weather forecast in JSON format from wttr.in API
- **Prompts**: Pre-defined prompt templates
  - `WeatherForecastPrompt` - Template for weather forecast queries
- **Resources**: Static data or configuration values
  - `DefaultCity` - Returns "San Francisco" as the default city

## 📦 Requirements

- .NET SDK (compatible with .NET 10.0-rc.2 or later)
- VS Code

## 🛠️ Usage

### Integrating with VS Code

The STDIO server can be configured in VS Code using the `.vscode/mcp.json` configuration file:

```jsonc
{
  "servers": {
    "minimal-mcp-server": {
      "type": "stdio",
      "command": "dotnet",
      "args": ["run", "./MinimalMcpStdioServer.cs"]
    }
  }
}
```

Once configured, GitHub Copilot in VS Code can discover and use the exposed tools.

## 📝 How it works

![GitHub Copilot using MCP Tool](github_copilot.png)

## 🔧 Configuration

The repository includes:
- `.vscode/mcp.json` - VS Code MCP server configuration
- `.devcontainer/` - Development container configuration (if using Dev Containers)

## 🤝 Contributing

This is a learning repository. Feel free to experiment with:
- Adding new tools (e.g., file operations, data processing)
- Implementing additional prompts and resources
- Exploring different transport mechanisms
- Adding authentication and authorization
- Integrating with other AI assistants and tools

## 📖 Resources

- [Model Context Protocol Documentation](https://modelcontextprotocol.io/)
- [ModelContextProtocol NuGet Package](https://www.nuget.org/packages/ModelContextProtocol)
- [ModelContextProtocol.AspNetCore NuGet Package](https://www.nuget.org/packages/ModelContextProtocol.AspNetCore)
- [GitHub Copilot MCP Integration](https://code.visualstudio.com/docs/copilot/)
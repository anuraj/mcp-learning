# MCP Learning

A learning repository demonstrating the implementation of **Model Context Protocol (MCP)** servers in C# using the `ModelContextProtocol` NuGet packages. This repository contains examples of both HTTP and STDIO transport implementations.

## 📋 Overview

This repository showcases two different MCP server implementations:

1. **MinimalMcpHttpServer.cs** - An HTTP-based MCP server using ASP.NET Core
2. **MinimalMcpStdioServer.cs** - A STDIO-based MCP server using Microsoft.Extensions.Hosting

## 🚀 Features

### HTTP Server (`MinimalMcpHttpServer.cs`)
- Built with ASP.NET Core Minimal APIs
- Uses `ModelContextProtocol.AspNetCore` package (v0.4.0-preview.3)
- Exposes tools via HTTP transport
- **Tools included:**
  - `GetWeatherForecast` - Fetches weather data for a specified city from wttr.in API

### STDIO Server (`MinimalMcpStdioServer.cs`)
- Built with Microsoft.Extensions.Hosting
- Uses `ModelContextProtocol` package (v0.4.0-preview.3)
- Communicates via standard input/output
- **Tools included:**
  - `GetWeatherForecast` - Fetches weather data for a specified city from wttr.in API

## 📦 Requirements

- .NET SDK (compatible with .NET 10.0-rc.2 or later)
- VS Code

## 🛠️ Usage

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

## 📚 Key Concepts

- **MCP (Model Context Protocol)**: A protocol for exposing tools and resources to AI assistants
- **Transport Types**: 
  - HTTP - RESTful API approach
  - STDIO - Standard input/output for local process communication
- **Tool Registration**: Using `[McpServerTool]` and `[McpServerToolType]` attributes
- **Dependency Injection**: Both implementations support DI for services like logging and HTTP clients

## 🔧 Configuration

The repository includes:
- `.vscode/mcp.json` - VS Code MCP server configuration
- `.devcontainer/` - Development container configuration (if using Dev Containers)

## 📝 Notes

- C# scripts use `#:` directives for SDK and package references
- The HTTP server uses ASP.NET Core infrastructure
- The STDIO server logs to standard error to avoid interfering with MCP communication
- Both implementations use preview versions of the ModelContextProtocol packages

## 🤝 Contributing

This is a learning repository. Feel free to experiment with:
- Adding new tools
- Trying different transport mechanisms
- Implementing prompts and resources
- Exploring advanced MCP features
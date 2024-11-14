# MS SQL Query Tool

This project is a simple ASP.NET Core application designed to provide a web interface for output of SQL queries against a Microsoft SQL Server database. Users can specify their database connection string and the query to be executed in the `appsettings.json` file.

## Getting Started

In `appsettings.json`
* `DefaultConnection` - update the connection string to point to your SQL Server database server
* `DefaultQuery` - put your SQL query here

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
- The following NuGet packages installed in your project:
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`
- Access to a Microsoft SQL Server database with the necessary permissions to execute queries.

### How to run

Go to [SQLQueryTool](https://github.com/JahyLuky/SQLQueryTool) repository.

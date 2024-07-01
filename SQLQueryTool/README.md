# MS SQL Query Tool

This project is a simple ASP.NET Core application designed to provide a web interface for executing SQL queries against a Microsoft SQL Server database. Users can specify their database connection string and the SQL query they want to execute directly in the `appsettings.json` file.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- Microsoft SQL Server installed, with access to a database and necessary permissions to execute queries.

### Usage

In `appsettings.json`
* `DefaultConnection` - update the connection string to point to your SQL Server database server
*  `SqlQuery` - specify your SQL query that you want to execute

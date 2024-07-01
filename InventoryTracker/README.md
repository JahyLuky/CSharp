# InventoryTracker

"InventoryTracker" is a CRUD application built using WPF (Windows Presentation Foundation) and .NET 8, designed to manage inventory items efficiently. This README.md file outlines what was used and learned throughout the project.

## Technologies Used

- **WPF (Windows Presentation Foundation)**: Used for creating the graphical user interface (GUI) of the application.
- **.NET 8**: The framework used for developing the application logic and data access.
- **MVVM (Model-View-ViewModel) Pattern**: Implemented to separate the UI from the business logic and data models.
- **MS SQL Server**: Integrated for database operations to store and manage inventory data.

## Setting Up the Project

### Prerequisites

- Visual Studio 2022 or later
- .NET 8 SDK
- Microsoft SQL Server (optional, for database integration)

### Creating the Project

1. **Open Visual Studio:**

   Launch Visual Studio 2022.

2. **Create a New Project:**

   - Go to File -> New -> Project.
   - Select WPF App (.NET) from the list of project templates.

3. **Name Your Project:**

   - Enter "InventoryTracker" as the name for your project.

4. **Choose Project Location:**

   - Select the location where you want to save your project files.

5. **Configure Project Settings:**

   - Choose .NET 8 as the target framework.
   - Set up other project settings as needed.

6. **Create Project:**

   - Click on "Create" to generate your new WPF project based on the selected template.

## Getting Started with InventoryTracker

### Project Structure

- Familiarize yourself with the following files and folders created by Visual Studio:
  - `MainWindow.xaml`: Main window UI definition.
  - `MainWindow.xaml.cs`: Code-behind file for the main window.
  - `App.xaml`: Application-level resources and settings.

### Designing UI with XAML

- Open `MainWindow.xaml` to start designing your application's user interface using XAML.

### Implementing CRUD Functionality

1. **Set Up Data Model:**

   Define data models (e.g., `InventoryItem`) for inventory items.

2. **Implement CRUD Operations:**

   - Use MVVM pattern or code-behind approach to implement Create, Read, Update, and Delete operations.
   - Bind UI elements to data using data binding in XAML.

### Connecting to MS SQL Server

- If integrating with SQL Server:
  - Add Entity Framework Core or use ADO.NET to connect to your SQL Server database.
  - Perform data operations (CRUD) using Entity Framework Core's DbContext.

### Testing and Iterating

- Test your application as you build each feature.
- Iterate on the design and functionality based on user feedback or your own testing.

## Additional Resources

- [Microsoft Docs on WPF](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
- [Microsoft Docs on .NET](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- Online tutorials and resources for learning WPF CRUD applications and MVVM pattern.

By following these steps and utilizing the technologies mentioned, you'll develop a robust "InventoryTracker" application capable of managing inventory efficiently using WPF and .NET 8. Enjoy your learning journey with WPF and database integration!

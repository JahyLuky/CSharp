# InventoryTracker

"InventoryTracker" is a CRUD application built using WPF (Windows Presentation Foundation) and .NET 8, designed to efficiently manage inventory items. This README.md file outlines the technologies utilized, setup instructions, and key features of the project.

## Technologies Used

- **WPF (Windows Presentation Foundation)**: Used for creating the graphical user interface (GUI) of the application.
- **.NET 8**: The framework used for developing the application logic and data access.
- **MVVM (Model-View-ViewModel) Pattern**: Implemented to separate the UI from the business logic and data models.
- **SQLite**: Integrated for local database operations to store and manage inventory data.
- **Password Hashing**: Implemented to securely store and manage user passwords.
- **Entity Framework Core**: Utilized for database access and management.

### User Management

- Implement login functionality with hashed passwords for security.
- Manage user roles (Admin, User) to control access to features.

### Database Integration

- Use Entity Framework Core with SQLite for local database operations.
- Set up database tables (`InventoryDatabase.cs`) and manage data securely.

## Additional Features

### Admin Features

- Display user management options (add, delete, save, cancel, show users) upon login.
- Allow admin users to manage user accounts and permissions.

## Testing and Iterating

- Test each feature of the application to ensure functionality and reliability.
- Iterate on the design and functionality based on user feedback and testing results.


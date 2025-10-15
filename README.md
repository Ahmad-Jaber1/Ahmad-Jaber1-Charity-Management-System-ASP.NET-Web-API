# Charity Management System - ASP.NET Web API

A backend API for managing charity operations, including assistance types, beneficiaries, organizational data, and user authentication. Built using ASP.NET Core Web API and SQL Server.

## Features

- **Assistance Management:** Track and manage different types of assistance provided (financial, non-financial, etc.).
- **Beneficiary Management:** Store and organize information on families, individuals, and guardians.
- **Membership & Receipts:** Manage general assembly members, basic members, and their payment receipts.
- **Authentication & Authorization:** Secure endpoints using ASP.NET Identity and JWT.
- **File Uploads:** Support for uploading and managing files related to charity operations.

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core (Code First & Migrations)
- SQL Server
- ASP.NET Identity (User Management & JWT Authentication)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/Ahmad-Jaber1/Ahmad-Jaber1-Charity-Management-System-ASP.NET-Web-API.git
   cd Ahmad-Jaber1-Charity-Management-System-ASP.NET-Web-API
   ```

2. **Configure Database Connection**

   Edit `appsettings.json` to set your SQL Server connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=CharityDb;Trusted_Connection=True;"
   }
   ```

3. **Apply Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the API**
   ```bash
   dotnet run --project Charity
   ```

5. **API Documentation**
   - Swagger UI available at `http://localhost:5000/swagger` (if enabled).

## Project Structure

- `Charity/` - Main API entry point.
- `Models/` - Entity and DTO classes.
- `Repository/` - Data access layer (generic repository pattern).
- `Services/` - Business logic layer.
- `Migrations/` - Entity Framework Core migration files.

## Contributing

Contributions, issues, and feature requests are welcome!  
Feel free to check the [issues page](https://github.com/Ahmad-Jaber1/Ahmad-Jaber1-Charity-Management-System-ASP.NET-Web-API/issues).

## License

**Note:** *No license file is currently included. Please add one (MIT, Apache, etc.) to clarify usage.*

## Author

- Ahmad Jaber  
  [GitHub Profile](https://github.com/Ahmad-Jaber1)

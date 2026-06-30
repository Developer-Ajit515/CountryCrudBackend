# 🌍 Country CRUD API with Payment Module

A RESTful ASP.NET Core Web API project that provides secure Country CRUD operations with JWT Authentication, Role-Based Authorization, and Razorpay Payment Integration. The project follows clean coding practices and demonstrates enterprise-level backend development using Entity Framework Core and SQL Server.

---

## 🚀 Features

* User Registration
* User Login
* JWT Authentication
* Role-Based Authorization (Admin/User)
* Country CRUD Operations
* Razorpay Payment Integration
* Entity Framework Core
* SQL Server Database
* Repository Pattern
* Dependency Injection
* Swagger API Documentation
* Input Validation
* Global Exception Handling
* Clean Project Structure

---

## 🛠️ Technologies Used

* ASP.NET Core Web API (.NET)
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Razorpay Payment Gateway
* Swagger (OpenAPI)
* Visual Studio 2022
* Git & GitHub

---

## 📂 Project Structure

```
CountryCrud
│
├── Controllers
├── Models
├── DTOs
├── Data
├── Repositories
├── Services
├── Middleware
├── Authentication
├── Payment
├── Migrations
├── wwwroot
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 🔐 Authentication

The API uses JWT (JSON Web Token) authentication.

### Available Endpoints

#### Authentication

* Register User
* Login User
* Generate JWT Token

#### Country

* Create Country
* Get All Countries
* Get Country By Id
* Update Country
* Delete Country

#### Payment

* Create Razorpay Order
* Verify Payment
* Payment Status

---

## ⚙️ Installation

### Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/CountryCrud.git
```

### Navigate to Project

```bash
cd CountryCrud
```

### Restore Packages

```bash
dotnet restore
```

### Update Database

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

Or run the project directly from Visual Studio.

---

## 📖 API Documentation

After running the application, open Swagger:

```
https://localhost:5001/swagger
```

or

```
https://localhost:7xxx/swagger
```

(depending on your configured port)

---

## 🔑 Configuration

Update the following values in **appsettings.json**:

* SQL Server Connection String
* JWT Secret Key
* Razorpay Key
* Razorpay Secret

Example:

```json
"ConnectionStrings": {
  "conStr": "Your SQL Server Connection String"
}

"Jwt": {
  "Key": "YourSecretKey"
}

"Razorpay": {
  "Key": "rzp_test_xxxxxxxxx",
  "Secret": "xxxxxxxxxxxxx"
}
```

---

## 🧪 Testing

You can test the API using:

* Swagger UI
* Postman
* Thunder Client

---

## 📌 Future Enhancements

* Refresh Token Authentication
* Pagination & Filtering
* Search API
* Unit Testing
* Logging with Serilog
* Docker Support
* Azure Deployment

---

## 👨‍💻 Author

**Ajit Singh**

* ASP.NET Core Developer
* C# Developer
* SQL Server
* Entity Framework Core

---

## 📄 License

This project is intended for learning, portfolio, and demonstration purposes.

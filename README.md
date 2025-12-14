# 📊 SurveyBasket API

A modern, scalable RESTful API for creating and managing surveys/polls built with **ASP.NET Core 9** following Clean Architecture principles.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-13.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)

## 📋 Table of Contents

- [Features](#-features)
- [Architecture](#-architecture)
- [Technologies](#-technologies)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Project Structure](#-project-structure)
- [Configuration](#-configuration)
- [Contributing](#-contributing)
- [License](#-license)

## ✨ Features

- **Poll Management** - Create, update, delete, and publish polls with customizable start/end dates
- **Question & Answer System** - Add multiple questions with various answer options to polls
- **Voting System** - Users can vote on active polls with validation to prevent duplicate votes
- **Results & Analytics** - View poll results with detailed analytics including:
  - Raw voting data
  - Votes per day
  - Votes per question breakdown
- **Authentication & Authorization** - Secure JWT-based authentication with refresh token support
- **Token Management** - Refresh and revoke tokens for enhanced security
- **Input Validation** - Comprehensive request validation using FluentValidation
- **API Documentation** - Interactive Swagger/OpenAPI documentation
- **Structured Logging** - Serilog integration for comprehensive logging

## 🏗 Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                      Presentation Layer                      │
│                     (SurveyBasket.Api)                       │
│              Controllers, Authentication, DI                 │
├─────────────────────────────────────────────────────────────┤
│                      Application Layer                       │
│                  (SurveyBasket.Application)                  │
│           Services, Mapping, Validations                     │
├─────────────────────────────────────────────────────────────┤
│                    Abstractions Layer                        │
│            (SurveyBasket.Application.Abstractions)           │
│          Interfaces, DTOs, Contracts                         │
├─────────────────────────────────────────────────────────────┤
│                      Domain Layer                            │
│                   (SurveyBasket.Domain)                      │
│                Entities, Core Business Logic                 │
├─────────────────────────────────────────────────────────────┤
│                   Infrastructure Layer                       │
│                (SurveyBasket.Infrastructure)                 │
│         DbContext, Migrations, Configurations                │
└─────────────────────────────────────────────────────────────┘
```

## 🛠 Technologies

| Category | Technology |
|----------|------------|
| Framework | ASP.NET Core 9 |
| Language | C# 13 |
| ORM | Entity Framework Core 9 |
| Database | SQL Server |
| Authentication | JWT Bearer Tokens |
| Validation | FluentValidation |
| Logging | Serilog |
| Documentation | Swagger / OpenAPI |

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or full instance)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/muhammadabdelgawad/SurveyBasket.git
   cd SurveyBasket
   ```

2. **Configure the database connection**
   
   Update the connection string in `appsettings.json` or use User Secrets:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SurveyBasketDb;Trusted_Connection=True;"
     }
   }
   ```

3. **Configure JWT settings**
   ```json
   {
     "Jwt": {
       "Key": "your-super-secret-key-here",
       "Issuer": "SurveyBasket",
       "Audience": "SurveyBasketUsers",
       "ExpiryMinutes": 60
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
   ```

5. **Run the application**
   ```bash
   dotnet run --project SurveyBasket.Api
   ```

6. **Access the API**
   - Swagger UI: `https://localhost:{port}/swagger`

## 📡 API Endpoints

### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/Auth/login` | Authenticate user and get tokens |
| POST | `/Auth/refresh` | Refresh access token |
| POST | `/Auth/revoke-refresh-token` | Revoke refresh token |

### Polls
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Polls` | Get all polls |
| GET | `/api/Polls/current` | Get currently active polls |
| GET | `/api/Polls/{id}` | Get poll by ID |
| POST | `/api/Polls` | Create a new poll |
| PUT | `/api/Polls/{id}` | Update a poll |
| DELETE | `/api/Polls/{id}` | Delete a poll |
| PUT | `/api/Polls/{id}/togglePublish` | Toggle poll publish status |

### Questions
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Polls/{pollId}/Questions` | Get all questions for a poll |
| GET | `/api/Polls/{pollId}/Questions/{id}` | Get question by ID |
| POST | `/api/Polls/{pollId}/Questions` | Add question to poll |
| PUT | `/api/Polls/{pollId}/Questions/{id}` | Update a question |
| DELETE | `/api/Polls/{pollId}/Questions/{id}` | Delete a question |

### Votes
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/polls/{pollId}/votes` | Start voting (get available questions) |
| POST | `/api/polls/{pollId}/votes` | Submit vote |

### Results
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/polls/{pollId}/Results/row-data` | Get raw voting data |
| GET | `/api/polls/{pollId}/Results/votes-per-day` | Get votes per day statistics |
| GET | `/api/polls/{pollId}/Results/votes-per-question` | Get votes per question breakdown |

## 📁 Project Structure

```
SurveyBasket/
├── SurveyBasket.Api/                    # Presentation Layer
│   ├── Controllers/                     # API Controllers
│   │   ├── AuthController.cs
│   │   ├── PollsController.cs
│   │   ├── QuestionsController.cs
│   │   ├── VotesController.cs
│   │   └── ResultsController.cs
│   ├── Authentication/                  # JWT Configuration
│   ├── DependencyInjection/            # DI Configuration
│   ├── Extensions/                      # Extension Methods
│   └── Program.cs                       # Application Entry Point
│
├── SurveyBasket.Application/            # Application Layer
│   ├── Services/                        # Business Logic Services
│   ├── Mapping/                         # Object Mapping Configurations
│   └── Validations/                     # Request Validators
│
├── SurveyBasket.Application.Abstractions/  # Abstractions Layer
│   └── (Interfaces, DTOs, Contracts)
│
├── SurveyBasket.Domain/                 # Domain Layer
│   └── Entities/                        # Domain Entities
│       ├── Poll.cs
│       ├── Question.cs
│       ├── Answer.cs
│       ├── Vote.cs
│       ├── VoteAnswer.cs
│       ├── ApplicationUser.cs
│       └── RefreshToken.cs
│
└── SurveyBasket.Infrastructure/         # Infrastructure Layer
    ├── AppDbContext.cs                  # EF Core DbContext
    ├── Migrations/                      # Database Migrations
    └── EntitiesConfigurations/          # Entity Type Configurations
```

## ⚙ Configuration

### appsettings.json Structure

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your connection string"
  },
  "Jwt": {
    "Key": "Your JWT secret key",
    "Issuer": "SurveyBasket",
    "Audience": "SurveyBasketUsers",
    "ExpiryMinutes": 60
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Muhammad Abdelgawad**

- GitHub: [@muhammadabdelgawad](https://github.com/muhammadabdelgawad)

---

⭐ If you find this project helpful, please give it a star!

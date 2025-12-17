# 📊 SurveyBasket API

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-13.0-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)](https://jwt.io/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

> **A production-ready, enterprise-grade RESTful API for creating and managing surveys and polls, built with ASP.NET Core 9 following Onion Architecture and SOLID principles.**

## 🌟 Overview

SurveyBasket is a modern, scalable survey management platform designed to handle complex polling scenarios with high performance and reliability. Built with best practices and enterprise patterns, it provides a robust foundation for survey-based applications.

### Why SurveyBasket?

- 🏗️ **Clean Architecture** - Maintainable, testable, and scalable codebase
- 🚀 **High Performance** - Distributed caching with HybridCache for optimal response times
- 🔒 **Security First** - JWT authentication with refresh tokens and secure token management
- 📊 **Rich Analytics** - Comprehensive voting statistics and real-time results
- ✅ **Type Safety** - Discriminated unions using OneOf for railway-oriented programming
- 🎯 **Validation** - FluentValidation for robust input validation
- 📝 **API Documentation** - Interactive Swagger/OpenAPI documentation
- 📈 **Observability** - Structured logging with Serilog

---

## 📋 Table of Contents

- [Features](#-features)
- [Architecture](#-architecture)
- [Technology Stack](#-technology-stack)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [API Documentation](#-api-documentation)
- [Project Structure](#-project-structure)
- [Key Features Deep Dive](#-key-features-deep-dive)
- [Performance & Caching](#-performance--caching)
- [Security](#-security)
- [Development](#-development)
- [Contributing](#-contributing)
- [License](#-license)
- [Author](#-author)

---

## ✨ Features

### Core Functionality

#### 🗳️ Poll Management
- Create, update, and delete polls with intuitive API
- Publish/unpublish polls with toggle functionality
- Set custom start and end dates for poll availability
- Automatic poll status management (Draft, Active, Ended)
- Retrieve current active polls or all polls

#### ❓ Question & Answer System
- Add multiple questions to each poll
- Support for various answer options per question
- Update and delete questions dynamically
- Maintain question order and relationships

#### 🎯 Voting System
- Secure voting mechanism with authentication
- Duplicate vote prevention per user per poll
- Vote on multiple questions in a single submission
- Real-time vote recording and validation

#### 📈 Results & Analytics
- **Raw Data Export** - Complete voting records for analysis
- **Time-Series Analytics** - Votes per day breakdown
- **Question Analytics** - Detailed votes per question statistics
- **User Participation Tracking** - Monitor engagement metrics

### Technical Features

#### 🔐 Authentication & Authorization
- JWT-based authentication with access and refresh tokens
- Secure token generation and validation
- Token refresh mechanism for seamless user experience
- Token revocation for enhanced security
- Role-based authorization ready

#### ⚡ Performance Optimization
- **Distributed Caching** - Microsoft.Extensions.Caching.Hybrid implementation
- Async/await throughout for optimal scalability
- Efficient database queries with EF Core
- Response caching for frequently accessed data

#### ✅ Input Validation
- FluentValidation integration for comprehensive request validation
- Automatic model validation with SharpGrip.FluentValidation.AutoValidation
- Custom validation rules for business logic
- Detailed validation error messages

#### 📊 Logging & Monitoring
- Structured logging with Serilog
- Request/response logging
- Error tracking and diagnostics
- Performance monitoring capabilities

#### 🗺️ Object Mapping
- High-performance object mapping with Mapster
- Automatic DTO conversions
- Custom mapping configurations

#### 🛡️ Error Handling
- Railway-oriented programming with OneOf
- Graceful error responses
- Consistent error format across API
- Detailed error messages for debugging

---

## 🏗 Architecture

SurveyBasket follows **Onion Architecture** principles with clear separation of concerns and dependency inversion:

```
┌─────────────────────────────────────────────────────────────────────┐
│                         Presentation Layer                          │
│                       (SurveyBasket.Api)                            │
│                                                                     │
│  • API Controllers (Polls, Questions, Votes, Results, Auth)        │
│  • JWT Authentication Configuration                                │
│  • Dependency Injection Setup                                      │
│  • Middleware Pipeline                                             │
│  • Swagger Configuration                                           │
└─────────────────────────────────────────────────────────────────────┘
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                        Application Layer                            │
│                    (SurveyBasket.Application)                       │
│                                                                     │
│  • Business Logic Services (Auth, Poll, Question, Vote, Result)    │
│  • Object Mapping (Mapster)                                        │
│  • Request Validators (FluentValidation)                           │
│  • Cache Service Implementation                                    │
└─────────────────────────────────────────────────────────────────────┘
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                       Abstractions Layer                            │
│              (SurveyBasket.Application.Abstractions)                │
│                                                                     │
│  • Service Interfaces (IAuthService, IPollService, etc.)           │
│  • Repository Interfaces (ICacheService)                           │
│  • DTOs (Request/Response Models)                                  │
│  • Result Types (OneOf Discriminated Unions)                       │
│  • Constants & Enums                                               │
└─────────────────────────────────────────────────────────────────────┘
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                          Domain Layer                               │
│                     (SurveyBasket.Domain)                           │
│                                                                     │
│  • Domain Entities (Poll, Question, Answer, Vote, VoteAnswer)      │
│  • Domain Models (ApplicationUser, RefreshToken)                   │
│  • Business Rules & Invariants                                     │
│  • Domain Events (if applicable)                                   │
└─────────────────────────────────────────────────────────────────────┘
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                      Infrastructure Layer                           │
│                  (SurveyBasket.Infrastructure)                      │
│                                                                     │
│  • Entity Framework Core DbContext                                 │
│  • Database Migrations                                             │
│  • Entity Type Configurations                                      │
│  • Data Seeding                                                    │
│  • External Service Integrations                                   │
└─────────────────────────────────────────────────────────────────────┘
```

### Architecture Benefits

- ✅ **Testability** - Each layer can be tested independently
- ✅ **Maintainability** - Clear separation of concerns
- ✅ **Scalability** - Easy to extend and modify
- ✅ **Flexibility** - Swap implementations without affecting business logic
- ✅ **Independence** - Business logic independent of frameworks and databases

---

## 🛠 Technology Stack

### Core Technologies

| Category | Technology | Version | Purpose |
|----------|------------|---------|---------|
| **Framework** | ASP.NET Core | 9.0 | Web API framework |
| **Language** | C# | 13.0 | Programming language |
| **Runtime** | .NET | 9.0 | Application runtime |
| **ORM** | Entity Framework Core | 9.0.10 | Database access |
| **Database** | SQL Server | 2019+ | Data persistence |

### Libraries & Packages

#### Authentication & Security
- **Microsoft.AspNetCore.Authentication.JwtBearer** `9.0.10` - JWT authentication
- **System.IdentityModel.Tokens.Jwt** - Token generation and validation

#### Caching & Performance
- **Microsoft.Extensions.Caching.Hybrid** `9.10.0` - Distributed caching with L1/L2 support
- **Microsoft.Extensions.Caching.Abstractions** - Caching abstractions

#### Validation
- **FluentValidation** `12.0.0` - Fluent validation library
- **FluentValidation.AspNetCore** `11.3.1` - ASP.NET Core integration
- **SharpGrip.FluentValidation.AutoValidation.Mvc** `1.5.0` - Automatic validation

#### Object Mapping
- **Mapster** `7.4.0` - High-performance object mapper
- **Mapster.DependencyInjection** `1.0.1` - DI integration

#### Error Handling
- **OneOf** `3.0.271` - Discriminated unions for result types

#### Logging
- **Serilog.AspNetCore** `9.0.0` - Structured logging

#### API Documentation
- **Swashbuckle.AspNetCore** `9.0.6` - Swagger/OpenAPI generation
  - Swagger
  - SwaggerGen
  - SwaggerUI

---

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- ✅ [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (version 9.0.0 or higher)
- ✅ [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (2019 or higher, or LocalDB)
- ✅ [Visual Studio 2022](https://visualstudio.microsoft.com/) (17.8+) or [Visual Studio Code](https://code.visualstudio.com/)
- ✅ [Git](https://git-scm.com/downloads)

**Optional but Recommended:**
- [Azure Data Studio](https://azure.microsoft.com/en-us/products/data-studio/) or [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- [Postman](https://www.postman.com/downloads/) or similar API testing tool

### Installation

#### 1. Clone the Repository

```bash
git clone https://github.com/muhammadabdelgawad/SurveyBasket.git
cd SurveyBasket
```

#### 2. Restore Dependencies

```bash
dotnet restore
```

#### 3. Configure Database Connection

Update the connection string in `SurveyBasket.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SurveyBasketDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**For SQL Server Express:**
```json
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=SurveyBasketDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

**For Azure SQL:**
```json
"DefaultConnection": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=SurveyBasketDb;Persist Security Info=False;User ID=your-username;Password=your-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

#### 4. Configure JWT Settings

Update JWT configuration in `appsettings.json` (or use User Secrets for production):

```json
{
  "Jwt": {
    "Key": "your-super-secret-key-minimum-32-characters-long",
    "Issuer": "SurveyBasket",
    "Audience": "SurveyBasketUsers",
    "ExpiryMinutes": 60
  }
}
```

**Using User Secrets (Recommended for Development):**

```bash
cd SurveyBasket.Api
dotnet user-secrets init
dotnet user-secrets set "Jwt:Key" "your-super-secret-key-minimum-32-characters-long"
```

#### 5. Apply Database Migrations

```bash
dotnet ef database update --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
```

**If you don't have Entity Framework Core tools installed:**

```bash
dotnet tool install --global dotnet-ef
```

#### 6. Run the Application

```bash
dotnet run --project SurveyBasket.Api
```

Or using Visual Studio:
- Open `SurveyBasket.sln`
- Set `SurveyBasket.Api` as the startup project
- Press `F5` or click **Run**

#### 7. Access the API

Once running, you can access:

- **Swagger UI**: `https://localhost:5001/swagger` (or the port shown in console)
- **API Base URL**: `https://localhost:5001/api`
- **Health Check**: `https://localhost:5001/health` (if configured)

### Configuration

#### appsettings.json Structure

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your SQL Server connection string"
  },
  "Jwt": {
    "Key": "Your secret key (min 32 characters)",
    "Issuer": "SurveyBasket",
    "Audience": "SurveyBasketUsers",
    "ExpiryMinutes": 60,
    "RefreshTokenExpiryDays": 7
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Serilog": {
    "Using": ["Serilog.Sinks.Console", "Serilog.Sinks.File"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      { "Name": "Console" },
      {
        "Name": "File",
        "Args": {
          "path": "Logs/log-.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  }
}
```

#### Environment Variables

For production deployments, use environment variables:

```bash
export ConnectionStrings__DefaultConnection="your-connection-string"
export Jwt__Key="your-secret-key"
export Jwt__Issuer="SurveyBasket"
export Jwt__Audience="SurveyBasketUsers"
```

---

## 📡 API Documentation

### Base URL
```
https://localhost:5001/api
```

### Authentication

All endpoints except authentication endpoints require a valid JWT token in the `Authorization` header:

```http
Authorization: Bearer {your-jwt-token}
```

### Authentication Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/Auth/login` | Authenticate user and receive access & refresh tokens | ❌ |
| `POST` | `/Auth/refresh` | Refresh access token using refresh token | ❌ |
| `POST` | `/Auth/revoke-refresh-token` | Revoke a refresh token | ✅ |

#### Login Request Example

```http
POST /api/Auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePassword123!"
}
```

#### Login Response Example

```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "8f7d6e5c4b3a2d1e...",
  "expiresIn": 3600
}
```

---

### Poll Management Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/Polls` | Retrieve all polls | ✅ |
| `GET` | `/api/Polls/current` | Get currently active polls | ✅ |
| `GET` | `/api/Polls/{id}` | Get specific poll by ID | ✅ |
| `POST` | `/api/Polls` | Create a new poll | ✅ Admin |
| `PUT` | `/api/Polls/{id}` | Update an existing poll | ✅ Admin |
| `DELETE` | `/api/Polls/{id}` | Delete a poll | ✅ Admin |
| `PUT` | `/api/Polls/{id}/togglePublish` | Toggle poll publish status | ✅ Admin |

#### Create Poll Request Example

```http
POST /api/Polls
Authorization: Bearer {token}
Content-Type: application/json

{
  "title": "Customer Satisfaction Survey 2024",
  "summary": "Help us improve our services",
  "startsAt": "2024-01-01T00:00:00Z",
  "endsAt": "2024-12-31T23:59:59Z"
}
```

#### Poll Response Example

```json
{
  "id": 1,
  "title": "Customer Satisfaction Survey 2024",
  "summary": "Help us improve our services",
  "startsAt": "2024-01-01T00:00:00Z",
  "endsAt": "2024-12-31T23:59:59Z",
  "isPublished": false
}
```

---

### Question Management Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/Polls/{pollId}/Questions` | Get all questions for a poll | ✅ |
| `GET` | `/api/Polls/{pollId}/Questions/{id}` | Get specific question by ID | ✅ |
| `POST` | `/api/Polls/{pollId}/Questions` | Add a new question to poll | ✅ Admin |
| `PUT` | `/api/Polls/{pollId}/Questions/{id}` | Update a question | ✅ Admin |
| `DELETE` | `/api/Polls/{pollId}/Questions/{id}` | Delete a question | ✅ Admin |

#### Create Question Request Example

```http
POST /api/Polls/1/Questions
Authorization: Bearer {token}
Content-Type: application/json

{
  "content": "How satisfied are you with our service?",
  "answers": [
    "Very Satisfied",
    "Satisfied",
    "Neutral",
    "Dissatisfied",
    "Very Dissatisfied"
  ]
}
```

---

### Voting Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/polls/{pollId}/votes` | Get available questions for voting | ✅ |
| `POST` | `/api/polls/{pollId}/votes` | Submit vote(s) for a poll | ✅ |

#### Submit Vote Request Example

```http
POST /api/polls/1/votes
Authorization: Bearer {token}
Content-Type: application/json

{
  "answers": [
    {
      "questionId": 1,
      "answerId": 2
    },
    {
      "questionId": 2,
      "answerId": 5
    }
  ]
}
```

---

### Results & Analytics Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/polls/{pollId}/Results/row-data` | Export raw voting data | ✅ Admin |
| `GET` | `/api/polls/{pollId}/Results/votes-per-day` | Get daily voting statistics | ✅ Admin |
| `GET` | `/api/polls/{pollId}/Results/votes-per-question` | Get question-level analytics | ✅ Admin |

#### Votes Per Day Response Example

```json
{
  "pollId": 1,
  "pollTitle": "Customer Satisfaction Survey 2024",
  "votesPerDay": [
    {
      "date": "2024-01-15",
      "numberOfVotes": 45
    },
    {
      "date": "2024-01-16",
      "numberOfVotes": 67
    }
  ]
}
```

#### Votes Per Question Response Example

```json
{
  "pollId": 1,
  "pollTitle": "Customer Satisfaction Survey 2024",
  "questions": [
    {
      "questionId": 1,
      "questionContent": "How satisfied are you with our service?",
      "answers": [
        {
          "answerId": 1,
          "answerContent": "Very Satisfied",
          "voteCount": 120
        },
        {
          "answerId": 2,
          "answerContent": "Satisfied",
          "voteCount": 85
        }
      ]
    }
  ]
}
```

---

## 📁 Project Structure

```
SurveyBasket/
│
├── 📂 SurveyBasket.Api/                          # Presentation Layer
│   ├── 📂 Controllers/                           # API Controllers
│   │   ├── AuthController.cs                     # Authentication endpoints
│   │   ├── PollsController.cs                    # Poll management endpoints
│   │   ├── QuestionsController.cs                # Question management endpoints
│   │   ├── VotesController.cs                    # Voting endpoints
│   │   └── ResultsController.cs                  # Analytics endpoints
│   ├── 📂 Authentication/                        # JWT configuration
│   │   └── JwtOptions.cs                         # JWT settings
│   ├── 📂 DependencyInjection/                   # Service registration
│   │   └── DependencyInjection.cs                # DI container configuration
│   ├── 📂 Extensions/                            # Extension methods
│   ├── 📂 Middleware/                            # Custom middleware
│   ├── appsettings.json                          # Configuration
│   ├── appsettings.Development.json              # Development config
│   └── Program.cs                                # Application entry point
│
├── 📂 SurveyBasket.Application/                  # Application Layer
│   ├── 📂 Services/                              # Business logic services
│   │   ├── AuthService.cs                        # Authentication service
│   │   ├── PollService.cs                        # Poll management service
│   │   ├── QuestionService.cs                    # Question management service
│   │   ├── VoteService.cs                        # Voting service
│   │   ├── ResultService.cs                      # Analytics service
│   │   └── CacheService.cs                       # Distributed cache service
│   ├── 📂 Mapping/                               # Object mapping
│   │   └── MappingConfiguration.cs               # Mapster configuration
│   └── 📂 Validations/                           # Request validators
│       ├── PollValidators.cs                     # Poll validation rules
│       ├── QuestionValidators.cs                 # Question validation rules
│       └── VoteValidators.cs                     # Vote validation rules
│
├── 📂 SurveyBasket.Application.Abstractions/     # Abstractions Layer
│   ├── 📂 Services/                              # Service interfaces
│   │   ├── IAuthService.cs
│   │   ├── IPollService.cs
│   │   ├── IQuestionService.cs
│   │   ├── IVoteService.cs
│   │   └── IResultService.cs
│   ├── 📂 Repositories/                          # Repository interfaces
│   │   └── 📂 Cache/
│   │       └── ICacheService.cs                  # Cache service interface
│   ├── 📂 DTOs/                                  # Data Transfer Objects
│   │   ├── 📂 Requests/                          # Request models
│   │   └── 📂 Responses/                         # Response models
│   ├── 📂 Results/                               # Result types (OneOf)
│   └── 📂 Constants/                             # Application constants
│
├── 📂 SurveyBasket.Domain/                       # Domain Layer
│   ├── 📂 Entities/                              # Domain entities
│   │   ├── Poll.cs                               # Poll aggregate root
│   │   ├── Question.cs                           # Question entity
│   │   ├── Answer.cs                             # Answer entity
│   │   ├── Vote.cs                               # Vote aggregate root
│   │   ├── VoteAnswer.cs                         # Vote-Answer relationship
│   │   ├── ApplicationUser.cs                    # User entity
│   │   └── RefreshToken.cs                       # Refresh token entity
│   ├── 📂 Enums/                                 # Domain enumerations
│   └── 📂 Common/                                # Shared domain logic
│
└── 📂 SurveyBasket.Infrastructure/               # Infrastructure Layer
    ├── 📂 Persistence/
    │   ├── AppDbContext.cs                       # EF Core DbContext
    │   ├── 📂 Migrations/                        # Database migrations
    │   └── 📂 Configurations/                    # Entity configurations
    │       ├── PollConfiguration.cs
    │       ├── QuestionConfiguration.cs
    │       ├── AnswerConfiguration.cs
    │       ├── VoteConfiguration.cs
    │       ├── VoteAnswerConfiguration.cs
    │       ├── ApplicationUserConfiguration.cs
    │       └── RefreshTokenConfiguration.cs
    ├── 📂 Services/                              # Infrastructure services
    └── 📂 DependencyInjection/                   # Infrastructure DI
```

---

## 🔍 Key Features Deep Dive

### 1. Clean Architecture Implementation

The project strictly follows Clean Architecture with these principles:

- **Dependency Rule**: Dependencies point inward; inner layers know nothing about outer layers
- **Abstractions**: All dependencies are injected through interfaces
- **Domain Independence**: Domain layer has no external dependencies
- **Testability**: Each layer can be tested in isolation

### 2. Performance & Caching

#### HybridCache Implementation

SurveyBasket uses Microsoft's `HybridCache` for optimal performance:

```csharp
public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);
        return cachedValue is null 
            ? null 
            : JsonSerializer.Deserialize<T>(cachedValue);
    }
    
    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
    {
        await _distributedCache.SetStringAsync(
            key, 
            JsonSerializer.Serialize(value), 
            cancellationToken
        );
    }
}
```

**Benefits:**
- ⚡ L1 (in-memory) and L2 (distributed) caching
- 🔄 Automatic cache invalidation
- 📊 Reduced database load
- 🚀 Improved response times

**Use Cases:**
- Poll data caching for faster retrieval
- User session management
- Frequently accessed analytics data

### 3. Railway-Oriented Programming with OneOf

The API uses discriminated unions for explicit error handling:

```csharp
public async Task<OneOf<PollResponse, NotFound, ValidationError>> GetPollAsync(int id)
{
    var poll = await _pollRepository.GetByIdAsync(id);
    
    if (poll is null)
        return new NotFound();
    
    return poll.Adapt<PollResponse>();
}
```

**Benefits:**
- ✅ Type-safe error handling
- 🎯 Explicit success/failure paths
- 📝 Self-documenting API responses
- 🛡️ Compile-time error checking

### 4. FluentValidation Integration

Comprehensive validation rules for all requests:

```csharp
public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
{
    public CreatePollRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);
            
        RuleFor(x => x.StartsAt)
            .GreaterThan(DateTime.UtcNow);
            
        RuleFor(x => x.EndsAt)
            .GreaterThan(x => x.StartsAt);
    }
}
```

### 5. JWT Authentication with Refresh Tokens

Secure authentication flow:

1. User logs in with credentials
2. API returns access token (short-lived) + refresh token (long-lived)
3. Access token used for API requests
4. When access token expires, use refresh token to get new access token
5. Refresh tokens can be revoked for security

---

## 🔒 Security

### Authentication & Authorization

- ✅ JWT Bearer token authentication
- ✅ Refresh token rotation
- ✅ Token revocation support
- ✅ Role-based authorization ready
- ✅ HTTPS enforcement in production

### Data Protection

- ✅ Password hashing (ASP.NET Core Identity)
- ✅ SQL injection prevention (parameterized queries)
- ✅ Input validation on all endpoints
- ✅ CORS configuration
- ✅ Rate limiting ready

### Best Practices

- Never store sensitive data in JWT payload
- Use User Secrets for development
- Use Azure Key Vault or similar for production
- Implement API versioning
- Monitor and log security events

---

## 👨‍💻 Development

### Running Tests

```bash
dotnet test
```

### Database Migrations

**Create a new migration:**
```bash
dotnet ef migrations add MigrationName --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
```

**Update database:**
```bash
dotnet ef database update --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
```

**Remove last migration:**
```bash
dotnet ef migrations remove --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
```

### Code Quality

- Follow SOLID principles
- Use meaningful names
- Keep methods small and focused
- Use async/await consistently

### Development Tools

- **Visual Studio 2026** - Full IDE with debugging
- **Visual Studio Code** - Lightweight editor with C# extension
- **Azure Data Studio** - Database management
- **Postman** - API testing
- **Git** - Version control

---

## 🤝 Contributing

Contributions are welcome! We appreciate your interest in improving SurveyBasket.

### How to Contribute

1. **Fork the repository**
   ```bash
   git clone https://github.com/muhammadabdelgawad/SurveyBasket.git
   ```

2. **Create a feature branch**
   ```bash
   git checkout -b feature/AmazingFeature
   ```

3. **Make your changes**
   - Follow the existing code style
   - Add tests for new functionality
   - Update documentation as needed

4. **Commit your changes**
   ```bash
   git commit -m 'Add some AmazingFeature'
   ```

5. **Push to the branch**
   ```bash
   git push origin feature/AmazingFeature
   ```

6. **Open a Pull Request**
   - Describe your changes
   - Reference any related issues
   - Wait for code review

### Contribution Guidelines

- ✅ Follow Clean Architecture principles
- ✅ Write unit tests for new features
- ✅ Update API documentation (Swagger)
- ✅ Follow C# coding conventions
- ✅ Use meaningful commit messages
- ✅ Keep PRs focused and small

---

## 👤 Author

**Muhammad Abdelgawad**

- 💼 GitHub: [@muhammadabdelgawad](https://github.com/muhammadabdelgawad)

---

## 📊 Project Statistics

![GitHub repo size](https://img.shields.io/github/repo-size/muhammadabdelgawad/SurveyBasket?style=flat-square)
![GitHub language count](https://img.shields.io/github/languages/count/muhammadabdelgawad/SurveyBasket?style=flat-square)
![GitHub top language](https://img.shields.io/github/languages/top/muhammadabdelgawad/SurveyBasket?style=flat-square)

---

## ⭐ Show Your Support

If you find this project helpful, please consider:

- ⭐ **Starring the repository**
- 🍴 **Forking the project**
- 📢 **Sharing with others**
- 💬 **Providing feedback**

---

<div align="center">

**Built with ❤️ using ASP.NET Core 9**

[⬆ Back to Top](#-surveybasket-api)

</div>

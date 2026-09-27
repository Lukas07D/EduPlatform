# EduPlatform (SmartCertify API)

A REST API for an e-learning and certification platform. It lets you manage **courses**, **exam questions** and their **answer choices**, which form the basis for online certification exams.

Built as a learning project to practise a layered .NET backend with ASP.NET Core, Entity Framework Core and SQL Server, deployed with Azure SQL and Azure DevOps.

> The solution and its projects are named `SmartCertify.*`. EduPlatform is the repository name.

## Tech stack

| Area | Technologies |
|---|---|
| Backend | C#, .NET 9, ASP.NET Core Web API |
| Data access | Entity Framework Core 9, SQL Server / Azure SQL |
| Validation | FluentValidation with a custom global action filter |
| Mapping | AutoMapper |
| API docs | OpenAPI, Scalar, Swagger UI |
| DevOps | Git, Azure DevOps (CI/CD), Azure SQL |

## Architecture

The solution is split into four projects with dependencies pointing inwards:

```
SmartCertify.API             → controllers, validation filter, DI configuration
SmartCertify.Application     → services, DTOs, validators, mapping profile, interfaces
SmartCertify.Domain          → entities (Course, Question, Choice, Exam, UserProfile, ...)
SmartCertify.Infrastructure  → EF Core DbContext and repository implementations
```

- **Controllers** stay thin and delegate to application services.
- **Services** hold the business logic and depend only on repository interfaces defined in the Application layer.
- **Repositories** in Infrastructure implement these interfaces using EF Core.
- **Validation** runs in one place: a global `ValidationFilter` resolves the matching `IValidator<T>` for every action argument and returns `400 Bad Request` with a list of errors.

## API endpoints

| Resource | Endpoints |
|---|---|
| Courses | `GET /api/courses`, `GET /api/courses/{id}`, `POST`, `PUT /{id}`, `PATCH /{id}` (description), `DELETE /{id}` |
| Questions | `GET /api/questions`, `GET /api/questions/{id}`, `POST`, `PUT /{id}`, `DELETE /{id}`, `POST /api/questions/CreateQuestionChoices` |
| Choices | `GET /api/choices/{questionId}`, `GET /api/choices/{questionId}/{id}`, `POST`, `PUT /{id}`, `PATCH /{id}`, `DELETE /{id}` |

In the Development environment, interactive API documentation is available through Scalar and Swagger UI.

## Running locally

**Requirements:** .NET 9 SDK, a SQL Server instance (local SQL Server, LocalDB or Azure SQL).

1. Clone the repository:
   ```bash
   git clone https://github.com/Lukas07D/EduPlatform.git
   cd EduPlatform
   ```
2. Set the connection string (kept out of source control with user secrets):
   ```bash
   cd SmartCertify.API
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DbContext" "Server=...;Database=SmartCertify;..."
   ```
3. Run the API:
   ```bash
   dotnet run
   ```
4. Open the API documentation at the URL shown in the console.

## Roadmap

- [ ] Unit tests for application services (xUnit + Moq)
- [ ] Integration tests for the API (`WebApplicationFactory`)
- [ ] Authentication and authorization (JWT)
- [ ] Exam flow endpoints (taking an exam, scoring results)
- [ ] Docker Compose setup (API + SQL Server)

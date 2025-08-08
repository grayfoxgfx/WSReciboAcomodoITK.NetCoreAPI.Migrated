# Migration Process: WCF to .NET 8 Web API with Clean Architecture & CQRS

## Overview
This document describes the migration of the legacy WCF service (WSReciboAcomodoITK) to a modern .NET 8 Web API, following Clean Architecture and CQRS principles. It also covers the integration of MCP GitHub tools and useful command prompts for development and automation.

---

## 1. Migration Steps

### 1.1. Project Setup
- Created a new .NET 8 solution and projects for API, Application, Domain, Infrastructure, Persistence, and Shared layers.
- Used Clean Architecture folder structure for separation of concerns.
- Added references between projects as needed.

### 1.2. Model & Logic Migration
- Migrated all domain models (e.g., HuEnvio, HuRespuesta, OtMalEstadoEnvio, etc.) from WCF to Domain layer.
- Migrated business logic from legacy service to Application layer.
- Refactored service methods to follow CQRS (Command/Query Responsibility Segregation).
- Ensured all logic is testable and separated from infrastructure concerns.

### 1.3. API Layer
- Created controllers for main endpoints (e.g., SAP_ITK_REF_ObtieneDatosHu, SAP_ITK_REF_GeneraOtEnMalEstado).
- Used dependency injection for service classes.
- Configured Swagger (OpenAPI) for API documentation, only enabled in development.

### 1.4. Logging
- Migrated legacy logging logic (`FileLogOperaciones`) to Infrastructure layer.
- Refactored `InsertarLogOperaciones` to include caller method name and delegate file logging.
- Ensured logging matches legacy behavior and is maintainable.

### 1.5. Testing
- Set up NUnit and Moq for unit and functional tests.
- Created and validated tests for all main endpoints and business logic.

### 1.6. Cleanup
- Removed unused endpoints, placeholder methods, and TODO comments.
- Ensured codebase is clean and maintainable.

---

## 2. MCP GitHub Tool Configuration

### 2.1. What is MCP GitHub?
MCP (Model Context Protocol) GitHub tools enable automated code reviews, issue management, and workflow automation directly from VS Code.

### 2.2. Configuration Steps
1. **Install MCP GitHub Extension**
   - Search for "MCP GitHub" in VS Code Extensions Marketplace and install.
2. **Authenticate**
   - Connect your GitHub account via the extension's settings.
3. **Repository Setup**
   - Ensure your project is initialized as a Git repository (`git init`).
   - Add remote origin if needed (`git remote add origin <repo-url>`).
4. **Enable MCP Features**
   - Use the command palette (`Ctrl+Shift+P`) and search for MCP commands (e.g., `MCP: Assign Copilot to Issue`, `MCP: Create Pull Request`).
   - Configure workflow automation and code review settings as desired.

### 2.3. Useful MCP GitHub Commands
- `MCP: Assign Copilot to Issue` — Delegate tasks to Copilot agent.
- `MCP: Create Pull Request` — Automate PR creation.
- `MCP: Request Copilot Review` — Get automated code review feedback.
- `MCP: List Notifications` — View pending reviews, issues, and PRs.

---

## 3. Command Prompts for Development

### 3.1. Build & Test
- **Build Solution:**
  ```pwsh
  dotnet build --no-incremental
  ```
- **Run Tests:**
  ```pwsh
  dotnet test
  ```

### 3.2. Run API Locally
- **Start API:**
  ```pwsh
  dotnet run --project src/WSReciboAcomodoITK.NetCoreAPI.API
  ```
- **Open Swagger UI:**
  Visit `http://localhost:5021` or the URL specified in `launchSettings.json`.

### 3.3. GitHub Integration
- **Commit Changes:**
  ```pwsh
  git add .
  git commit -m "Migrate WCF to .NET 8 Web API"
  git push
  ```
- **Create Branch:**
  ```pwsh
  git checkout -b feature/your-feature
  ```

---

## 4. Best Practices
- Keep business logic in Application layer, models in Domain, and infrastructure concerns (logging, persistence) in Infrastructure/Persistence layers.
- Use dependency injection for all services.
- Enable Swagger only in development for security.
- Remove unused code and comments for maintainability.
- Use MCP GitHub tools for efficient code review and workflow automation.

---

## 5. References
- [Legacy WCF Repo](https://github.com/grayfoxgfx/WSReciboAcomodoITK)
- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/core/dotnet-eight)
- [Clean Architecture Guide](https://github.com/jasontaylordev/CleanArchitecture)
- [MCP GitHub Extension](https://marketplace.visualstudio.com/items?itemName=GitHub.vscode-mcp)

---

For further questions or improvements, contact your project maintainer or refer to the above resources.

---

## 6. Latest Migration Steps

### 6.1. Create and Push to New Remote Repository
- Created a new public GitHub repository: [WSReciboAcomodoITK.NetCoreAPI.Migrated](https://github.com/grayfoxgfx/WSReciboAcomodoITK.NetCoreAPI.Migrated)
- Initialized local git repository (`git init`)
- Added remote origin:
  ```pwsh
  git remote add origin https://github.com/grayfoxgfx/WSReciboAcomodoITK.NetCoreAPI.Migrated.git
  ```
- Committed all migration changes:
  ```pwsh
  git add .
  git commit -m "Initial migration: WCF to .NET 8 Web API, Clean Architecture, CQRS, documentation."
  ```
- Pushed to remote:
  ```pwsh
  git push -u origin master
  ```

All migration history and documentation are now available in the new repository for collaboration and review.

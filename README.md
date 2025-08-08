# WSReciboAcomodoITK.NetCoreAPI

This repository is a migration of the original WCF service to a .NET 8 Web API using Clean Architecture and CQRS.

## Solution Structure
- **API**: Presentation layer (controllers, endpoints)
- **Application**: CQRS (commands, queries, handlers, DTOs)
- **Domain**: Entities, value objects, interfaces
- **Infrastructure**: External services, integrations
- **Persistence**: Data access, EF Core context
- **Shared**: Common utilities, exceptions

## Getting Started
1. Build the solution:
   ```sh
   dotnet build
   ```
2. Run the API:
   ```sh
   dotnet run --project src/WSReciboAcomodoITK.NetCoreAPI.API
   ```

## Next Steps
- Migrate business logic, models, and data access from the original WCF project.
- Implement CQRS patterns in the Application layer.
- Add API endpoints in the API layer.

---
For workspace-specific Copilot instructions, see `.github/copilot-instructions.md`.

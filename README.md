# Flex Fresh Studio - WebAPIServices

The web API service that is used for management at Flex Fresh Studio store on the client admin website build in JavaScript.

# DESIGN PATTERN
You can see the differences between not using repositories (directly using the EF DbContext) versus using repositories, which makes it easier to mock those repositories.
![You can see the differences between not using repositories (directly using the EF DbContext) versus using repositories, which makes it easier to mock those repositories.](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/infrastructure-persistence-layer-implementation-entity-framework-core/custom-repo-versus-db-context.png)
-----

# DEVELOP ENVIRONMENT
1. Visual Studio 2022
2. [.NET 6.0](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6) or later
3. [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
3. PostgreSql

### BASE USAGE
-----

### Dependencies

| NuGet Packages | License |
| --- | --- |
| EntityFrameworkCore.InMemory | MIT |
| Swashbuckle.AspNetCore | MIT |
| Npgsql | PostgreSQL License |
| Npgsql.EntityFrameworkCore.PostgreSQL | PostgreSQL License |
| System.IdentityModel.Tokens.Jwt | MIT |
| AspDotNetCore.Authentication.JWTwtBearer | MIT |
| AspDotNetCore.MVC.NewtonSoftJson | MIT |
| EntityFrameworkCore.Tools | MIT |
| NewtonSoft.Json | MIT |
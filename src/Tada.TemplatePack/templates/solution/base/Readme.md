# TadaSourceName

## Prerequisites

- [Visual Studio Code](https://code.visualstudio.com/download) Or [Visual Studio](https://visualstudio.microsoft.com/)
- [Docker](https://www.docker.com/get-started/)

## Solution Architecture

This solution is built on Clean/Onion Architecture principles.

It uses certain terminology to achieve this architecture.

1. Domain layer contains the models, enumerations and interfaces
   for the solution services.

2. Infrastructure layer (Can be one or many projects)
   Each Project implements a single responsibility task such as
   Email tasks, Database Context, Calls to external api' etc.

3. Services layer contains the implementation of the interfaces defined in the Domain.

4. Presentation layer (Can be one or many projects)
   contains the UI interface to the solution. This can be anything like a
   Website, Console App, Windows App or simply an Api Service.

## References

### Solution Resources

- [Database](/src/2.Infrastructure/Database/TadaSourceName.Infrastructure.Database/Readme.md)

### Additional Resources

- [Tada](https://github.com/niallduane/)
- [Set up https for docker](https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md)
- [Localization](https://github.com/AlexTeixeira/Askmethat-Aspnet-JsonLocalizer)
- [EFBundles](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#bundles)

dotnet new classlib -n "$SOLUTION_NAME.Infrastructure.$INFRA_NAME" -o "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME";
dotnet new xunit -n "$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests" -o "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests";

dotnet add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.csproj" package Microsoft.Extensions.DependencyInjection.Abstractions;
dotnet add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.csproj" package Microsoft.Extensions.Configuration.Abstractions;

dotnet add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests.csproj" reference "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.csproj";
dotnet add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests.csproj" package Bogus;
dotnet add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests.csproj" package Moq;

dotnet add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj" reference "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.csproj";

dotnet sln add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.csproj";
dotnet sln add "./src/2.Infrastructure/$INFRA_NAME/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests/$SOLUTION_NAME.Infrastructure.$INFRA_NAME.Tests.csproj";

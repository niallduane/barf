dotnet new $type -n "$SOLUTION_NAME.Presentation.$PresentationName" -o "./src/4.Presentation/$SOLUTION_NAME.Presentation.PresentationName" --force;

dotnet user-secrets init -p "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" --id "$SOLUTION_NAME-local-settings";

dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Services/$SOLUTION_NAME.Domain.Services.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj" reference "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj";

dotnet sln add "./src/4.Presentation/$SOLUTION_NAME.Presentation.$PresentationName/$SOLUTION_NAME.Presentation.$PresentationName.csproj";
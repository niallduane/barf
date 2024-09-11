dotnet new install Tada.TemplatePack;
dotnet new editorconfig;
dotnet new gitignore;
dotnet new tool-manifest;
dotnet new globaljson --roll-forward feature;

dotnet tool install swashbuckle.aspnetcore.cli;
dotnet tool install dotnet-ef;
dotnet tool install dotnet-format;
dotnet tool install Tada;

dotnet new sln -n "$SOLUTION_NAME";

dotnet new classlib -n "$SOLUTION_NAME.Domain.Core" -o "./src/1.Domain/$SOLUTION_NAME.Domain.Core";
dotnet sln add "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";

dotnet new classlib -n "$SOLUTION_NAME.Domain.Services" -o "./src/1.Domain/$SOLUTION_NAME.Domain.Services";
dotnet add "./src/1.Domain/$SOLUTION_NAME.Domain.Services/$SOLUTION_NAME.Domain.Services.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";
dotnet sln add "./src/1.Domain/$SOLUTION_NAME.Domain.Services/$SOLUTION_NAME.Domain.Services.csproj";

dotnet new classlib -n "$SOLUTION_NAME.Infrastructure.Database" -o "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database";
dotnet new classlib -n "$SOLUTION_NAME.Infrastructure.Database.Repositories" -o "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories";
dotnet new xunit -n "$SOLUTION_NAME.Infrastructure.Database.Tests" -o "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests";

dotnet user-secrets init -p "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" --id "$SOLUTION_NAME-local-settings";

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Microsoft.EntityFrameworkCore;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Microsoft.EntityFrameworkCore.Design;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Microsoft.Extensions.Configuration.EnvironmentVariables;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Microsoft.Extensions.Configuration.UserSecrets;

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj";
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj" package Microsoft.EntityFrameworkCore.InMemory;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj" package Bogus;

dotnet sln add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet sln add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj";
dotnet sln add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj";

dotnet new classlib -n "$SOLUTION_NAME.Services" -o "./src/3.Services/$SOLUTION_NAME.Services";
dotnet new xunit -n "$SOLUTION_NAME.Services.Tests" -o "./src/3.Services/$SOLUTION_NAME.Services.Tests";

dotnet add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";
dotnet add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Services/$SOLUTION_NAME.Domain.Services.csproj";
dotnet add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj";


dotnet add "./src/3.Services/$SOLUTION_NAME.Services.Tests/$SOLUTION_NAME.Services.Tests.csproj" reference "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj";
dotnet add "./src/3.Services/$SOLUTION_NAME.Services.Tests/$SOLUTION_NAME.Services.Tests.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Tests/$SOLUTION_NAME.Infrastructure.Database.Tests.csproj";
dotnet add "./src/3.Services/$SOLUTION_NAME.Services.Tests/$SOLUTION_NAME.Services.Tests.csproj" package Moq;
dotnet add "./src/3.Services/$SOLUTION_NAME.Services.Tests/$SOLUTION_NAME.Services.Tests.csproj" package Bogus;

dotnet sln add "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj";
dotnet sln add "./src/3.Services/$SOLUTION_NAME.Services.Tests/$SOLUTION_NAME.Services.Tests.csproj";

dotnet new webapi -n "$SOLUTION_NAME.Presentation.Api" -o "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api" --use-controllers true;

dotnet user-secrets init -p "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" --id "$SOLUTION_NAME-local-settings";

dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Core/$SOLUTION_NAME.Domain.Core.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" reference "./src/1.Domain/$SOLUTION_NAME.Domain.Services/$SOLUTION_NAME.Domain.Services.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" reference "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database.Repositories/$SOLUTION_NAME.Infrastructure.Database.Repositories.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" reference "./src/3.Services/$SOLUTION_NAME.Services/$SOLUTION_NAME.Services.csproj";
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" package Microsoft.AspNetCore.Mvc.Versioning;
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer;
dotnet add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj" package Swashbuckle.AspNetCore.Annotations;

dotnet sln add "./src/4.Presentation/$SOLUTION_NAME.Presentation.Api/$SOLUTION_NAME.Presentation.Api.csproj";

dotnet new tada-sln -n $SOLUTION_NAME -o ./;

dotnet restore;
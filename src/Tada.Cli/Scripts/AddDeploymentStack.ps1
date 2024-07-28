dotnet new install Tada.TemplatePack;
dotnet new console -n "$SOLUTION_NAME.Infrastructure.DeploymentStack" -o "./src/2.Infrastructure/DeploymentStack/$SOLUTION_NAME.Infrastructure.DeploymentStack";

dotnet add "./src/2.Infrastructure/DeploymentStack/$SOLUTION_NAME.Infrastructure.DeploymentStack/$SOLUTION_NAME.Infrastructure.DeploymentStack.csproj" package Pulumi;

dotnet sln add "./src/2.Infrastructure/DeploymentStack/$SOLUTION_NAME.Infrastructure.DeploymentStack/$SOLUTION_NAME.Infrastructure.DeploymentStack.csproj";
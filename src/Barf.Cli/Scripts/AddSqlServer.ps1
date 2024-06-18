dotnet new barf-database-sqlserver -n $SOLUTION_NAME -o ./;

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Microsoft.EntityFrameworkCore.SqlServer;

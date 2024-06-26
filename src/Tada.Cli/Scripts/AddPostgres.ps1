dotnet new tada-database-postgres -n $SOLUTION_NAME -o ./;

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Npgsql.EntityFrameworkCore.PostgreSQL;


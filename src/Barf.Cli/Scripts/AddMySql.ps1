dotnet new barf-database-mysql -n $SOLUTION_NAME -o ./;

dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Pomelo.EntityFrameworkCore.MySql;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Pomelo.EntityFrameworkCore.MySql.NetTopologySuite;
dotnet add "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj" package Pomelo.EntityFrameworkCore.MySql.Json.Microsoft;

dotnet user-secrets set "ConnectionStrings:DatabaseVersion" "8.0.23-mysql" -p "./src/2.Infrastructure/Database/$SOLUTION_NAME.Infrastructure.Database/$SOLUTION_NAME.Infrastructure.Database.csproj";


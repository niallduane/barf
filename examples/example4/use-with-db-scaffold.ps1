#
# This example sets up a tada solution and adds the following services
# organisation, user, product, customer and order.
# 
# NOTE The entities, domain requests and responses don't have any properties
#
# To use copy this script into an empty folder and execute.

tada new Example4
cd ./src/2.Infrastructure/Example4.Infrastructure.database

# EF Core Scaffolding 
# https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

dotnet ef dbcontext scaffold "Server=localhost,1433;Database=Example4;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer

cd ../../../
tada add service Organisation --type excludeentity
tada add service User --type excludeentity
tada add service Product --type excludeentity
tada add service Customer --type excludeentity
tada add service Order --type excludeentity

# add a db migration called Initial
tada db add Initial

# Apply migration to database
tada db update

# start the app
tada app serve

# Next Steps
# Add properties to the database properties
# Add properties to the domain service models
# Update the mappings between the models and entities in the DbMappings classes.
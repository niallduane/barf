# Database Infrastructure

## Start the database

In the solution directory, start the database by

`docker compose up -d`

## Add Migration

In vscode, run task `Add Database Migration`.

Enter a descriptive name for the migration.

Alternatively, In the database project directory, run the following command with a new migration name

`dotnet ef migrations add {name of migration}`

## Update Local Dev Database

In vscode, run task `Update Database`

Alternatively, In the database project directory, run the command

`dotnet ef database update`

## Script Migrations

In the database project directory, run the command

`dotnet ef migrations script --output "{file location Path}"`

## Executing SQL Scripts on the local database

To execute sql directly on the mysql docker container, run the following command

`docker compose exec tadasourcename-db sqlcmd`

Write SQL scripts in the folder `./src/2.Infrastructure/Database/Scripts/Dev`
and execute them using the command `source {filename}.sql`

## References

* [Dotnet Entity Framework Core CLI reference](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#common-options)
* [Using connection strings with dotnet ef](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings#aspnet-core)

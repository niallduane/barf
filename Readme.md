# Tada

A CLI that creates a dotnet solution built on clean architecture.
Under the hood, it uses dotnet templates to create the solution.

Every Tada solution contains

* Database setup (Sql Server[Default], Mysql Or Postgres)
* Api project with swagger configuration

## Prerequisites

* >= DOTNET 8
* VS Code
* Docker

## Quick Start

* Install the CLI

    `dotnet tool install Tada --global`
* Install the templates

    `tada install`
* Create a new tada solution 

    `tada new ${solutionName} --dbtype sqlserver|mysql|postgres`
    
    * Run this command in an empty directory

    * Sql Server is the default option

## CLI Command Reference 

### Add commands

#### `tada add service`

#### `tada add repository`

#### `tada add entity`

#### `tada add infrastructure`

### Database commands

#### `tada db add`

#### `tada db update`

#### `tada db remove`

#### `tada db revert`

#### `tada db shell`

## References

* [Authenticating to github packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages)
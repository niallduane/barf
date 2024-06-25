# Barf

A CLI that creates a dotnet solution built on clean architecture.
Under the hood, it uses dotnet templates to create the solution.

Every Barf solution contains

* Database setup (Sql Server[Default], Mysql Or Postgres)
* Api project with swagger configuration

## Prerequisites

* >= DOTNET 8
* VS Code
* Docker

## Quick Start

* Install the CLI

    `dotnet tool install Barf --global`
* Install the templates

    `barf install`
* Create a new barf solution 

    `barf new ${solutionName} --dbtype sqlserver|mysql|postgres`
    
    * Run this command in an empty directory

    * Sql Server is the default option

## CLI Command Reference 

### Add commands

#### `barf add service`

#### `barf add repository`

#### `barf add entity`

#### `barf add infrastructure`

### Database commands

#### `barf db add`

#### `barf db update`

#### `barf db remove`

#### `barf db revert`

#### `barf db shell`

## References

* [Authenticating to github packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages)

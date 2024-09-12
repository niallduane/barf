# Architecture

## Application

TODO

## Hosting

TODO

## Solution

This solution is built on Clean/Onion Architecture principles.

It uses certain terminology to achieve this architecture.

1. Domain layer contains the models, enumerations and interfaces
   for the solution services.

2. Infrastructure layer (Can be one or many projects)
   Each Project implements a single responsibility task such as
   Email tasks, Database Context, Calls to external api' etc.

3. Services layer contains the implementation of the interfaces defined in the Domain.

4. Presentation layer (Can be one or many projects)
   contains the UI interface to the solution. This can be anything like a
   Website, Console App, Windows App or simply an Api Service.
#!/bin/bash

version=1.0.0-alpha

dotnet pack;
dotnet tool uninstall Tada --global;
dotnet tool install Tada --global

dotnet new uninstall Tada.TemplatePack
dotnet new install Tada.TemplatePack --force

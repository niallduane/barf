#!/bin/bash

dotnet nuget remove source "tada_project"
dotnet nuget add source --name "tada_project" "C:\Users\n_dua\source\Tada\output"

dotnet pack
dotnet tool uninstall Tada --global
dotnet tool install Tada --global

dotnet new uninstall Tada.TemplatePack
dotnet new install ./output/Tada.TemplatePack.1.0.0.nupkg --force

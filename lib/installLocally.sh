#!/bin/bash
dotnet pack
dotnet tool uninstall Barf --global
dotnet tool install Barf --global

dotnet new uninstall Barf.TemplatePack
dotnet new install ./output/Barf.TemplatePack.1.0.0.nupkg --force

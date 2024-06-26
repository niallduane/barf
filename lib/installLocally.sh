#!/bin/bash

dotnet pack
dotnet tool uninstall Tada --global
dotnet tool install Tada --global

dotnet new uninstall Tada.TemplatePack
dotnet new install ./output/Tada.TemplatePack.1.0.0.nupkg --force

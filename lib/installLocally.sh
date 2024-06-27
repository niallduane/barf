#!/bin/bash

version=1.0.0

dotnet pack /p:PackageVersion="$version"
dotnet tool uninstall Tada --global
dotnet tool install Tada --global

dotnet new uninstall Tada.TemplatePack
dotnet new install "./output/Tada.TemplatePack.$version.nupkg" --force

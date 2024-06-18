#!/bin/bash

set -e

echo "adding custom commands to bashrc"
cat ./.devcontainer/.bashrc >>~/.bashrc

dotnet tool restore

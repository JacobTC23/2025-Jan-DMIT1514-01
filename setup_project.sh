#!/bin/bash

# Check if a parameter is provided
if [ -z "$1" ]; then
  echo "Usage: $0 <project-name>"
  exit 1
fi

# Store the parameter
PROJECT_NAME=$1

# Run the specified commands
dotnet new mgdesktopgl -n "$PROJECT_NAME" -o "./$PROJECT_NAME"
dotnet sln DMIT1514-private.sln add "./$PROJECT_NAME/$PROJECT_NAME.csproj"


# Add the package


# Output instructions for manual steps
echo "
OPERATIONS COMPLETE, NOW DO THE FOLLOWING:
change directory into the new project
dotnet add package Contentless --version 4.0.0
Open .csproj and paste the following inside the relevant <ItemGroup>:
<ItemGroup>
    <MonoGameContentReference Include=\"Content\\Content.mgcb\" />
</ItemGroup>"

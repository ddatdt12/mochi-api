# Use the official .NET SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /src

# Install a shell (bash) and other utilities for interactive access
RUN apt-get update && apt-get install -y bash

# Copy your ASP.NET Core project files to the container
COPY ../MochiApi.csproj .
RUN dotnet restore MochiApi.csproj
RUN dotnet tool install --global dotnet-ef --version 6.*
ENV PATH="${PATH}:/root/.dotnet/tools"
# Copy the rest of your project files to the container
COPY ../ .
WORKDIR /src
# RUN dotnet ef database update

CMD [ "dotnet", "run" ]

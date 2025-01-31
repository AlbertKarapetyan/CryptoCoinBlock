# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy entire solution and restore
COPY . . 
RUN dotnet restore CryptoCoinBlock.sln

# Install EF Tools for Migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Run tests before proceeding
RUN dotnet test CM.Domain.Tests/CM.Domain.Tests.csproj --configuration Release --no-restore
RUN dotnet test CM.API.Tests/CM.API.Tests.csproj --configuration Release --no-restore

# Build the solution in Release mode
RUN dotnet build CryptoCoinBlock.sln -c Release -o /app/build

# Publish the project
RUN dotnet publish CryptoCoinBlock.sln -c Release -o /app/out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "CryptoCoinBlock.dll"]
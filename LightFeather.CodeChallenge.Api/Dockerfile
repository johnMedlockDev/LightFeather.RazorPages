# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files separately to utilize Docker cache
COPY ["LightFeather.CodeChallenge.Domain/LightFeather.CodeChallenge.Domain.csproj", "LightFeather.CodeChallenge.Domain/"]
COPY ["LightFeather.CodeChallenge.Infrastructure/LightFeather.CodeChallenge.Infrastructure.csproj", "LightFeather.CodeChallenge.Infrastructure/"]
COPY ["LightFeather.CodeChallenge.Api/LightFeather.CodeChallenge.Api.csproj", "LightFeather.CodeChallenge.Api/"]

# Restore as distinct layers
RUN dotnet restore "LightFeather.CodeChallenge.Api/LightFeather.CodeChallenge.Api.csproj" --runtime linux-x64

# Copy everything else and build
COPY . .
WORKDIR "/src/LightFeather.CodeChallenge.Api"
RUN dotnet publish "LightFeather.CodeChallenge.Api.csproj" -c Release -o /app/publish --no-restore --runtime linux-x64 -p:PublishReadyToRun=true

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set a non-root user for security purposes
USER app

# Healthcheck (optional)
HEALTHCHECK --interval=30s --timeout=3s --retries=3 CMD curl --fail http://localhost/health || exit 1

# Define the entry point which starts the application
ENTRYPOINT ["dotnet", "LightFeather.CodeChallenge.Api.dll"]
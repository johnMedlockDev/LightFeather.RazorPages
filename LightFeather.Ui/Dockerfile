# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files separately to utilize Docker cache
COPY ["LightFeather.Domain/LightFeather.Domain.csproj", "LightFeather.Domain/"]
COPY ["LightFeather.Ui/LightFeather.Ui.csproj", "LightFeather.Ui/"]

# Restore as distinct layers
RUN dotnet restore "LightFeather.Ui/LightFeather.Ui.csproj" --runtime linux-x64

# Copy everything else and build
COPY . .
WORKDIR "/src/LightFeather.Ui"
RUN dotnet publish "LightFeather.Ui.csproj" -c Release -o /app/publish --no-restore --runtime linux-x64 -p:PublishReadyToRun=true

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set a non-root user for security purposes
USER app

# Healthcheck (optional)
HEALTHCHECK --interval=30s --timeout=3s --retries=3 CMD curl --fail http://localhost/health || exit 1

# Define the entry point which starts the application
ENTRYPOINT ["dotnet", "LightFeather.Ui.dll"]
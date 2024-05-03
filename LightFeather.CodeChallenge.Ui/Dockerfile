FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LightFeather.CodeChallenge.Domain/LightFeather.CodeChallenge.Domain.csproj", "LightFeather.CodeChallenge.Domain/"]
COPY ["LightFeather.CodeChallenge.Ui/LightFeather.CodeChallenge.Ui.csproj", "LightFeather.CodeChallenge.Ui/"]
RUN dotnet restore "./LightFeather.CodeChallenge.Ui/LightFeather.CodeChallenge.Ui.csproj"
COPY . .
WORKDIR "/src/LightFeather.CodeChallenge.Ui"
RUN dotnet build "./LightFeather.CodeChallenge.Ui.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LightFeather.CodeChallenge.Ui.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LightFeather.CodeChallenge.Ui.dll"]
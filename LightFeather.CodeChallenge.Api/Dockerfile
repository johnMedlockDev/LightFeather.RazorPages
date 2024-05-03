FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["LightFeather.CodeChallenge.Domain/LightFeather.CodeChallenge.Domain.csproj", "LightFeather.CodeChallenge.Domain/"]
COPY ["LightFeather.CodeChallenge.Api/LightFeather.CodeChallenge.Api.csproj", "LightFeather.CodeChallenge.Api/"]
RUN dotnet restore "./LightFeather.CodeChallenge.Api/LightFeather.CodeChallenge.Api.csproj"
COPY . .
WORKDIR "/src/LightFeather.CodeChallenge.Api"
RUN dotnet build "./LightFeather.CodeChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "./LightFeather.CodeChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LightFeather.CodeChallenge.Api.dll"]
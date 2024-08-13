FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/API/WLCS.Api/WLCS.Api.csproj", "src/API/WLCS.Api/"]
COPY ["src/Modules/Competitions/WLCS.Modules.Competitions.Infrastructure/WLCS.Modules.Competitions.Infrastructure.csproj", "src/Modules/Competitions/WLCS.Modules.Competitions.Infrastructure/"]
COPY ["src/Modules/Competitions/WLCS.Modules.Competitions.Application/WLCS.Modules.Competitions.Application.csproj", "src/Modules/Competitions/WLCS.Modules.Competitions.Application/"]
COPY ["src/Modules/Competitions/WLCS.Modules.Competitions.Domain/WLCS.Modules.Competitions.Domain.csproj", "src/Modules/Competitions/WLCS.Modules.Competitions.Domain/"]
COPY ["src/Modules/Competitions/WLCS.Modules.Competitions.Presentation/WLCS.Modules.Competitions.Presentation.csproj", "src/Modules/Competitions/WLCS.Modules.Competitions.Presentation/"]
RUN dotnet restore "./src/API/WLCS.Api/WLCS.Api.csproj"
COPY . .
WORKDIR "/src/src/API/WLCS.Api"
RUN dotnet build "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WLCS.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]"]
COPY ["src/api/WLCS.Api/WLCS.Api.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Competition.Infrastructure/WLCS.Modules.Competition.Infrastructure.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Competition.Application/WLCS.Modules.Competition.Application.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Competition.Domain/WLCS.Modules.Competition.Domain.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Competition.Presentation/WLCS.Modules.Competition.Presentation.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Administration.Infrastructure/WLCS.Modules.Administration.Infrastructure.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Administration.Application/WLCS.Modules.Administration.Application.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Administration.Domain/WLCS.Modules.Administration.Domain.csproj", "src/api/WLCS.Api/"]
COPY ["src/api/WLCS.Modules.Administration.Presentation/WLCS.Modules.Administration.Presentation.csproj", "src/api/WLCS.Api/"]
RUN dotnet restore "./src/api/WLCS.Api/WLCS.Api.csproj"
COPY . .
WORKDIR "/src/src/api/WLCS.Api"
RUN dotnet build "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WLCS.Api.dll"]
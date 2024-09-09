FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["API/WLCS.Api/WLCS.Api.csproj", "API/WLCS.Api/"]
# Common Modules
COPY ["Common/WLCS.Common.Infrastructure/WLCS.Common.Infrastructure.csproj", "Common/WLCS.Common.Infrastructure/"]
COPY ["Common/WLCS.Common.Application/WLCS.Common.Application.csproj", "Common/WLCS.Common.Application/"]
COPY ["Common/WLCS.Common.Domain/WLCS.Common.Domain.csproj", "Common/WLCS.Common.Domain/"]
COPY ["Common/WLCS.Common.Presentation/WLCS.Common.Presentation.csproj", "Common/WLCS.Common.Presentation/"]
# Competitions Module
COPY ["Modules/Competitions/WLCS.Modules.Competitions.Infrastructure/WLCS.Modules.Competitions.Infrastructure.csproj", "Modules/Competitions/WLCS.Modules.Competitions.Infrastructure/"]
COPY ["Modules/Competitions/WLCS.Modules.Competitions.Application/WLCS.Modules.Competitions.Application.csproj", "Modules/Competitions/WLCS.Modules.Competitions.Application/"]
COPY ["Modules/Competitions/WLCS.Modules.Competitions.Domain/WLCS.Modules.Competitions.Domain.csproj", "Modules/Competitions/WLCS.Modules.Competitions.Domain/"]
COPY ["Modules/Competitions/WLCS.Modules.Competitions.Presentation/WLCS.Modules.Competitions.Presentation.csproj", "Modules/Competitions/WLCS.Modules.Competitions.Presentation/"]
COPY ["Modules/Competitions/WLCS.Modules.Competitions.IntegrationEvents/WLCS.Modules.Competitions.IntegrationEvents.csproj", "Modules/Competitions/WLCS.Modules.Competitions.IntegrationEvents/"]
# Athletes Module
COPY ["Modules/Athletes/WLCS.Modules.Athletes.Infrastructure/WLCS.Modules.Athletes.Infrastructure.csproj", "Modules/Athletes/WLCS.Modules.Athletes.Infrastructure/"]
COPY ["Modules/Athletes/WLCS.Modules.Athletes.Application/WLCS.Modules.Athletes.Application.csproj", "Modules/Athletes/WLCS.Modules.Athletes.Application/"]
COPY ["Modules/Athletes/WLCS.Modules.Athletes.Domain/WLCS.Modules.Athletes.Domain.csproj", "Modules/Athletes/WLCS.Modules.Athletes.Domain/"]
COPY ["Modules/Athletes/WLCS.Modules.Athletes.Presentation/WLCS.Modules.Athletes.Presentation.csproj", "Modules/Athletes/WLCS.Modules.Athletes.Presentation/"]
COPY ["Modules/Athletes/WLCS.Modules.Athletes.IntegrationEvents/WLCS.Modules.Athletes.IntegrationEvents.csproj", "Modules/Athletes/WLCS.Modules.Athletes.IntegrationEvents/"]
# Administration Module
COPY ["Modules/Administration/WLCS.Modules.Administration.Infrastructure/WLCS.Modules.Administration.Infrastructure.csproj", "Modules/Administration/WLCS.Modules.Administration.Infrastructure/"]
COPY ["Modules/Administration/WLCS.Modules.Administration.Application/WLCS.Modules.Administration.Application.csproj", "Modules/Administration/WLCS.Modules.Administration.Application/"]
COPY ["Modules/Administration/WLCS.Modules.Administration.Domain/WLCS.Modules.Administration.Domain.csproj", "Modules/Administration/WLCS.Modules.Administration.Domain/"]
COPY ["Modules/Administration/WLCS.Modules.Administration.Presentation/WLCS.Modules.Administration.Presentation.csproj", "Modules/Administration/WLCS.Modules.Administration.Presentation/"]
COPY ["Modules/Administration/WLCS.Modules.Administration.IntegrationEvents/WLCS.Modules.Administration.IntegrationEvents.csproj", "Modules/Administration/WLCS.Modules.Administration.IntegrationEvents/"]

RUN dotnet restore "./API/WLCS.Api/WLCS.Api.csproj"
COPY . .
WORKDIR "/src/API/WLCS.Api"
RUN dotnet build "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WLCS.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WLCS.Api.dll"]
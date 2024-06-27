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
# Competition Module
COPY ["src/modules/Competition/WLCS.Modules.Competition.Infrastructure/WLCS.Modules.Competition.Infrastructure.csproj", "src/modules/Competition/WLCS.Modules.Competition.Infrastructure/"]
COPY ["src/modules/Competition/WLCS.Modules.Competition.IntegrationEvents/WLCS.Modules.Competition.IntegrationEvents.csproj", "src/modules/Competition/WLCS.Modules.Competition.IntegrationEvents/"]
COPY ["src/modules/Competition/WLCS.Modules.Competition.Application/WLCS.Modules.Competition.Application.csproj", "src/modules/Competition/WLCS.Modules.Competition.Application/"]
COPY ["src/modules/Competition/WLCS.Modules.Competition.Domain/WLCS.Modules.Competition.Domain.csproj", "src/modules/Competition/WLCS.Modules.Competition.Domain/"]
COPY ["src/modules/Competition/WLCS.Modules.Competition.Presentation/WLCS.Modules.Competition.Presentation.csproj", "src/modules/Competition/WLCS.Modules.Competition.Presentation/"]
# Administration Module
COPY ["src/modules/Administration/WLCS.Modules.Administration.Infrastructure/WLCS.Modules.Administration.Infrastructure.csproj", "src/modules/Administration/WLCS.Modules.Administration.Infrastructure/"]
COPY ["src/modules/Administration/WLCS.Modules.Administration.IntegrationEvents/WLCS.Modules.Administration.IntegrationEvents.csproj", "src/modules/Administration/WLCS.Modules.Administration.IntegrationEvents/"]
COPY ["src/modules/Administration/WLCS.Modules.Administration.Application/WLCS.Modules.Administration.Application.csproj", "src/modules/Administration/WLCS.Modules.Administration.Application/"]
COPY ["src/modules/Administration/WLCS.Modules.Administration.Domain/WLCS.Modules.Administration.Domain.csproj", "src/modules/Administration/WLCS.Modules.Administration.Domain/"]
COPY ["src/modules/Administration/WLCS.Modules.Administration.Presentation/WLCS.Modules.Administration.Presentation.csproj", "src/modules/Administration/WLCS.Modules.Administration.Presentation/"]
# Athletes Module
COPY ["src/modules/Athletes/WLCS.Modules.Athletes.Infrastructure/WLCS.Modules.Athletes.Infrastructure.csproj", "src/modules/Athletes/WLCS.Modules.Athletes.Infrastructure/"]
COPY ["src/modules/Athletes/WLCS.Modules.Athletes.IntegrationEvents/WLCS.Modules.Athletes.IntegrationEvents.csproj", "src/modules/Athletes/WLCS.Modules.Athletes.IntegrationEvents/"]
COPY ["src/modules/Athletes/WLCS.Modules.Athletes.Application/WLCS.Modules.Athletes.Application.csproj", "src/modules/Athletes/WLCS.Modules.Athletes.Application/"]
COPY ["src/modules/Athletes/WLCS.Modules.Athletes.Domain/WLCS.Modules.Athletes.Domain.csproj", "src/modules/Athletes/WLCS.Modules.Athletes.Domain/"]
COPY ["src/modules/Athletes/WLCS.Modules.Athletes.Presentation/WLCS.Modules.Athletes.Presentation.csproj", "src/modules/Athletes/WLCS.Modules.Athletes.Presentation/"]
# Communication Module
COPY ["src/modules/Communication/WLCS.Modules.Communication.Infrastructure/WLCS.Modules.Communication.Infrastructure.csproj", "src/modules/Communication/WLCS.Modules.Communication.Infrastructure/"]
COPY ["src/modules/Communication/WLCS.Modules.Communication.IntegrationEvents/WLCS.Modules.Communication.IntegrationEvents.csproj", "src/modules/Communication/WLCS.Modules.Communication.IntegrationEvents/"]
COPY ["src/modules/Communication/WLCS.Modules.Communication.Application/WLCS.Modules.Communication.Application.csproj", "src/modules/Communication/WLCS.Modules.Communication.Application/"]
COPY ["src/modules/Communication/WLCS.Modules.Communication.Domain/WLCS.Modules.Communication.Domain.csproj", "src/modules/Communication/WLCS.Modules.Communication.Domain/"]
COPY ["src/modules/Communication/WLCS.Modules.Communication.Presentation/WLCS.Modules.Communication.Presentation.csproj", "src/modules/Communication/WLCS.Modules.Communication.Presentation/"]
# Results Module
COPY ["src/modules/Results/WLCS.Modules.Results.Infrastructure/WLCS.Modules.Results.Infrastructure.csproj", "src/modules/Results/WLCS.Modules.Results.Infrastructure/"]
COPY ["src/modules/Results/WLCS.Modules.Results.IntegrationEvents/WLCS.Modules.Results.IntegrationEvents.csproj", "src/modules/Results/WLCS.Modules.Results.IntegrationEvents/"]
COPY ["src/modules/Results/WLCS.Modules.Results.Application/WLCS.Modules.Results.Application.csproj", "src/modules/Results/WLCS.Modules.Results.Application/"]
COPY ["src/modules/Results/WLCS.Modules.Results.Domain/WLCS.Modules.Results.Domain.csproj", "src/modules/Results/WLCS.Modules.Results.Domain/"]
COPY ["src/modules/Results/WLCS.Modules.Results.Presentation/WLCS.Modules.Results.Presentation.csproj", "src/modules/Results/WLCS.Modules.Results.Presentation/"]
# Scheduling Module
COPY ["src/modules/Scheduling/WLCS.Modules.Scheduling.Infrastructure/WLCS.Modules.Scheduling.Infrastructure.csproj", "src/modules/Scheduling/WLCS.Modules.Scheduling.Infrastructure/"]
COPY ["src/modules/Scheduling/WLCS.Modules.Scheduling.IntegrationEvents/WLCS.Modules.Scheduling.IntegrationEvents.csproj", "src/modules/Scheduling/WLCS.Modules.Scheduling.IntegrationEvents/"]
COPY ["src/modules/Scheduling/WLCS.Modules.Scheduling.Application/WLCS.Modules.Scheduling.Application.csproj", "src/modules/Scheduling/WLCS.Modules.Scheduling.Application/"]
COPY ["src/modules/Scheduling/WLCS.Modules.Scheduling.Domain/WLCS.Modules.Scheduling.Domain.csproj", "src/modules/Scheduling/WLCS.Modules.Scheduling.Domain/"]
COPY ["src/modules/Scheduling/WLCS.Modules.Scheduling.Presentation/WLCS.Modules.Scheduling.Presentation.csproj", "src/modules/Scheduling/WLCS.Modules.Scheduling.Presentation/"]

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
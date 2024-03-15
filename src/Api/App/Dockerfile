FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /root

# Common
COPY ["src/Api/Common/Shared/Shared.csproj", "src/Api/Common/Shared/"]
COPY ["src/Api/Common/Domain/Domain.csproj", "scr/Api/Common/Domain/"]
COPY ["src/Api/Common/Application/Application.csproj", "scr/Api/Common/Application/"]
COPY ["src/Api/Common/Authorization/Authorization.csproj", "scr/Api/Common/Authorization/"]
COPY ["src/Api/Common/Infrastructure/Infrastructure.csproj", "scr/Api/Common/Infrastructure/"]
COPY ["src/Api/Common/Persistence/Persistence.csproj", "scr/Api/Common/Persistence/"]
COPY ["src/Api/Common/Endpoints/Endpoints.csproj", "scr/Api/Common/Endpoints/"]

# Modules - Users
COPY ["src/Api/Modules/Users/Modules.Users.Domain/Modules.Users.Domain.csproj", "src/Modules/Users/Modules.Users.Domain/"]
COPY ["src/Api/Modules/Users/Modules.Users.Application/Modules.Users.Application.csproj", "src/Modules/Users/Modules.Users.Application/"]
COPY ["src/Api/Modules/Users/Modules.Users.Endpoints/Modules.Users.Endpoints.csproj", "src/Modules/Users/Modules.Users.Endpoints/"]
COPY ["src/Api/Modules/Users/Modules.Users.Infrastructure/Modules.Users.Infrastructure.csproj", "src/Modules/Users/Modules.Users.Infrastructure/"]
COPY ["src/Api/Modules/Users/Modules.Users.Persistence/Modules.Users.Persistence.csproj", "src/Modules/Users/Modules.Users.Persistence/"]

# Modules - Notifications
COPY ["src/Api/Modules/Notifications/Modules.Notifications.Domain/Modules.Notifications.Domain.csproj", "src/Modules/Notifications/Modules.Notifications.Domain/"]
COPY ["src/Api/Modules/Notifications/Modules.Notifications.Application/Modules.Notifications.Application.csproj", "src/Modules/Notifications/Modules.Notifications.Application/"]
COPY ["src/Api/Modules/Notifications/Modules.Notifications.Infrastructure/Modules.Notifications.Infrastructure.csproj", "src/Modules/Notifications/Modules.Notifications.Infrastructure/"]
COPY ["src/Api/Modules/Notifications/Modules.Notifications.Persistence/Modules.Notifications.Persistence.csproj", "src/Modules/Notifications/Modules.Notifications.Persistence/"]

# Modules - Meets
COPY ["src/Api/Modules/Meets/Modules.Meets.Domain/Modules.Meets.Domain.csproj", "src/Modules/Meets/Modules.Meets.Domain/"]
COPY ["src/Api/Modules/Meets/Modules.Meets.Application/Modules.Meets.Application.csproj", "src/Modules/Meets/Modules.Meets.Application/"]
COPY ["src/Api/Modules/Meets/Modules.Meets.Endpoints/Modules.Meets.Endpoints.csproj", "src/Modules/Meets/Modules.Meets.Endpoints/"]
COPY ["src/Api/Modules/Meets/Modules.Meets.Infrastructure/Modules.Meets.Infrastructure.csproj", "src/Modules/Meets/Modules.Meets.Infrastructure/"]
COPY ["src/Api/Modules/Meets/Modules.Meets.Persistence/Modules.Meets.Persistence.csproj", "src/Modules/Meets/Modules.Meets.Persistence/"]

# Modules - Athletes
COPY ["src/Api/Modules/Athletes/Modules.Athletes.Domain/Modules.Athletes.Domain.csproj", "src/Modules/Athletes/Modules.Athletes.Domain/"]
COPY ["src/Api/Modules/Athletes/Modules.Athletes.Application/Modules.Athletes.Application.csproj", "src/Modules/Athletes/Modules.Athletes.Application/"]
COPY ["src/Api/Modules/Athletes/Modules.Athletes.Endpoints/Modules.Athletes.Endpoints.csproj", "src/Modules/Athletes/Modules.Athletes.Endpoints/"]
COPY ["src/Api/Modules/Athletes/Modules.Athletes.Infrastructure/Modules.Athletes.Infrastructure.csproj", "src/Modules/Athletes/Modules.Athletes.Infrastructure/"]
COPY ["src/Api/Modules/Athletes/Modules.Athletes.Persistence/Modules.Athletes.Persistence.csproj", "src/Modules/Athletes/Modules.Athletes.Persistence/"]

# Executable
COPY ["src/Api/App/App.csproj", "src/Api/App/"]

RUN dotnet restore "/src/Api/App/App.csproj"

COPY . .

WORKDIR "/root/src/Api/App"
RUN dotnet build "App.csproj" --configuration Release -o /app/build /p:UseAppHost=false

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.dll"]
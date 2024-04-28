FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SmartDj.Server/SmartDj.Server.csproj", "SmartDj.Server/"]
COPY ["SmartDj.Shared/SmartDj.Shared.csproj", "SmartDj.Shared/"]
RUN dotnet restore "SmartDj.Server/SmartDj.Server.csproj"
COPY . .
WORKDIR "/src/SmartDj.Server"
RUN dotnet build "SmartDj.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SmartDj.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartDj.Server.dll"]

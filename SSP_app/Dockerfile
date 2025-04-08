FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["SSP_app/SSP_app.csproj", "SSP_app/"]
RUN dotnet restore "SSP_app/SSP_app.csproj"
COPY . .
WORKDIR "/src/SSP_app"
RUN dotnet build "SSP_app.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "SSP_app.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSP_app.dll"]

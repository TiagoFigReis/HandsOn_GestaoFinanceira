FROM mcr.microsoft.com/dotnet/aspnet:9.0-windowsservercore-ltsc2022 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0-windowsservercore-ltsc2022 AS build
WORKDIR /src

COPY ["HandsOn-Back/src/API/", "API/"]
COPY ["HandsOn-Back/src/Application/", "Application/"]
COPY ["HandsOn-Back/src/Core/", "Core/"]
COPY ["HandsOn-Back/src/Infrastructure/", "Infrastructure/"]

RUN dotnet restore "API/API.csproj"

WORKDIR "/src/API"

RUN dotnet build "API.csproj" -c Release -o /app/build -nowarn:CS8618,CS0436,CS8601,CS8602,CS8603,CS8604,CS8625

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
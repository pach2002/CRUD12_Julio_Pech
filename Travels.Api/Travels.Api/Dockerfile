#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Travels.Api/Travels.Api.csproj", "Travels.Api/"]
COPY ["Travels.ApplicationServices/Travels.ApplicationServices.csproj", "Travels.ApplicationServices/"]
COPY ["Travels.ApplicationServices.Shared/Travels.ApplicationServices.Shared.csproj", "Travels.ApplicationServices.Shared/"]
COPY ["Travels.Core/Travels.Core.csproj", "Travels.Core/"]
COPY ["Travels.DataAccess/Travels.DataAccess.csproj", "Travels.DataAccess/"]
COPY ["Travels.Jwt/Travels.Jwt.csproj", "Travels.Jwt/"]
RUN dotnet restore "./Travels.Api/./Travels.Api.csproj"
COPY . .
WORKDIR "/src/Travels.Api"
RUN dotnet build "./Travels.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Travels.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Travels.Api.dll"]
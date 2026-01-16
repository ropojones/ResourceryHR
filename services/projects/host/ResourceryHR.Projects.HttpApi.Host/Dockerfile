# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/projects/host/ResourceryHR.Projects.HttpApi.Host/ResourceryHR.Projects.HttpApi.Host.csproj", "services/projects/host/ResourceryHR.Projects.HttpApi.Host/"]
COPY ["shared/ResourceryHR.Microservice.Shared/ResourceryHR.Microservice.Shared.csproj", "shared/ResourceryHR.Microservice.Shared/"]
COPY ["services/administration/src/ResourceryHR.Administration.EntityFrameworkCore/ResourceryHR.Administration.EntityFrameworkCore.csproj", "services/administration/src/ResourceryHR.Administration.EntityFrameworkCore/"]
COPY ["shared/ResourceryHR.Shared/ResourceryHR.Shared.csproj", "shared/ResourceryHR.Shared/"]
COPY ["services/administration/src/ResourceryHR.Administration.Domain/ResourceryHR.Administration.Domain.csproj", "services/administration/src/ResourceryHR.Administration.Domain/"]
COPY ["services/administration/src/ResourceryHR.Administration.Domain.Shared/ResourceryHR.Administration.Domain.Shared.csproj", "services/administration/src/ResourceryHR.Administration.Domain.Shared/"]
COPY ["shared/ResourceryHR.Hosting.Shared/ResourceryHR.Hosting.Shared.csproj", "shared/ResourceryHR.Hosting.Shared/"]
COPY ["shared/ResourceryHR.ServiceDefaults/ResourceryHR.ServiceDefaults.csproj", "shared/ResourceryHR.ServiceDefaults/"]
COPY ["services/projects/src/ResourceryHR.Projects.HttpApi/ResourceryHR.Projects.HttpApi.csproj", "services/projects/src/ResourceryHR.Projects.HttpApi/"]
COPY ["services/projects/src/ResourceryHR.Projects.Application.Contracts/ResourceryHR.Projects.Application.Contracts.csproj", "services/projects/src/ResourceryHR.Projects.Application.Contracts/"]
COPY ["services/projects/src/ResourceryHR.Projects.Domain.Shared/ResourceryHR.Projects.Domain.Shared.csproj", "services/projects/src/ResourceryHR.Projects.Domain.Shared/"]
COPY ["services/projects/src/ResourceryHR.Projects.Application/ResourceryHR.Projects.Application.csproj", "services/projects/src/ResourceryHR.Projects.Application/"]
COPY ["services/projects/src/ResourceryHR.Projects.Domain/ResourceryHR.Projects.Domain.csproj", "services/projects/src/ResourceryHR.Projects.Domain/"]
COPY ["services/projects/src/ResourceryHR.Projects.EntityFrameworkCore/ResourceryHR.Projects.EntityFrameworkCore.csproj", "services/projects/src/ResourceryHR.Projects.EntityFrameworkCore/"]
RUN dotnet restore "./services/projects/host/ResourceryHR.Projects.HttpApi.Host/ResourceryHR.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/ResourceryHR.Projects.HttpApi.Host"
RUN dotnet build "./ResourceryHR.Projects.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ResourceryHR.Projects.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceryHR.Projects.HttpApi.Host.dll"]
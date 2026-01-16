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
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/ResourceryHR.SaaS.HttpApi.Host/ResourceryHR.SaaS.HttpApi.Host.csproj", "services/saas/host/ResourceryHR.SaaS.HttpApi.Host/"]
COPY ["shared/ResourceryHR.Microservice.Shared/ResourceryHR.Microservice.Shared.csproj", "shared/ResourceryHR.Microservice.Shared/"]
COPY ["services/administration/src/ResourceryHR.Administration.EntityFrameworkCore/ResourceryHR.Administration.EntityFrameworkCore.csproj", "services/administration/src/ResourceryHR.Administration.EntityFrameworkCore/"]
COPY ["shared/ResourceryHR.Shared/ResourceryHR.Shared.csproj", "shared/ResourceryHR.Shared/"]
COPY ["services/administration/src/ResourceryHR.Administration.Domain/ResourceryHR.Administration.Domain.csproj", "services/administration/src/ResourceryHR.Administration.Domain/"]
COPY ["services/administration/src/ResourceryHR.Administration.Domain.Shared/ResourceryHR.Administration.Domain.Shared.csproj", "services/administration/src/ResourceryHR.Administration.Domain.Shared/"]
COPY ["shared/ResourceryHR.Hosting.Shared/ResourceryHR.Hosting.Shared.csproj", "shared/ResourceryHR.Hosting.Shared/"]
COPY ["shared/ResourceryHR.ServiceDefaults/ResourceryHR.ServiceDefaults.csproj", "shared/ResourceryHR.ServiceDefaults/"]
COPY ["services/saas/src/ResourceryHR.SaaS.HttpApi/ResourceryHR.SaaS.HttpApi.csproj", "services/saas/src/ResourceryHR.SaaS.HttpApi/"]
COPY ["services/saas/src/ResourceryHR.SaaS.Application.Contracts/ResourceryHR.SaaS.Application.Contracts.csproj", "services/saas/src/ResourceryHR.SaaS.Application.Contracts/"]
COPY ["services/administration/src/ResourceryHR.Administration.Application.Contracts/ResourceryHR.Administration.Application.Contracts.csproj", "services/administration/src/ResourceryHR.Administration.Application.Contracts/"]
COPY ["services/saas/src/ResourceryHR.SaaS.Domain.Shared/ResourceryHR.SaaS.Domain.Shared.csproj", "services/saas/src/ResourceryHR.SaaS.Domain.Shared/"]
COPY ["services/saas/src/ResourceryHR.SaaS.Application/ResourceryHR.SaaS.Application.csproj", "services/saas/src/ResourceryHR.SaaS.Application/"]
COPY ["services/administration/src/ResourceryHR.Administration.Application/ResourceryHR.Administration.Application.csproj", "services/administration/src/ResourceryHR.Administration.Application/"]
COPY ["services/saas/src/ResourceryHR.SaaS.Domain/ResourceryHR.SaaS.Domain.csproj", "services/saas/src/ResourceryHR.SaaS.Domain/"]
COPY ["services/saas/src/ResourceryHR.SaaS.EntityFrameworkCore/ResourceryHR.SaaS.EntityFrameworkCore.csproj", "services/saas/src/ResourceryHR.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "./services/saas/host/ResourceryHR.SaaS.HttpApi.Host/ResourceryHR.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/ResourceryHR.SaaS.HttpApi.Host"
RUN dotnet build "./ResourceryHR.SaaS.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ResourceryHR.SaaS.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceryHR.SaaS.HttpApi.Host.dll"]
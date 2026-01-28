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
COPY ["services/recruitment/NuGet.Config", "services/recruitment/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/recruitment/host/Resourcery.Recruitment.HttpApi.Host/Resourcery.Recruitment.HttpApi.Host.csproj", "services/recruitment/host/Resourcery.Recruitment.HttpApi.Host/"]
COPY ["shared/Resourcery.Microservice.Shared/Resourcery.Microservice.Shared.csproj", "shared/Resourcery.Microservice.Shared/"]
COPY ["services/administration/src/Resourcery.Administration.EntityFrameworkCore/Resourcery.Administration.EntityFrameworkCore.csproj", "services/administration/src/Resourcery.Administration.EntityFrameworkCore/"]
COPY ["shared/Resourcery.Shared/Resourcery.Shared.csproj", "shared/Resourcery.Shared/"]
COPY ["services/administration/src/Resourcery.Administration.Domain/Resourcery.Administration.Domain.csproj", "services/administration/src/Resourcery.Administration.Domain/"]
COPY ["services/administration/src/Resourcery.Administration.Domain.Shared/Resourcery.Administration.Domain.Shared.csproj", "services/administration/src/Resourcery.Administration.Domain.Shared/"]
COPY ["shared/Resourcery.Hosting.Shared/Resourcery.Hosting.Shared.csproj", "shared/Resourcery.Hosting.Shared/"]
COPY ["shared/Resourcery.ServiceDefaults/Resourcery.ServiceDefaults.csproj", "shared/Resourcery.ServiceDefaults/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.HttpApi/Resourcery.Recruitment.HttpApi.csproj", "services/recruitment/src/Resourcery.Recruitment.HttpApi/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.Application.Contracts/Resourcery.Recruitment.Application.Contracts.csproj", "services/recruitment/src/Resourcery.Recruitment.Application.Contracts/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.Domain.Shared/Resourcery.Recruitment.Domain.Shared.csproj", "services/recruitment/src/Resourcery.Recruitment.Domain.Shared/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.Application/Resourcery.Recruitment.Application.csproj", "services/recruitment/src/Resourcery.Recruitment.Application/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.Domain/Resourcery.Recruitment.Domain.csproj", "services/recruitment/src/Resourcery.Recruitment.Domain/"]
COPY ["services/recruitment/src/Resourcery.Recruitment.EntityFrameworkCore/Resourcery.Recruitment.EntityFrameworkCore.csproj", "services/recruitment/src/Resourcery.Recruitment.EntityFrameworkCore/"]
RUN dotnet restore "./services/recruitment/host/Resourcery.Recruitment.HttpApi.Host/Resourcery.Recruitment.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/recruitment/host/Resourcery.Recruitment.HttpApi.Host"
RUN dotnet build "./Resourcery.Recruitment.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Resourcery.Recruitment.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resourcery.Recruitment.HttpApi.Host.dll"]
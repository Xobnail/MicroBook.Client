#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MicroBook.Client/MicroBook.Client.Host.csproj", "MicroBook.Client/"]
COPY ["MicroBook.Client.Application/MicroBook.Client.Application.csproj", "MicroBook.Client.Application/"]
COPY ["MicroBook.Client.Contracts/MicroBook.Client.Contracts.csproj", "MicroBook.Client.Contracts/"]
COPY ["MicroBook.Client.Domain/MicroBook.Client.Domain.csproj", "MicroBook.Client.Domain/"]
RUN dotnet restore "./MicroBook.Client/MicroBook.Client.Host.csproj"
COPY . .
WORKDIR "/src/MicroBook.Client"
RUN dotnet build "./MicroBook.Client.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroBook.Client.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroBook.Client.Host.dll"]
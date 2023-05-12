#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Src/Musala.Gateways.WebApi/Musala.Gateways.WebApi.csproj", "Src/Musala.Gateways.WebApi/"]
COPY ["Src/Musala.Gateways.Application/Musala.Gateways.Application.csproj", "Src/Musala.Gateways.Application/"]
COPY ["Src/Musala.Gateways.Persistence/Musala.Gateways.Persistence.csproj", "Src/Musala.Gateways.Persistence/"]
COPY ["Src/Musala.Gateways.Domain/Musala.Gateways.Domain.csproj", "Src/Musala.Gateways.Domain/"]
COPY ["Src/Musala.Gateways.Infrastructure/Musala.Gateways.Infrastructure.csproj", "Src/Musala.Gateways.Infrastructure/"]
RUN dotnet restore "Src/Musala.Gateways.WebApi/Musala.Gateways.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/Musala.Gateways.WebApi"
RUN dotnet build "Musala.Gateways.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Musala.Gateways.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Musala.Gateways.WebApi.dll"]
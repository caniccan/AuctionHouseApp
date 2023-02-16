#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuctionHouse.Sourcing/AuctionHouse.Sourcing.csproj", "AuctionHouse.Sourcing/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
RUN dotnet restore "AuctionHouse.Sourcing/AuctionHouse.Sourcing.csproj"
COPY . .
WORKDIR "/src/AuctionHouse.Sourcing"
RUN dotnet build "AuctionHouse.Sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuctionHouse.Sourcing.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuctionHouse.Sourcing.dll"]
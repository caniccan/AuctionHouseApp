#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuctionHouse.UI/AuctionHouse.UI.csproj", "AuctionHouse.UI/"]
COPY ["AuctionHouse.Infrastructure/AuctionHouse.Infrastructure.csproj", "AuctionHouse.Infrastructure/"]
COPY ["AuctionHouse.Core/AuctionHouse.Core.csproj", "AuctionHouse.Core/"]
RUN dotnet restore "AuctionHouse.UI/AuctionHouse.UI.csproj"
COPY . .
WORKDIR "/src/AuctionHouse.UI"
RUN dotnet build "AuctionHouse.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuctionHouse.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuctionHouse.UI.dll"]
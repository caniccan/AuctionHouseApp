#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuctionHouse.APIGateway/AuctionHouse.APIGateway.csproj", "AuctionHouse.APIGateway/"]
RUN dotnet restore "AuctionHouse.APIGateway/AuctionHouse.APIGateway.csproj"
COPY . .
WORKDIR "/src/AuctionHouse.APIGateway"
RUN dotnet build "AuctionHouse.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuctionHouse.APIGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuctionHouse.APIGateway.dll"]
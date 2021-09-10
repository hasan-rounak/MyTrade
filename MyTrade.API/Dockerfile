#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyTrade.API/MyTrade.API.csproj", "MyTrade.API/"]
RUN dotnet restore "MyTrade.API/MyTrade.API.csproj"
COPY . .
WORKDIR "/src/MyTrade.API"
RUN dotnet build "MyTrade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyTrade.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTrade.API.dll"]
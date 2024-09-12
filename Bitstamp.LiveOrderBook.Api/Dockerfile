FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bitstamp.LiveOrderBook.Api/Bitstamp.LiveOrderBook.Api.csproj", "Bitstamp.LiveOrderBook.Api/"]
RUN dotnet restore "Bitstamp.LiveOrderBook.Api/Bitstamp.LiveOrderBook.Api.csproj"
COPY . .
WORKDIR "/src/Bitstamp.LiveOrderBook.Api"
RUN dotnet build "Bitstamp.LiveOrderBook.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bitstamp.LiveOrderBook.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bitstamp.LiveOrderBook.Api.dll"]

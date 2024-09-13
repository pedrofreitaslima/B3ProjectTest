FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bitstamp.LiveOrderBook.EthUsd.Function/Bitstamp.LiveOrderBook.EthUsd.Function.csproj", "Bitstamp.LiveOrderBook.EthUsd.Function/"]
RUN dotnet restore "Bitstamp.LiveOrderBook.EthUsd.Function/Bitstamp.LiveOrderBook.EthUsd.Function.csproj"
COPY . .
WORKDIR "/src/Bitstamp.LiveOrderBook.EthUsd.Function"
RUN dotnet build "Bitstamp.LiveOrderBook.EthUsd.Function.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bitstamp.LiveOrderBook.EthUsd.Function.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bitstamp.LiveOrderBook.EthUsd.Function.dll"]

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bitstamp.LiveOrderBook.WorkerService/Bitstamp.LiveOrderBook.WorkerService.csproj", "Bitstamp.LiveOrderBook.WorkerService/"]
RUN dotnet restore "Bitstamp.LiveOrderBook.WorkerService/Bitstamp.LiveOrderBook.WorkerService.csproj"
COPY . .
WORKDIR "/src/Bitstamp.LiveOrderBook.WorkerService"
RUN dotnet build "Bitstamp.LiveOrderBook.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bitstamp.LiveOrderBook.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bitstamp.LiveOrderBook.WorkerService.dll"]

# Bitstamp WebSocket Project

## Summary
+ [What is this project?](#whatis)
+ [How to works this solution architect?](#solutionarchitectworks)
+ [How to run?](#howtorun)
+ [What are the techonologies applied?](#techonologies)
+ [What are the libraries used in ours applications?](#libraries)
+ [What are the patterns applied?](#patterns)
+ [Who are the authors?](#authors)

## <a name="whatis">What is this project?</a>
This project was create to show for **B3 Company** as a test of knowlodges and the goals purpose for this project is **create an architecture with to subscribe in Bitstamp and consume live data of cryptocurrencies**, so transmiting these data for all applications that compose this solution.

## Goals
- All projects in this solution should have at least **80 percent of code coverage**.
- The solution should subscribe with **web socket** in **Bitstamp site** and consuming data about **live order book** to two currencies pairs being them: **BTC/USD** and **ETH/USD**.
- Persist this data consuming in any database could be NoSQL or SQL.
- Each 5 seconds print data below:
    1. Highest USD price for cryptocurrency.
    2. Lowest USD price for cryptocurrency.
    3. Average of the last 5 seconds USD price for cryptocurrency.
    4. Average USD price for cryptocurrency.
- Create an API Rest to simulate the current price of bids and asks.
    1. One endpoint with GET method to query current price for bid.
        - It should be for each cryptocurrency (BTC and ETH). 
    2. One endpoint with GET medhot to query current price for ask.
        - It should be for each cryptocurrency (BTC and ETH).
    3. The response should show for user the following data:
        - ID transact
        - Collection of items used to calculate the USD current price.
        - The request number of cryptocurrency.
        - Type of operation being them: bid or ask.
        - The USD current price (save this value in any database).

## <a name="solutionarchitectworks">How to works this solution architect?</a>
This solution contains in the most part some application created using .NET 6.0 and C# language, except the frontend screen that should show in live the highest, lowest, average in the last 5 seconds, and average in all the time of USD price for each cryptocurrency.
So, these .NET application that compose solution are:
1. **Bitstamp.LiveOrderBook.Domain** -
2. **Bitstamp.LiveOrderBook.WorkerService** - 
3. **Bitstamp.LiveOrderBook.BtcUsd.Function** - 
4. **Bitstamp.LiveOrderBook.EthUsd.Function** -
5. **Bitstamp.LiveOrderBook.Api** - 

### Solution Design
#### Default

#### Purpose to AWS

#### Purpose to Azure
![Solution in Azure](https://github.com/pedrofreitaslima/B3ProjectTest/blob/main/docs/images/BitstampAzure.svg)

## <a name="howtorun">How to run?</a>


## <a name="technologies">What are the techonologies applied?</a>
- **.NET 6.0** - Framework created for Microsoft used in all ours applications.
- **C#** - Programming language used in all ours applications.
- **RabbitMQ** - Messaging and Streaming broken to transmit data between our application.
- **MongoDB** - NoSQL database used to storage datas in all our solution.
- **Docker** - PaaS used to build and deploy ours applications.
- **HTTP** - Protocol to comunicate in our rest API.
- **Web Socket** - Protocol to comunicate with Bitstamp site to get data about cryptocurrency.]
- **Insomnia** - Tools used to test and do HTTP requests.
- **Jetbrains Rider** - IDE used to constructed the .NET applications.
- **VS Code** - IDE used to constructed the frontend application.
- **VueJS** - framework used with javascript for create SPA to show the current data for each 5 seconds.

## <a name="libraries">What are the libraries used in ours applications?</a>
- **MediatR** - 
- **AutoMapper** - 
- **MongoDB.Driver** - 
- **EasyNetQ** - 
- **FluentValidation** - 
- **XUnit** - 
- **Moq** - 
- **FluentAssertion**

## <a name="patterns">What are the patterns applied?</a>
- **Event Sourcing Pattern**
- **CQRS**
- **SOLID**
- **DDD**
- **TDD**
- **Clean Code**
- **Clean Architecture**
- **Unit Test**
- **KISS**
- **YAGNI**
- **DI**
- **DRY**
- **Microsservices**
- **Messaging sourcing**
- **CI/CD**
- **REST**
- **Asynchronous application**

## <a name="authors">Who are the authors?</a>
- pedrofreitaslima &copy;

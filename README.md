# Azure Function RabbitMQ Trigger Demo

This project demonstrates an Azure Function developed in .NET 6 to showcase the RabbitMQ trigger. The function processes messages from a RabbitMQ queue named "orders" and uses SQL Server with Entity Framework Core as the ORM.

## Overview
The primary function, `AddOrder`, gets order from http trigger and adds into RabbitMQ queue for futher processing.
The seconday function, `OrderProcessorFunction`, processes messages from the RabbitMQ queue, deserializes order data, and stores it in the SQL Server database.

## Prerequisites

- RabbitMQ instance with a queue named "orders".
- Azure Storage Account (for Azure Functions runtime).
- SQL Server Database for storing orders.
- Properly configured connection strings in the `local.settings.json` file.

## Configuration

Update the `local.settings.json` file with necessary connection strings and configuration settings for RabbitMQ, SQL Server, and other dependencies.

## How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/RahulMule/AzureFunction_RabbitMQ_Demo.git
   cd AzureFunction_RabbitMQ_Demo
   dotnet build
   dotnet run




# License

This project is licensed under the [MIT License](LICENSE).


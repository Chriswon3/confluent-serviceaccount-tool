# Confluent Service Account Connectivity Tool

A .NET 8 console application to **test connectivity to Confluent Cloud**.  
This tool allows you to consume and produce events from Kafka topics using **Confluent Service Accounts**.

---

## ✨ Features

- ✅ Produce test messages to a Confluent Cloud topic  
- ✅ Consume messages from a Confluent Cloud topic  
- ✅ Supports **JSON-formatted messages** (human-readable)  
- ⚠️ Avro and Protobuf messages can also be consumed, but they will appear as **encoded/non-readable** since deserializers are not configured  

---

## 📦 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- A [Confluent Cloud](https://confluent.cloud/) account  
- A **Service Account** with the required ACLs for the topics you want to test  
- Your Confluent Cloud cluster credentials:
  - Bootstrap servers  
  - Service Account Id
  - Service Account Secret
  - Group Id
  - Topic

---

## ⚙️ Configuration

When running the ConsoleApp, you will be prompted for your configuration.

## ▶️ Running the Application
Build
`dotnet build`

Run
`dotnet run`

﻿/*

document: https://docs.microsoft.com/ja-jp/azure/cosmos-db/create-sql-api-dotnet

dotnet new console --name cosmostest
cd cosmostest
dotnet add package Microsoft.Azure.Cosmos
dotnet add package Newtonsoft.Json
code .
dotnet run

*/

using System;
using Microsoft.Azure.Cosmos;

namespace test
{
    class Program
    {

        static string connectionString = "DONT-WRITE-HERE";

        static void Print(object value) 
        {
            Console.WriteLine(value);
        }

        static string Read(string prompt)
        {
            Print(prompt);
            return Console.ReadLine();
        }

        static void SetConnectionString() 
        {
            connectionString = Read("Connection string:");
        }

        static void CreateDatabase()
        {
            var databaseId = Read("Database id:");
            var cc = new CosmosClient(connectionString);
            cc.CreateDatabaseAsync(databaseId).Wait();
        }

        static void CreateContainer()
        {
            var databaseId = Read("Database id:");
            var containerName = Read("Container name:");
            var partitionKeyPath = Read("Partition key path:");
            var cc = new CosmosClient(connectionString);
            var db = cc.GetDatabase(databaseId);
            db.CreateContainerAsync(containerName, partitionKeyPath);
        }

        static void CreateItem()
        {
            var databaseId = Read("Database id:");
            var containerName = Read("Container name:");
            var songTitle = Read("songTitle(id):");
            var artist = Read("artist:");
            var music = new Music {Id = songTitle, Artist = artist};

            var cc = new CosmosClient(connectionString);
            var db = cc.GetDatabase(databaseId);
            var container = db.GetContainer(containerName);    
            container.CreateItemAsync(music);
        }

        static void ListItems()
        {
            var databaseId = Read("Database id:");
            var containerName = Read("Container name:");
            var cc = new CosmosClient(connectionString);
            var db = cc.GetDatabase(databaseId);
            var container = db.GetContainer(containerName);    
            var query = "select * from m";
            using var fe = container.GetItemQueryIterator<Music>(query);
            while (fe.HasMoreResults)
            {
                foreach (var music in fe.ReadNextAsync().Result)
                {
                    Print("id: " + music.Id + ", artist: " + music.Artist);
                }
            }
        }

        static void Main(string[] args)
        {

            SetConnectionString();

            while (true)
            {
                var command = Read("Command:");
                switch (command)
                {
                    case "CreateDatabase":
                        CreateDatabase();
                        break;
                    case "CreateContainer":
                        CreateContainer();
                        break;
                    case "CreateItem":
                        CreateItem();
                        break;
                    case "ListItems":
                        ListItems();
                        break;
                    case "Exit":
                    case "Quit":
                        return;
                    default:
                        Print("Unknown command: " + command);
                        break;
                }
            }

        }
    }
}

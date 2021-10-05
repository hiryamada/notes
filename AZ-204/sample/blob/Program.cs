using System;
using Azure.Storage.Blobs;

// 接続文字列
var connectionString = "DONT-WRITE-HERE";

void Print(object value)
{
    Console.WriteLine(value);
}

string Read(string prompt)
{
    Print(prompt);
    return Console.ReadLine();
}

void SetConnectionString()
{
    connectionString = Read("Connection String:");
}

void ListContainers()
{
    var bsc = new BlobServiceClient(connectionString);
    foreach (var container in bsc.GetBlobContainers())
    {
        Console.WriteLine(container.Name);
    }
}

void CreateContainer() 
{
    Console.WriteLine("Container name:");
    var containerName = Console.ReadLine();
    var bcc = new BlobContainerClient(connectionString, containerName);
    bcc.CreateIfNotExists();
}

void DeleteContainer() 
{
    Console.WriteLine("Container name:");
    var containerName = Console.ReadLine();
    var bcc = new BlobContainerClient(connectionString, containerName);
    bcc.Delete();
}

void Upload()
{
    string containerName = Read("Container name:");
    string localFileName = Read("Local file name:");
    var bc = new BlobClient(connectionString, containerName, localFileName);
    bc.Upload(localFileName);
}

void Download()
{
    string containerName = Read("Container name:");
    string blobName = Read("Blob name:");
    var bc = new BlobClient(connectionString, containerName, blobName);
    bc.DownloadTo(blobName);
}

void ListBlobs()
{
    string containerName = Read("Container name:");
    var bcc = new BlobContainerClient(connectionString, containerName);
    foreach (var blob in bcc.GetBlobs())
    {
        Print(blob.Name);
    }
}

SetConnectionString();

while (true)
{
    Print("Command:");
    var input = Console.ReadLine();
    switch (input) {
        case "ListContainers":
            ListContainers();
            break;
        case "CreateContainer":
            CreateContainer();
            break;
        case "DeleteContainer":
            DeleteContainer();
            break;
        case "ListBlobs":
            ListBlobs();
            break;
        case "Upload":
            Upload();
            break;
        case "Download":
            Download();
            break;
        case "Exit":
        case "Quit":
            return;
        default:
            Print("Unknown command: " + input);
            break;
    }
}
/*

document: https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-dotnet

dotnet new console -n blobtest
cd blobtest
dotnet add package Azure.Storage.Blob
code .

Ctrl + Shift + Space: パラメータヒントの表示
F5: デバッグ実行
Ctrl + F5: デバッグ無しで実行

*/

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
        Print(container.Name);
    }
}

void CreateContainer() 
{
    var containerName = Read("Container name:");
    var bcc = new BlobContainerClient(connectionString, containerName);
    bcc.CreateIfNotExists();
}

void DeleteContainer() 
{
    var containerName = Read("Container name:");
    var bcc = new BlobContainerClient(connectionString, containerName);
    bcc.Delete();
}

void Upload()
{
    string containerName = Read("Container name:");
    string blobPath = Read("Blob Path:");
    string localFilePath = Read("Local file path:");
    var bc = new BlobClient(connectionString, containerName, blobPath);
    bc.Upload(localFilePath);
}

void Download()
{
    string containerName = Read("Container name:");
    string blobPath = Read("Blob Path:");
    string localFilePath = Read("Local file path:");
    var bc = new BlobClient(connectionString, containerName, blobPath);
    bc.DownloadTo(localFilePath);
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


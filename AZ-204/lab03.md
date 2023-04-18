# ラボ3 コードの最終形

冒頭のエンドポイント、アカウント名、アカウントキーはご自身のリソースのものをご記入ください。

```cs
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Threading.Tasks;
public class Program
{
    private const string blobServiceEndpoint = "";
    private const string storageAccountName = "";
    private const string storageAccountKey = "";
    public static async Task Main(string[] args)
    {
        Console.WriteLine("演習3 タスク3: ストレージアカウントの情報を表示:");
        StorageSharedKeyCredential accountCredentials = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);
        BlobServiceClient serviceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), accountCredentials);
        AccountInfo info = await serviceClient.GetAccountInfoAsync();
        await Console.Out.WriteLineAsync($"Connected to Azure Storage Account");
        await Console.Out.WriteLineAsync($"Account name:\t{storageAccountName}");
        await Console.Out.WriteLineAsync($"Account kind:\t{info?.AccountKind}");
        await Console.Out.WriteLineAsync($"Account sku:\t{info?.SkuName}");
        await EnumerateContainersAsync(serviceClient);
        string existingContainerName = "raster-graphics";
        await EnumerateBlobsAsync(serviceClient, existingContainerName);

        string newContainerName = "vector-graphics";
        BlobContainerClient containerClient = await GetContainerAsync(serviceClient, newContainerName);

        Console.WriteLine("演習4 タスク4: BLOB にアクセスするためのURIを表示");
        string uploadedBlobName = "graph.svg";
        BlobClient blobClient = await GetBlobAsync(containerClient, uploadedBlobName);
        await Console.Out.WriteLineAsync($"Blob Url:\t{blobClient.Uri}");
    }
    private static async Task EnumerateContainersAsync(BlobServiceClient client)
    {
        Console.WriteLine("演習3 タスク4: 既存のコンテナーを列挙");
        await foreach (BlobContainerItem container in client.GetBlobContainersAsync())
        {
            await Console.Out.WriteLineAsync($"Container:\t{container.Name}");
        }
    }
    private static async Task EnumerateBlobsAsync(BlobServiceClient client, string containerName)
    {
        Console.WriteLine("演習4 タスク1: 既存のコンテナー内の BLOB を列挙");
        BlobContainerClient container = client.GetBlobContainerClient(containerName);
        await Console.Out.WriteLineAsync($"Searching:\t{container.Name}");
        await foreach (BlobItem blob in container.GetBlobsAsync())
        {
            await Console.Out.WriteLineAsync($"Existing Blob:\t{blob.Name}");
        }
    }
    private static async Task<BlobContainerClient> GetContainerAsync(BlobServiceClient client, string containerName)
    {
        Console.WriteLine("演習4 タスク2: コンテナーを(なければ)作成");
        BlobContainerClient container = client.GetBlobContainerClient(containerName);
        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);
        await Console.Out.WriteLineAsync($"New Container:\t{container.Name}");
        return container;
    }
    private static async Task<BlobClient> GetBlobAsync(BlobContainerClient client, string blobName)
    {
        BlobClient blob = client.GetBlobClient(blobName);
        await Console.Out.WriteLineAsync($"Blob Found:\t{blob.Name}");
        return blob;
    }
}
```
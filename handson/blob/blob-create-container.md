# ハンズオン: Blobコンテナーの一覧を取得するコンソールアプリ


```
dotnet new console -n blobcreatecontainer
cd blobcreatecontainer
dotnet add package Azure.Storage.Blobs --version 12.11.0
dotnet add package Azure.Identity --version 1.5.0
code -r .
```


```c#
using Azure.Identity;
using Azure.Storage.Blobs;

const string endpoint = "https://funcinput0973432.blob.core.windows.net/";
var uri = new Uri(endpoint);
var cred = new DefaultAzureCredential();
var client = new BlobServiceClient(uri, cred);

string name = DateTime.Now.ToString("yyyyMMddHHmmss");
await client.CreateBlobContainerAsync(name);

```
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;

using static System.Console;

// 認証情報
var credential = new DefaultAzureCredential();

// ユーザーシークレットを読み取る
var config = new ConfigurationBuilder()
  .AddUserSecrets<Program>()
  .Build();

// Blob エンドポイント
var endpoint = new Uri(config["endpoint"]);

// プロンプトを表示し、キーボードから文字列を入力する
string Input(string prompt)
{
  Write(prompt);
  Write(": ");
  return ReadLine() ?? "";
}

// コンテナー 一覧
void ListContainers()
{
  var bsc = new BlobServiceClient(endpoint, credential);
  foreach (var container in bsc.GetBlobContainers())
  {
    WriteLine(container.Name);
  }
}

// コンテナー 作成
void CreateContainer()
{
  var containerName = Input("コンテナ名");
  var bcc = new BlobContainerClient(new Uri(endpoint, containerName), credential);
  bcc.CreateIfNotExists();
}

// コンテナー 削除
void DeleteContainer()
{
  Console.WriteLine("コンテナ名");
  var containerName = Console.ReadLine();
  var bcc = new BlobContainerClient(new Uri(endpoint, containerName), credential);
  bcc.Delete();
}

// Blob ダウンロード
void Upload()
{
  string containerName = Input("コンテナ名");
  string localFileName = Input("ローカルのファイル名");
  var bcc = new BlobContainerClient(new Uri(endpoint, containerName), credential);
  var bc = bcc.GetBlobClient(localFileName);
  bc.Upload(localFileName);
}

// Blob ダウンロード
void Download()
{
  string containerName = Input("コンテナ名");
  string blobName = Input("Blob name:");
  var bcc = new BlobContainerClient(new Uri(endpoint, containerName), credential);
  var bc = bcc.GetBlobClient(blobName);
  bc.DownloadTo(blobName);
}

// Blob 一覧表示
void ListBlobs()
{
  string containerName = Input("コンテナ名");
  var bcc = new BlobContainerClient(new Uri(endpoint, containerName), credential);
  foreach (var blob in bcc.GetBlobs())
  {
    WriteLine(blob.Name);
  }
}

while (true)
{
  var command = Input("コマンド");
  switch (command)
  {
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
      WriteLine("不明なコマンド: " + command);
      break;
  }
}

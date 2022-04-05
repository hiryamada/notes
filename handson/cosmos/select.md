# サンプルコード: 項目の作成と検索

以下のコードをProgram.csに上書きします。

endpoint には、Cosmos DBのエンドポイントを指定します（Cosmos DBアカウントの「概要」ページにURLが書かれています）

`dotnet run` で実行して、ListItems や CreateItem の2つのコマンドを投入します。

```c#
using Azure.Identity;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

var endpoint = "https://cosmos9827349234.documents.azure.com:443/";
var cred = new DefaultAzureCredential();
var client = new CosmosClient(endpoint, cred);

while (true)
{
    var command = Read("Command:");
    switch (command)
    {
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

void Print(object value) 
{
    Console.WriteLine(value);
}

string Read(string prompt)
{
    Print(prompt);
    return Console.ReadLine();
}

void CreateItem()
{
    var databaseId = "musicdb";
    var containerName = "music";
    var songTitle = Read("id(song title)):");
    var artist = Read("partition key(artist):");
    var music = new Music {Id = songTitle, Artist = artist};

    var db = client.GetDatabase(databaseId);
    var container = db.GetContainer(containerName);    
    container.CreateItemAsync(music);
}

void ListItems()
{
    var databaseId = "musicdb";
    var containerName = "music";

    var db = client.GetDatabase(databaseId);
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

class Music
{
    [JsonProperty(PropertyName = "id")]
    public string Id {get; set;}
    [JsonProperty(PropertyName = "artist")]
    public string Artist {get;set;}
}
```


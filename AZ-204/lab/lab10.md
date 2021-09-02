# ラボ10 Queue Storage

```
ストレージアカウント
└キュー
  ↑↓ キューの作成、メッセージの受信(+削除)、メッセージの送信
.NETアプリケーション＋Queue Storageクライアントライブラリ
```

- 演習1
  - ストレージアカウントを作成
  - 接続文字列をコピー
- 演習2
  - .NETアプリケーションを作成
  - キュー （名前: `messagequeue`） を作成するコードを追加
  - アプリケーションを実行して、キューを作成する
- 演習3
  - キューからメッセージを読み込むコードを追加
  - ストレージアカウントのStorage Explorerを使用して、キューにメッセージを入れる
  - アプリケーションを実行して、キューからメッセージを読み取る（ここではメッセージの削除はしない）
- 演習3 タスク3
  - キューから読み込んだメッセージを削除するコードを追加
  - アプリケーションを実行して、キューからメッセージを読み取る。そのメッセージは削除される。
- 演習4
  - キューに新しいメッセージを送信するコードを追加
  - アプリケーションを実行して、キューにメッセージを書き込む
  - ストレージアカウントのStorage Explorerを使用して、キューに入ったメッセージを確認する

■コード例

演習2: キューの作成
```
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    // 接続文字列はAzure Key Vaultに格納すべき。
    private const string storageConnectionString = "接続文字列"; 
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        // 演習2～4共通部分
        QueueClient client = new QueueClient(storageConnectionString, queueName);

        // 演習2: キューの作成
        await client.CreateAsync();
        Console.WriteLine($"---Account Metadata---");
        Console.WriteLine($"Account Uri:\t{client.Uri}");

    }
}
```


演習3: メッセージの読み取り
```
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    // 接続文字列はAzure Key Vaultに格納すべき。
    private const string storageConnectionString = "接続文字列"; 
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        // 演習2～4共通部分
        QueueClient client = new QueueClient(storageConnectionString, queueName);

        // 演習3: メッセージの読み取り
        Console.WriteLine($"---Existing Messages---");
        int batchSize = 10;
        TimeSpan visibilityTimeout = TimeSpan.FromSeconds(2.5d);            
        Response<QueueMessage[]> messages = await client.ReceiveMessagesAsync(batchSize, visibilityTimeout);
        foreach (QueueMessage message in messages?.Value)
        {
            Console.WriteLine($"[{message.MessageId}]\t{message.MessageText}");
        }
    }
}
```

演習3タスク3: 読み取ったメッセージの削除
```
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    // 接続文字列はAzure Key Vaultに格納すべき。
    private const string storageConnectionString = "接続文字列"; 
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        // 演習2～4共通部分
        QueueClient client = new QueueClient(storageConnectionString, queueName);

        // 演習3: メッセージの読み取り
        Console.WriteLine($"---Existing Messages---");
        int batchSize = 10;
        TimeSpan visibilityTimeout = TimeSpan.FromSeconds(2.5d);            
        Response<QueueMessage[]> messages = await client.ReceiveMessagesAsync(batchSize, visibilityTimeout);
        foreach (QueueMessage message in messages?.Value)
        {
            Console.WriteLine($"[{message.MessageId}]\t{message.MessageText}");
            // 演習3タスク3: 読み取ったメッセージの削除
            await client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }
    }
}
```


演習4: メッセージの作成
```
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    // 接続文字列はAzure Key Vaultに格納すべき。
    private const string storageConnectionString = "接続文字列"; 
    private const string queueName = "messagequeue";

    public static async Task Main(string[] args)
    {
        // 演習2～4共通部分
        QueueClient client = new QueueClient(storageConnectionString, queueName);


        // 演習4: メッセージの作成
        Console.WriteLine($"---New Messages---");
        string greeting = "Hi, Developer!";
        await client.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(greeting)));            
        Console.WriteLine($"Sent Message:\t{greeting}");

    }
}
```


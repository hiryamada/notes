// Controllers/QueueController.cs

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class QueueController
{
    private readonly QueueClient _client;

    // DIを使用してキューサービスのクライアントを受け取る
    public QueueController(QueueServiceClient client)
    {
        // キュー操作用のクライアントを取得
        _client = client.GetQueueClient("queue1");
    }
    [HttpGet("/send")]
    public async Task<object> SendMessage(string message = "hello,world!")
    {
        // メッセージを送信
        return await _client.SendMessageAsync(message);
    }
    [HttpGet("/receive")]
    public async Task<QueueMessage> ReceiveMessage()
    {
        // メッセージを受信
        var result = await _client.ReceiveMessageAsync();

        // メッセージが受信できた場合は、そのメッセージをキューから削除
        if (result.Value != null)
        {
            var message = result.Value;
            await _client.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        }
        return result;
    }
}
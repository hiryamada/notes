# デバッグ手法

## デバッガを使う

コードの適当な地点にブレークポイントを設置し、デバッグ実行を開始。

`kernel` 変数の中を覗く。

カーネルに追加されたプラグイン等はこれで確認できる。

## HTTP通信のキャプチャ

以下のようなクラスを準備する。

```cs
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class CustomDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        System.Console.WriteLine("*** HTTP リクエスト送信 BEGIN ");
        System.Console.WriteLine(request);
        if (request.Content != null)
        {
            var requestBody = await request.Content.ReadAsStringAsync();
            System.Console.WriteLine("Request Body: ");
            System.Console.WriteLine(requestBody);
        }
        System.Console.WriteLine("*** HTTP リクエスト送信 END ");

        var result = base.SendAsync(request, cancellationToken);

        // HTTP リクエスト送信後の処理

        var response = await result;

        System.Console.WriteLine("*** HTTP レスポンス受信 BEGIN ");
        System.Console.WriteLine(response);
        if (response.Content != null)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine("Response Body: ");
            System.Console.WriteLine(responseBody);
        }
        System.Console.WriteLine("*** HTTP レスポンス受信 END ");

        return response;
    }
}
```

`CustomDelegatingHandler`を使って`HttpClient`を作成する。

```c#
var httpClient = new HttpClient(
    new CustomDelegatingHandler
    {
        InnerHandler = new HttpClientHandler()
    });
```

`Kernel` 構築時に、`AddAzureOpenAIChatCompletion` の引数で `httpClient` を渡す。

```c#
var kernel = Kernel.CreateBuilder()
    .AddAzureOpenAIChatCompletion(
        deployment, endpoint, key,
        httpClient: httpClient)
    .Build();
```

これで、Azure OpenAIとの通信がログ出力され、リクエストボディ・レスポンスボディが見えるようになる。


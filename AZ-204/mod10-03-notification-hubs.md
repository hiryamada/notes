
Azure Notification Hubs

[製品ページ](https://azure.microsoft.com/ja-jp/services/notification-hubs/)


[ドキュメント](https://docs.microsoft.com/ja-jp/azure/notification-hubs/notification-hubs-push-notification-overview)


[価格](https://azure.microsoft.com/ja-jp/pricing/details/notification-hubs/)：Free、Basic、Standard 

プッシュ通知については[こちらの資料](https://abc.android-group.jp/2014w/wp-content/uploads/sites/2/2015/01/ABC2014w_Microsoft_Ota.pdf)がわかりやすい。

登場時(2013)のブログ
[1](https://azure.microsoft.com/ja-jp/blog/cross-post-broadcast-push-notifications-to-millions-of-mobile-devices-using-windows-azure-notification-hubs/)
[2](https://weblogs.asp.net/scottgu/broadcast-push-notifications-to-millions-of-mobile-devices-using-windows-azure-notification-hubs)

GitHubの[Notification Hubs関連リポジトリ](https://github.com/search?p=1&q=org%3AAzure+notification&type=Repositories)


# 名前空間とハブ

名前空間を作成し、その名前空間の中にハブを作成します。

[Notification Hubs のリソース構造について教えてください。](https://docs.microsoft.com/ja-jp/azure/notification-hubs/notification-hubs-push-notification-faq#what-is-the-resource-structure-of-notification-hubs)

Azure Notification Hubs には、2 つのリソース レベルとして、ハブと名前空間があります。 ハブは、1 つのアプリのクロスプラットフォーム プッシュ情報を保持できる単一のプッシュ リソースです。 名前空間は、1 つのリージョンのハブのコレクションです。 推奨されるマッピングでは、1 つの名前空間を 1 つのアプリに対応付けます。 その名前空間内に、運用アプリで動作する運用環境ハブ、テスト アプリで動作するテスト ハブなどを配置できます。


名前空間＞ハブ

名前空間レベルで課金


# 例


[クロスプラットフォーム通知を送信する例](https://docs.microsoft.com/ja-jp/azure/notification-hubs/notification-hubs-aspnet-cross-platform-notification)


`SendTemplateNotificationAsync`

```C#

public async Task<HttpResponseMessage> Post()
{
    var user = HttpContext.Current.User.Identity.Name;
    var userTag = "username:" + user;

    var notification = new Dictionary<string, string> { { "message", "Hello, " + user } };
    await Notifications.Instance.Hub.SendTemplateNotificationAsync(notification, userTag);

    return Request.CreateResponse(HttpStatusCode.OK);
}

```

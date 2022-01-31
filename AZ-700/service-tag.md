# サービスタグ

https://docs.microsoft.com/ja-jp/azure/virtual-network/service-tags-overview

Azure サービスの IP アドレス プレフィックスのグループ。

サービス タグに含まれるアドレス プレフィックスの管理は Microsoft が行う。

■使用例1

Azure Storage（ストレージアカウント）への接続（送信）を許可するNSG規則を作成。「Storage」

■使用例2

Windows Update へのアクセスを許可するNSGを規則を作成。「AzureUpdateDelivery」

■サービスタグが利用できる場所

- ネットワーク セキュリティ グループ
- Azure Firewall
- ユーザー定義のルート (UDR)
- オンプレミスのファイアウォール等
  - [Service Tag Discovery APIを使用して、IPアドレス範囲をJSONで取得できる](https://docs.microsoft.com/ja-jp/azure/virtual-network/service-tags-overview#service-tags-on-premises)

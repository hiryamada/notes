
# Azure Firewall

https://docs.microsoft.com/ja-jp/azure/networking/fundamentals/networking-overview#azure-firewall

https://docs.microsoft.com/ja-jp/azure/firewall/overview

[まとめ資料](https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod04/Azure%20Firewall.pdf)

2つの製品がある: Azure Firewall Standard と Azure Firewall Premium. Azure portalで作成する際に「Firewall tier」で「Standard」か「Premium」を選択。

■Azure Firewall Standard

2018/9/24 一般提供
https://azure.microsoft.com/ja-jp/updates/azure-firewall-generally-available/

- VNet内のリソースを保護するためのサービス
- マネージド サービス (Firewall as a Service)
  - 組み込みの高可用性
  - 無制限のスケーラビリティ
- ステートフルなファイアウォール(戻りのトラフィックを自動で許可)
- アプリケーションとネットワークの接続ポリシーを、サブスクリプションと仮想ネットワークをまたいで一元的に作成、適用、記録することができる

※Premiumが登場したことによって、初代の「Azure Firewall」は「Azure Firewall Standard」と呼ばれるようになった

■参考: Azure Filrewall Premium 

プレビュー (2021/2/16～):

- https://azure.microsoft.com/ja-jp/updates/azure-firewall-premium-now-in-public-preview/
- https://docs.microsoft.com/ja-jp/azure/firewall/premium-features
- https://www.ether-zone.com/azure-firewall-premium/

一般提供（2021/7/19～）
https://azure.microsoft.com/ja-jp/updates/announcing-the-azure-firewall-premium-general-availability/

特徴
- ファイアウォール ポリシー
  - このリリースからは、すべての新機能はファイアウォール ポリシーによってのみ構成
- TLSインスペクション（TLS検査）
  - アウトバウンド トラフィックを復号化し、データを処理し、その後にデータを暗号化して宛先に送信
  - Azure Firewallに中間CA証明書が必要
- シグネチャベースのIDPS（ネットワーク侵入検出と防止システム） 
  - ネットワーク トラフィック内のバイト シーケンスやマルウェアによって使用される既知の悪意のある命令シーケンスなど、特定のパターンを探すことによって攻撃を迅速に検出できる。
- URL フィルタリング
  - Azure Firewall の FQDN フィルタリング機能を拡張して URL 全体が考慮対象になるようにする。
- Web カテゴリ
  - 管理者は、ギャンブルの Web サイトやソーシャル メディアの Web サイトなどの Web サイト カテゴリへのユーザーのアクセスを許可または拒否できる。


# [Azure Firewall](https://docs.microsoft.com/ja-jp/azure/firewall/overview)

Azure Firewall は、クラウドネイティブのサービスとしてのファイアウォール (FWaaS) オファリング。

お客様のすべてのトラフィック フローを一元的に管理し、ログに記録することができます。

アプリケーションおよびネットワークの両レベルのフィルタリング規則がサポートされています。

Microsoft 脅威インテリジェンスのフィードと統合されていて、既知の悪意のある IP アドレスおよびドメインをフィルタリングすることができます。

参考: [Announcement Blob](https://azure.microsoft.com/ja-jp/blog/azure-firewall-and-network-virtual-appliances/)

# 脅威インテリジェンス

脅威インテリジェンス ベースのフィルタリングを有効にして、悪意のある既知の IP アドレスおよびドメインとの間のトラフィックをファイアウォールによって警告およびブロックできます。

IP アドレスとドメインの情報は Microsoft 脅威インテリジェンス フィードから取得され、最も信頼度の高いレコードのみが含まれます。

3 つの設定の中から選択できます。

- オフ - この機能はご使用のファイアウォールでは有効になりません。
- 警告のみ - 悪意のある既知の IP アドレスおよびドメインと通信するトラフィックがファイアウォールを通過すると、信頼度の高い警告を受信します
- 警告して拒否 - 悪意のある既知の IP アドレスおよびドメインと通信するトラフィックがファイアウォールを通過すると、トラフィックがブロックされ、信頼度の高い警告を受信します



# 送信元ネットワーク アドレス変換 (SNAT) 

仮想ネットワーク トラフィックから、インターネットへのアウトバウンドトラフィックでは、送信元 IP アドレスは Azure Firewall のパブリック IP アドレスに変換されます。 

# 宛先ネットワーク アドレス変換 (DNAT) 

インターネットから、ファイアウォールのパブリック IP アドレスへのインバウンド インターネット ネットワーク トラフィックでは、宛先IPアドレスは、仮想ネットワークのプライベート IP アドレスに変換されます。

# 複数のパブリックIPアドレスのサポート

最大250のパブリックIPアドレスをAzure Firewallに関連付けることができます。

SNATでは、SNATポートが不足される可能性が低くなります。

DNATでは、複数のIPアドレスで、同一のポートの着信をサポートできるようになります。

■Azure Firewallのコスト

|-|料金|
|-|-|
|デプロイメント|デプロイ時間あたり ￥140|
|データ処理|処理 GB あたり ￥1.792|

1ヶ月(730時間)稼働させると、約10万円～


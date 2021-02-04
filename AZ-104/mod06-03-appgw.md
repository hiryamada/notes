# Application Gateway


- [サービスのトップページ](https://azure.microsoft.com/ja-jp/services/application-gateway/)
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/application-gateway/)
- [Microsoft Learn ](https://docs.microsoft.com/ja-jp/learn/)
  - [AZ-104:Azure 管理者向けの仮想ネットワークの構成と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-virtual-networks/)
    - [Application Gateway で Web サービスのトラフィックを負荷分散する](https://docs.microsoft.com/ja-jp/learn/modules/load-balance-web-traffic-with-application-gateway/)
  - [Azure でネットワーク セキュリティを実装する](https://docs.microsoft.com/ja-jp/learn/paths/implement-network-security/)
    - [Azure Application Gateway を使用してネットワーク トラフィックをエンドツーエンドで暗号化する](https://docs.microsoft.com/ja-jp/learn/modules/end-to-end-encryption-with-app-gateway/)

[Load BalancerとApplication Gatewayの違い（Azureサポートチーム）](https://jpaztech1.z11.web.core.windows.net/LoadBalancer%E3%81%A8ApplicationGateway%E3%81%AE%E9%80%9A%E4%BF%A1%E3%81%AE%E9%81%95%E3%81%84.html)

# Application Gateway とは？

アプリケーションレイヤー(L7)のロードバランサー

サービスとしての[アプリケーション配信コントローラー](https://www.google.com/search?q=%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E9%85%8D%E4%BF%A1%E3%82%B3%E3%83%B3%E3%83%88%E3%83%AD%E3%83%BC%E3%83%A9%E3%83%BC)。

Web トラフィックのみ (HTTP、HTTPS、WebSocket、HTTP/2) に対して機能。

リージョン負荷分散サービス。

VNet内に作成。

# 機能

- 自動スケーリング
- TLS オフロード - SSL 証明書を管理し、暗号化されていないトラフィックをバックエンド サーバーに渡して、暗号化/暗号化の解除のオーバーヘッドを回避
- エンド ツー エンド TLS
- Web アプリケーション ファイアウォール (WAF)
- Cookie ベースのセッション アフィニティ（セッションの持続性）
- URL パスベースのルーティング
- マルチサイト ホスティング
- パスベースのルーティング
- 複数サイトのホスティング
- ラウンド ロビンによるトラフィックの負荷分散
- HTTP から HTTPS へ、または別のサイトへのリダイレクト
- ネットワーク セキュリティ グループ (NSG) をサポート
- ゾーン冗長性(Standard_v2)
- [Azure Web アプリケーション ファイアウォール](https://docs.microsoft.com/ja-jp/azure/web-application-firewall/overview) - 詳細な監視とログ記録を備えた高度なWAFをサポート
- HTTP ヘッダーの書き換え - 重要なセキュリティ シナリオを有効にするために、またはサーバー名などの機密情報を削除するために、各要求の受信および送信 HTTP ヘッダーの情報を追加または削除する
- カスタム エラー ページ

# 種類

- Application Gateway v1 (Standard および WAF) 
- Application Gateway v2 (Standard_v2 と WAF_v2) 

Standard, Standard_v2, WAF, WAF_v2の4つから選択。WAF, WAF_v2は、WAF付きのApplication Gateway。

# サブネットへのデプロイ

- 専用サブネットが必要
- 名前は特に決められていない。任意の名前を指定
- サブネット内に他のアプリケーション ゲートウェイをデプロイすることもできます
- アプリケーション ゲートウェイ サブネットに他のリソースをデプロイすることはできません。 
- 1 つのサブネットで v2 と v1 両方の Application Gateway SKU をサポートすることはできません。

# サブネットのサイズ

- Application Gateway (Standard または WAF) SKU では、最大 32 のインスタンス (32 のインスタンス IP アドレス + 1 つのプライベート フロントエンド IP + 5 つの予約済み Azure) をサポートできます。そのため、最小サブネット サイズは /26 をお勧めします。
- Application Gateway (Standard_v2 または WAF_v2) SKU では、最大 125 のインスタンス (125 のインスタンス IP アドレス + 1 つのプライベート フロントエンド IP + 5 つの予約済み Azure) をサポートできます。そのため、最小サブネット サイズは /24 をお勧めします。


# コンポーネント

[Microsoft Learnの図](https://docs.microsoft.com/ja-jp/learn/modules/load-balance-web-traffic-with-application-gateway/4-create-configure-application-gateway)

[ドキュメントの図](https://docs.microsoft.com/ja-jp/azure/application-gateway/configuration-overview)

- フロントエンド IP アドレス
- リスナー
- 要求ルーティング規則
- HTTP 設定
- バックエンド プール
- 正常性プローブ

# バックエンド プール（負荷分散先）

- Azure 仮想マシン
- Azure 仮想マシン スケール セット
- オンプレミス サーバー(IPアドレス/FQDN)
- Azure App Service

# 正常性プローブの送信元

https://docs.microsoft.com/ja-jp/azure/application-gateway/application-gateway-probe-overview

Application Gateway で正常性プローブに使用される発信元 IP アドレスは、バックエンド プールによって異なります。
- バックエンド プール内のサーバー アドレスがパブリック エンドポイントの場合、ソース アドレスはアプリケーション ゲートウェイのフロントエンド パブリック IP アドレスです。（注：今回のラボはこのパターン）
- バックエンド プール内のサーバー アドレスがプライベート エンドポイントの場合、ソース IP アドレスは Application Gateway サブネットのプライベート IP アドレス空間からのものです。


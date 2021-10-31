# ネットワーク セキュリティのソリューション

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/overview#networking

■ネットワークセキュリティグループ（NSG）

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

- 名前
- セキュリティ規則
  - 受信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...
  - 送信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...

「セキュリティ規則」のプロパティ (Azure portalの表示順):

- ソース - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- ソースポート範囲 - * 等
- 宛先 - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- サービス - HTTP等 (選択すると、プロトコルと宛先ポートが自動入力される)
- プロトコル Any / TCP / UDP / ICMP
- 宛先ポートの範囲 80 / 80-81 / 80,81 / 80,81-82 / * など
- アクション: 許可 / 拒否
- 優先度 100～4096, 小さいほど優先度が高い
- 名前: 作成後の変更は不可!!
- 説明

■ネットワーク仮想アプライアンス（NVA）


https://azure.microsoft.com/ja-jp/solutions/network-appliances/

Network Virtual Appliance（NVA）は、下記のような機能を提供するAzure VM。

- Web アプリケーション ファイアウォール (WAF)
- ファイアウォール
- ゲートウェイ/ルーター
- アプリケーション配信コントローラー (ADC)
- WAN オプティマイザー

製品ベンダー例: Barracuda, Check Point, Cisco, Citrix, F5, Fortinet, NetApp, Paloalto, Trend Microなど。

Azure Marketplaceからデプロイすることができる。

NVAは、VNetにデプロイされる。
https://docs.microsoft.com/ja-jp/learn/modules/control-network-traffic-flow-with-routes/

「カスタム ルート」を使用して、トラフィックがNVAを経由するように設定。

例: 
- VMから送信されるトラフィックをNVAでフィルタリングしてからインターネットに送信
- インターネットからのトラフィックをNVAでフィルタリングしてからVMに送信

■強制トンネリング

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm

- 検査および監査のために、インターネットへのすべてのトラフィックをオンプレミスに戻すようにリダイレクトする (つまり、"強制する") ことができる。
- 多くの企業において、 IT ポリシーの重要なセキュリティ要件
- ExpressRoute接続やVPN接続と、UDR（ユーザー定義ルート）を使用して、強制トンネリングを構成できる
  - UDR：ルートテーブルのこと。
  - 宛先 0.0.0.0/0 を、VNet Gatewayへと転送するように設定

わかりやすい解説:
https://www.syuheiuda.com/?p=3685

■Application Gateway

https://docs.microsoft.com/ja-jp/azure/application-gateway/overview

- Web アプリケーションに対するトラフィックを管理できる Web トラフィック ロード バランサー。
- [OSI レイヤー 7](https://ja.wikipedia.org/wiki/OSI%E5%8F%82%E7%85%A7%E3%83%A2%E3%83%87%E3%83%AB)で動作（HTTPとHTTPSをサポート）


**URLパス** や **ホスト ヘッダー** など、HTTP リクエストの属性に基づいてルーティングを決定することができる。

HTTPリクエストの例:

```
GET /index.php HTTP/1.1
Host: www.example.com
```

※1行目の「/index.php」が **URLパス** 。2行目の「Host: www.example.com」が **ホストヘッダー** 。

これらの値に基づいて、リクエストを（異なる）バックエンドへルーティングすることができる。

- [URLパスに基づくルーティング](https://docs.microsoft.com/ja-jp/azure/application-gateway/create-url-route-portal)
  - URLパスに基づき、異なるバックエンドへトラフィックをルーティングできる
    - 例
      - /video/* → videoBackendPool
      - /images/* → imageBackendPool
      - /* → appBackendPool
- [ホスト名に基づくルーティング](https://docs.microsoft.com/ja-jp/azure/application-gateway/create-multiple-sites-portal)
  - 異なるドメインの複数のWebサイトを1つのApplication Gatewayでホスティング可能

TLS(SSL)による暗号化通信に対応。

- [TLS終端(TLS termination)](https://docs.microsoft.com/ja-jp/azure/application-gateway/ssl-overview#tls-termination)
  - TLSセッションがApplication Gatewayで解除される
  - Application Gatewayからバックエンドの間では暗号化なし（HTTP）で通信。
  - バックエンドの負荷を削減できる
- [エンドツーエンドTLS暗号化](https://docs.microsoft.com/ja-jp/azure/application-gateway/ssl-overview#end-to-end-tls-encryption)
  - TLSセッションがApplication Gatewayでいったん解除され、ルーティングが行われる。バックエンドに要求が送られる際に別のTLSセッションを使用する。
  - 用途
    - セキュリティ要件、コンプライアンス要件により、エンドツーエンド暗号化が必要な場合
    - バックエンドがTLS通信しか受け付けない場合

TLS証明書は[Azure Key Vaultに格納することができる](https://docs.microsoft.com/ja-jp/azure/application-gateway/key-vault-certs)。


■ピアリング


https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview

- 2つのVNetの接続機能。
- 各VNet内部のVMなどは相互に通信が可能となる。
- リージョン内のVNetを接続することも、異なるリージョンのVNetを接続することもできる。
- トラフィックはMicrosoftのプライベートなネットワークを介してルーティングされる。
  - トラフィックの暗号化を行う必要がない。
- ピアリングの作成に際してダウンタイムは発生しない
- 別の Azure サブスクリプションに属するVNetともピアリングできる
- 別テナントの Azure サブスクリプションに属するVNetともピアリングできる

注意
- 2つのVNetが重複するアドレス空間を持つ場合はピアリングできない
- ピアリングの作成には料金はかからないが、ピアリング経由のデータ転送には料金がかかる。

ピアリングの種類:

- （ローカル）仮想ネットワークピアリング
  - リージョン内でのピアリング
  - 例: 東日本←→東日本
- グローバル仮想ネットワークピアリング
  - 異なるリージョン間でのピアリング
  - 例: 東日本←→西日本
  - Microsoftのバックボーンインフラストラクチャを使用

制限:
- グローバルピアリングを経由して、BasicロードバランサーのフロントエンドIP経由で、背後のリソースに接続することはできない。
- API Management等、内部的にBasicロードバランサーを使用している場合がある。
  - https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-faq#what-are-the-constraints-related-to-global-vnet-peering-and-load-balancers
- 制限を回避するためには、2つのVNetを、ピアリングではなく、VPNで接続する。

```
VNet1 東日本

↓ ピアリング

VNet2 西日本

フロントエンドIP
Basic LB
|   | 
VM  VM ... 東日本からフロントエンドIP経由ではつながらない
```

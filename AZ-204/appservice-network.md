# App Serviceのネットワーク

■VNetでのApp Service運用

https://docs.microsoft.com/ja-jp/azure/app-service/environment/overview

App ServiceをVNet内で運用したい場合は、「App Service Environments」を使用する。

[App Service Environmentについてのまとめ](mod01-ase.md)

■アクセスの制限

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restrictions

App Serviceに対する、特定のIPアドレスからの接続を許可・拒否したい場合は、「アクセスの制限」を使用する。

- 優先順位に従って評価される許可規則と拒否規則のリスト。
- 受信要求をフィルター処理する。

■サービスエンドポイント/プライベートエンドポイント

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#access-restriction-rules-based-on-service-endpoints

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#private-endpoint

特定のVNetの特定のサブネットからのみ、App Serviceへの接続を許可したい場合は、「サービスエンドポイント」 または 「プライベート エンドポイント」を使用する。

サービスエンドポイント:

```
         App Service
              ↑
VNet          |
└サブネット（サービスエンドポイント）
 └VM
```

プライベート エンドポイント:

```
          App Service
               ↑
VNet           |
└サブネット     |
 ├プライベートエンドポイント(NIC)
 └VM
```

いずれの場合でも、トラフィックはAzureの内部を通り、インターネットを経由しない。

参考: [まとめ資料: サービスエンドポイントとプライベートエンドポイント](../AZ-104/pdf/mod06/サービスエンドポイントvsプライベートエンドポイント.pdf)

■ハイブリッド接続

https://docs.microsoft.com/ja-jp/azure/app-service/networking-features#hybrid-connections

https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections

VPNや専用線（ExpressRoute）を使用せず、App Serviceから、オンプレミスのDB等にアクセスしたい場合、「ハイブリッド接続」を利用する。

```
App Service
 ↑   ↓ 
オンプレミスのファイアウォール
 ↑   ↓
オンプレミス Windows Server＋「ハイブリッド接続マネージャー」
     ↓
オンプレミスDB等
```

このとき、オンプレミス側のファイアウォールに「穴」を開ける必要はない。Azureへの接続は、ハイブリッド接続マネージャの側から、ポート443(HTTPS)を使用して行われる。この接続を利用して、App Serviceアプリは、オンプレミスのDB等へTCP接続することができる。

特徴:
- オンプレミスのシステムとサービスに簡単に接続できる
- UDPは使用できない

詳しくは[ハイブリット接続のメリット](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections#app-service-hybrid-connection-benefits)・[ハイブリット接続で実行できないこと](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-hybrid-connections#things-you-cannot-do-with-hybrid-connections)を参照。


■App Serviceのアドレス(FQDN)

たとえば example という名前のアプリをデプロイすると example.azurewebsites.net という名前のFQDNがアプリに割り当てられる。


■App Serviceの受信IPアドレス

https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-the-inbound-ip

オンプレミスから、App Serviceへのアクセスを許可する際に、App Serviceのアプリの受信IPアドレスを特定する必要がある。

```
App Service アプリ(a.b.c.d)
↑
オンプレミスのファイアウォール(a.b.c.dへの発信を許可)
↑
オンプレミスのコンピュータ
```

たとえば example という名前のアプリをデプロイした場合、そのIPアドレスは以下のようにして調べることができる。

```
nslookup example.azurewebsites.net
```

受信IPアドレスはアプリに対して1つだけである。

アプリを削除して、別のリソースグループにアプリを再作成するなどした場合に、アプリの受信IPアドレスが変わる場合がある。[詳細](https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#when-inbound-ip-changes)

■App Serviceの送信IPアドレス

App Serviceから、オンプレミスのコンピュータへのアクセスを許可する際に、App ServiceのアプリのIPアドレスを特定したい場合がある。

```
App Service アプリ(a.b.c.d)
↓
オンプレミスのファイアウォール(a.b.c.dへの着信を許可)
↓
オンプレミスのコンピュータ(DMZ)
```

送信IPアドレスは、アプリに対して複数割り当てされる。これらは、アプリの受信IPアドレスとは異なる。

https://docs.microsoft.com/ja-jp/azure/app-service/overview-inbound-outbound-ips#find-outbound-ips

以下のコマンドでアプリの送信IPアドレスを調べることができる。

```
az webapp show --query outboundIpAddresses 
```


# VNetインジェクション（AzureのリソースをVNet内にデプロイ）

2017/7/26 App Service Environment (ASE) 一般提供開始。仮想ネットワーク内に「App Service Environment」を作成。App Service アプリを高スケールで安全に実行するための、完全に分離された専用環境が提供される。App Service Environment 内のアプリでは、追加の構成を使用せずに、仮想ネットワーク内または仮想ネットワーク経由でリソースにアクセスできる。アプリの価格プランとしては「App Service Isolated 価格プラン」（I1/I2/I3）を利用。
https://azure.microsoft.com/en-gb/blog/announcing-app-service-isolated-more-power-scale-and-ease-of-use/

```
VNet
│ピアリング接続
VNet
├専用サブネット（名前は任意、/24以上を推奨）
│└App Service Environment
│  └App Serviceアプリ（I1/I2/I3）
├サブネット
│└VM
└GatewaySubnet
  └仮想ネットワークゲートウェイ
     │VPN or 専用線(ExpressRoute)
     オンプレミス
```

詳細
https://docs.microsoft.com/ja-jp/azure/app-service/environment/overview

※App Serviceでは「VNetインジェクション」という用語は使わないが、他のサービスでは「VNetインジェクション」と呼ぶ場合がある。

例: Azure Spring Apps （Azure Spring Cloud）
https://docs.microsoft.com/ja-jp/azure/spring-cloud/how-to-deploy-in-azure-virtual-network?tabs=azure-portal

Azure Spring Apps （Azure Spring Cloud）インスタンスを仮想ネットワークにデプロイする（VNet インジェクションとも呼ばれます。）

例: Azure Databricks
https://docs.microsoft.com/ja-jp/azure/databricks/administration-guide/cloud-configurations/azure/vnet-inject-upgrade

独自の Azure Virtual Network に Azure Databricks ワークスペースをデプロイする機能 ("VNet インジェクション" とも呼ばれる) 

参考: VNET インジェクションに対応するのサービス一覧
※VNET インジェクションに対応していないものは「マルチテナント」
https://cloudsteady.jp/post/8955/

# VNet統合

2020/2/27 一般提供開始。
https://azure.github.io/AppService/2020/02/27/General-Availability-of-VNet-Integration-with-Windows-Web-Apps.html

アプリは仮想ネットワーク内のリソースにアクセスしたり、仮想ネットワークを通じてリソースにアクセスしたりできます。 仮想ネットワーク統合では、アプリにプライベートでアクセスすることはできません。


```
VNet
|
VNet
├サブネット
│  └仮想NIC ← App Serviceアプリ
└サブネット
  └VM
```

詳細
https://docs.microsoft.com/ja-jp/azure/app-service/overview-vnet-integration

参考
https://tech-lab.sios.jp/archives/22563

> App Serviceはそのまんまだと仮想ネットワーク上のリソースにはアクセスできません。

> 仮想ネットワーク上にVNet統合用サブネットを用意します。そのサブネットを経由して、同じ仮想ネットワーク上にある他のサブネットや、Service Endpoint経由でAzure Database for MySQLなどのマネージドサービス、Express Route経由でオンプレミスのリソースにアクセスします。


# Azure App Serviceの「仮想ネットワーク統合」(vnet integration)

https://learn.microsoft.com/ja-jp/azure/app-service/overview-vnet-integration


■概要

App Service アプリが、(1)仮想ネットワーク内のリソースにアクセスしたり、(2)仮想ネットワークを通じてリソースにアクセスしたりできる

(1)仮想ネットワーク内のリソースにアクセスする例:
```
VNet
└サブネット
 └VM (DB等)
   ↑ アクセス
App Serviceアプリ
```

(2)仮想ネットワークを通じてリソースにアクセスする例:
```
リソース（ストレージアカウント等）
             ↑
VNet         ↑
└サブネット  ↑
 └プライベートエンドポイント
   ↑ アクセス
App Serviceアプリ
```

■「リージョン」仮想ネットワーク統合(regional virtual network integaration)

App Serviceアプリと同一リージョンの仮想ネットワークへのアクセスの場合は「ゲートウェイ」が不要（「リージョン仮想ネットワーク統合」）
https://learn.microsoft.com/ja-jp/azure/app-service/overview-vnet-integration#how-regional-virtual-network-integration-works


■「ゲートウェイが必要な」仮想ネットワーク統合(gateway-required virtual network integration)

App Serviceアプリと異なるリージョンの仮想ネットワークへのアクセスの場合は、仮想ネットワーク内に「Azure Virtual Network ゲートウェイ」（VPNゲートウェイ）が必要。

https://learn.microsoft.com/ja-jp/azure/app-service/overview-vnet-integration#gateway-required-virtual-network-integration

```
VNet
├サブネット
│ └VM (DB等) ←←←
└GatewaySubnet  ↑
  └Azure Virtual Network ゲートウェイ（VPNゲートウェイ）
   ↑ アクセス(P2S VPN接続)
App Serviceアプリ
```

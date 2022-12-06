# Azure ExpressRoute


接続プロバイダー（サービスプロバイダー）が提供するプライベート接続を介して、オンプレミスのネットワークを Microsoft クラウドに拡張するサービス。帯域保証型。

物理的な接続:
```
Azureデータセンター
|
ExpressRouteの「ロケーション」(東京、大阪等)
|
接続プロバイダー
| 専用線
オンプレ東京
```

リソース構成:

```
VNet
├サブネット
│└VM
└GatewaySubnet
 └仮想ネットワークゲートウェイ(type: ExpressRoute)
   | 接続
  ExpressRoute回線
```

[解説PDF: ExpressRoute まとめ](../AZ-500/pdf/mod2/ExpressRouteまとめ.pdf)

<!--
■さらに詳しい解説

→ [ExpressRoute](expressroute.md)

-->
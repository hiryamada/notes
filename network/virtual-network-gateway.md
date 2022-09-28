# 仮想ネットワークゲートウェイ

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpngateways#whatis

仮想ネットワークゲートウェイは、VNetで「VPN接続」または「専用線接続」(ExpressRoute)を利用するためのリソース。

■仮想ネットワークゲートウェイの種類

「VPNゲートウェイ」と「ExpressRouteゲートウェイ」がある。

```
仮想ネットワークゲートウェイ (virtual network gateway)
├VPNゲートウェイ (VPN gateway)
└ExpressRouteゲートウェイ (ExpressRoute gateway)
```

■仮想ネットワークゲートウェイのサブネット

仮想ネットワークゲートウェイは、「GatewaySubnet」という名前のサブネットにデプロイする必要がある。プレフィックスは/27以上（/26, /25）が推奨される。最小は/29（推奨されない）。

**ゲートウェイ サブネットにはネットワーク セキュリティ グループ (NSG) を関連付けない**。関連付けると正常な動作が妨げられる場合がある。https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-gateway-settings

VPNゲートウェイ:

```
VNet
└GatewaySubnet
  └VPNゲートウェイ - VPN - オンプレミス
```

ExpressRouteゲートウェイ:

```
VNet
└GatewaySubnet
  └ExpressRouteゲートウェイ - ExpressRoute - オンプレミス
```

■ExpressRoute（専用線）とVPNの組み合わせ

1つのVNetに、1つの「VPNゲートウェイ」と1つの「ExpressRouteゲートウェイ」を（一緒に）デプロイできる。

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/about-zone-redundant-vnet-gateways#can-i-deploy-both-vpn-and-express-route-gateways-in-same-virtual-network

> 同じ仮想ネットワーク内での VPN Gateway と Express Route ゲートウェイの共存がサポートされています。

https://learn.microsoft.com/ja-jp/azure/expressroute/expressroute-howto-coexist-resource-manager

> ExpressRoute のバックアップとしてサイト間 VPN 接続を構成することができます。

```
VNet
└GatewaySubnet
  ├ExpressRouteゲートウェイ - ExpressRoute - オンプレミス
  └VPNゲートウェイ - VPN - オンプレミス
```

※平常時はExpressRoute回線が優先で使用される。ExpressRoute回線に障害が発生した場合に、VPN（サイト間 VPN）にフォールオーバーされる。


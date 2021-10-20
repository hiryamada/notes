# ハイブリッド ネットワーク

■ExpressRoute

Azureの専用線接続。

[まとめPDF](../AZ-500/pdf/mod2/ExpressRouteまとめ.pdf)

■VPN

Azureの仮想専用線接続。

Site-to-Site(S2S)接続 (オンプレミスとの接続は「クロスプレミス接続」とも呼ばれる):

```
VNet
└GatewaySubnet
 └仮想ネットワークゲートウェイ（VPNゲートウェイ）
  |VPN接続(IPsecトンネル)
オンプレミス
```

Point-to-Site(P2S)接続:

```
VNet
└GatewaySubnet
 └仮想ネットワークゲートウェイ（VPNゲートウェイ）
  |VPN接続(OpenVPN/SSTP等)
クライアントPC
```

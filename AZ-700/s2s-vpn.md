# 仮想ネットワークゲートウェイ

- VPNゲートウェイとも。
- GatewaySubnetにデプロイされる

# ローカルネットワークゲートウェイ

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-site-to-site-portal#LocalNetworkGateway

- オンプレミスの場所 (サイト) を表すオブジェクト
- 接続を作成するオンプレミス VPN デバイスの IP アドレスを指定
- VPN ゲートウェイを介して VPN デバイスにルーティングされる IP アドレスのプレフィックスを指定

# 接続

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-site-to-site-portal#CreateConnection

仮想ネットワーク ゲートウェイとオンプレミス VPN デバイスとの間にサイト間 VPN 接続を作成

- ローカルネットワークゲートウェイ名
- 接続名
- 共有キー
  - 何を指定してもかまわないが、接続の両側で一致している必要がある
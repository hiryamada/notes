# S2S

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/design#s2smulti

Site-to-Site

サイト間

IPsec/IKE (IKEv1 または IKEv2) VPN トンネルを介した接続

# P2S

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-about

Point-to-Site

ポイント対サイト

個々のクライアント コンピューターから仮想ネットワークへの、セキュリティで保護された接続を作成

使用されるプロトコル:

- OpenVPN
  - SSL/TLSベース
  - Android, iOS, Windows, Linux, Macで使用可
- SSTP
  - TLSベース
  - Windowsでのみサポート
  - [パフォーマンス、スケーラビリティ、セキュリティを向上させるには、代わりに OpenVPN プロトコルの使用を検討してください。](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps)
- IKEv2 VPN 
  - Macで使用

# V2V

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/design#V2V

VNet-to-VNet

VNet間



# SSTP 

Secure Socket Tunneling Protocol

https://www.vpngate.net/ja/howto_sstp.aspx

https://www.proofpoint.com/jp/threat-reference/sstp

- Microsoft社によって開発された
- Windowsで利用可能なPPTPやL2TP/IPSecなどの安全でないオプションを置き換えるために、Microsoftはこの技術を開発
- WindowsのデフォルトのVPN接続は、ほとんどがSSTPを使用
- 背後にある技術はSSL/TLSハンドシェイクを利用
- Windows VistaにSSTP標準が導入され、Windows 7、8、10でも信頼できるセキュアなプロトコルとして存続

# カスタム IPSEC/IKE ポリシー

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-compliance-crypto#custom-ipsecike-policy-with-azure-vpn-gateways

Azure VPN ゲートウェイは、接続ごとのカスタム IPsec/IKE ポリシーをサポート

サイト間または VNet 間接続の場合、必要なキーの強度を備えた、IPsec および IKE の暗号化アルゴリズムの特定の組み合わせを選択

カスタム IPsec/IKE ポリシーは、Basic SKU を除くすべての Azure SKU でサポートされています。

ある特定の接続に対して指定できるポリシーの組み合わせは 1 つだけです。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-ipsecikepolicy-rm-powershell#s2sconnection

New-AzIpsecPolicy で作成

New-AzVirtualNetworkGatewayConnection で指定


# リセット

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/reset-gateway

仮想ネットワークゲートウェイと、接続を、リセットできる。


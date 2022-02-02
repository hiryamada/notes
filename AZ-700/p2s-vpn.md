# 認証

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-certificates-point-to-site

ポイント対サイト接続では、認証に証明書を使用します。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-vpn-client-install-azure-cert

P2S VPN ゲートウェイが証明書認証を要求するように構成されている場合、各クライアント コンピューターにはクライアント証明書がローカルにインストールされている必要があります。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/howto-point-to-site-multi-auth#type

仮想ネットワークゲートウェイで、認証とトンネルの種類を指定。

トンネルの種類として [OpenVPN (SSL)] を選択します。

[認証の種類] で、目的の種類を選択します。 オプション:

- Azure 証明書
- RADIUS
- Azure Active Directory

# 3つの認証方式

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps

P2S VPN 接続は、Windows デバイスと Mac デバイスから開始されます。 接続するクライアントでは、次の認証方法を使用できます。

- [OpenVPN - ネイティブ Azure Active Directory 認証 (Windows 10 のみ)](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/openvpn-azure-ad-tenant)
  - OpenVPNプロトコル使用時に、Azure AD認証が使用できる。
  - ユーザーが正常に接続するには、有効な Azure AD 資格情報が必要になる。
- [VPN Gateway のネイティブ証明書認証 (自己署名証明書を含む)](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-howto-point-to-site-rm-ps)
- [RADIUS サーバー](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps)

# OpenVPNとRADIUS

https://www.allied-telesis.co.jp/support/list/router/ar3050s_ar4050s/rel/5.4.6-2.2/613-002107_M/docs/overview-206.html

OpenVPNではクライアント認証にRADIUSサーバーを使用します。

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-how-to-radius-ps#5-add-the-radius-server-and-client-address-pool

ここの手順からするとOpenVPN以外にSSTPやIKEv2も使えそうだが・・・

# 自己署名証明書 (.pfx)

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-certificates-point-to-site


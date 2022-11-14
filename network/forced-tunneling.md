# 強制トンネリング (Forced Tunneling)

※おそらく、Azure独特の用語。

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm

- 検査および監査のために、インターネットへのすべてのトラフィックをオンプレミスに戻すようにリダイレクトする (つまり、"強制する") ことができる。
- 多くの企業において、 IT ポリシーの重要なセキュリティ要件

■強制トンネリングとは？

https://www.syuheiuda.com/?p=3685

> 全ての通信をオンプレ側に向ける設定

> デフォルト ルートをオンプレに向けてインターネットに直接出ていかないようにするということ

https://qiita.com/hidekko/items/c6da30484e3dda87e7b1

> Azure上のVMのDefault Gatewayをオンプレミスに向ける、これを日本語では強制トンネリング、英語ではForced Tunnelingと言います。

> 強制トンネリングでない通常の構成では、Azure上のVMはAzureから直接インターネットに接続しています。

> 強制トンネリングの構成では、Azure上のVMからのインターネット通信が一度オンプレミスのルーターに転送され、オンプレミスのルーターからインターネット接続する経路になります。

■強制トンネリングの必要性

https://qiita.com/hidekko/items/c6da30484e3dda87e7b1

> 例えば10拠点あるネットワーク環境を想定し、それぞれの拠点からインターネット接続を行っている場合を考えてみてください。同じネットワークポリシー、例えばQiitaには接続してもいいがFacebookは接続NG、のような接続先を絞るネットワークポリシーが存在する場合、10拠点バラバラでインターネット接続を行っていれば、ネットワークポリシー変更時に10台のネットワーク機器で同じ設定を行わなければなりません。(最近一元管理のサービスも出てきていますので一概には言えませんが・・・)これが1拠点のネットワーク機器から集約してインターネット接続を行っている環境であれば、1台のネットワーク機器の設定変更で済みます。設定変更漏れの危険性が低くなるというメリットが考えられます。

■VPN接続での強制トンネリング

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm#configuration-overview

- (方法1)VPN接続をBGPで行い、オンプレVPN機器から0.0.0.0/0を広報する（Azureサポートで推奨される方法）
  - https://www.michikusayan.com/entry/2019/06/02/023432
- (方法2)コマンド(Azure PowerShellの「[Set-AzVirtualNetworkGatewayDefaultSite](https://learn.microsoft.com/ja-jp/powershell/module/Az.Network/Set-AzVirtualNetworkGatewayDefaultSite?view=azps-8.3.0&viewFallbackFrom=azps-5.8.0)」)を使用する（Azureサポートで推奨される方法）
  - https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm#configure-forced-tunneling-1
- (方法3)UDR を使って、VNet 内のサブネットに対して、0.0.0.0/0 を GatewaySubnet に向けるルートを書く。
  - https://www.syuheiuda.com/?p=3685

■ExpressRoute接続での強制トンネリング

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm#requirements-and-considerations

https://www.syuheiuda.com/?p=3685

オンプレからデフォルト ルート (0.0.0.0/0) を広報する。（ExpressRoute BGP ピアリング セッションを介して、既定のルートを通知する.）

■参考: ExpressRoute接続 + 強制トンネリング で、ライセンス認証ができない事象について

KMS サーバーへのルーティングを設定する。

https://jpaztech1.z11.web.core.windows.net/ExpressRoute%E7%92%B0%E5%A2%83%E3%81%A7%E3%83%A9%E3%82%A4%E3%82%BB%E3%83%B3%E3%82%B9%E8%AA%8D%E8%A8%BC%E3%81%8C%E3%81%A7%E3%81%8D%E3%81%AA%E3%81%84%E4%BA%8B%E8%B1%A1%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6.html

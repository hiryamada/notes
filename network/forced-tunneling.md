# 強制トンネリング

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-forced-tunneling-rm


- 検査および監査のために、インターネットへのすべてのトラフィックをオンプレミスに戻すようにリダイレクトする (つまり、"強制する") ことができる。
- 多くの企業において、 IT ポリシーの重要なセキュリティ要件
- ExpressRoute接続やVPN接続と、UDR（ユーザー定義ルート）を使用して、強制トンネリングを構成できる
  - UDR：ルートテーブルのこと。
  - 宛先 0.0.0.0/0 を、VNet Gatewayへと転送するように設定

わかりやすい解説:
https://www.syuheiuda.com/?p=3685


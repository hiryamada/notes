# Virtual Network NAT

※VNet NAT, NAT Gatewayとも

※リソース名は「NATゲートウェイ」

■概要

VMから外部への接続に特化した専用サービス。送信元IPアドレスを固定できる。SNATポート枯渇を防止できる。

※SNATポート枯渇: アプリケーションが外部のサービスのエンドポイントと大量のコネクションを張った際に、SNAT ポート（送信元のポート）が不足して通信できなくなってしまうこと

VMにパブリックIPアドレスがない場合:
```
VNet
└サブネット
  └NIC → デフォルトのSNAT(可変のパブリックIPアドレス) → 外部サービス等
    └VM
```

- デフォルトのSNAT の パブリックIP は暗黙的であり、Microsoft に属している
- この IP アドレスは変更される可能性がある
- 実稼働ワークロードで、変更の可能性があるIPアドレスを使用することは推奨されていない

VMにパブリックIPアドレスがある場合:

```
VNet
└サブネット
  └NIC + パブリックIPアドレス → 外部サービス等
   └VM
```

- IPアドレスを固定できる

NAT Gatewayを導入した場合:
```
VNet
├サブネット
│  └NAT Gateway + IPアドレス+ポート → 外部サービス等
│           ↑
└サブネット ↑
  └NIC -    VM
```

参考: AzureのSNATオプション: https://jpaztech.github.io/blog/network/snat-options-for-azure-vm/

NAT Gatewayを利用するメリット:
- 送信元IPアドレスを固定できる
- NAT Gateway に追加できるパブリック IP アドレスの最大数は 16 個。
  - 1つの IPアドレスあたり、64000個のSNAT ポートを提供
  - 一つの NAT Gateway あたり、最大 64,000 * 16 = 1,024,000 ポートが SNAT ポートに使える。
  - SNATポート枯渇の問題が起きにくい。
- 外部接続の TCP アイドル タイムアウトを最大 120 分に伸ばせる。
  - アイドル: エンドポイントの間で長時間データが送信されないこと
  - タイムアウトになるとポートが閉じられる（別の接続でそのポートを利用できるようになる）
  - アイドル タイムアウト タイマーを長めに設定すると、SNAT ポート不足の可能性が高くなる
  - ※UDPは 4 分で固定。
- フルマネージドな PaaS サービスで、高い可用性を提供。
- Azure Firewall（のSNATの利用）よりも低コスト。

■公式サイト等

ドキュメント:
https://learn.microsoft.com/ja-jp/azure/virtual-network/nat-gateway/nat-overview

価格:
https://azure.microsoft.com/ja-jp/pricing/details/virtual-network/

- リソース時間 $0.045 / 時間
- 処理されたデータ $0.045/GB

NAT ゲートウェイを使用してパブリック IP アドレスを管理する
https://learn.microsoft.com/ja-jp/azure/virtual-network/ip-services/configure-public-ip-nat-gateway

Azure Virtual Network NAT (NAT ゲートウェイ) のトラブルシューティング
https://learn.microsoft.com/ja-jp/azure/virtual-network/nat-gateway/troubleshoot-nat

Azure Friday(動画) How to get better outbound connectivity using Azure NAT Gateway
https://www.youtube.com/watch?v=2Ng_uM0ZaB4

■報道記事等:

Azure仮想ネットワークの「NATゲートウェイ」が正式版に
https://atmarkit.itmedia.co.jp/ait/articles/2003/23/news012.html

■歴史

2020/2/18 Virtual Network NAT プレビュー
https://azure.microsoft.com/ja-jp/updates/natpreview/

2020/3/12 Virtual Network NAT 一般提供開始
https://azure.microsoft.com/ja-jp/updates/virtual-network-nat-now-generally-available/



■料金

https://azure.microsoft.com/ja-jp/pricing/details/virtual-network/

$0.045 / 時間、$0.045 /GB

時間料金は月換算で約2000円。https://www.google.com/search?q=0.024+*+24+*+30+%E3%83%89%E3%83%AB+%E5%86%86

他にパブリックIPアドレス/パブリックIPプレフィックスの料金も発生。

https://azure.microsoft.com/ja-jp/pricing/details/ip-addresses/

パブリックIPアドレス(standard)の場合 $0.005 / 時間


■NATゲートウェイとApp Serviceアプリの統合

2020/11/15

https://azure.github.io/AppService/2020/11/15/web-app-nat-gateway.html

https://blog.shibayan.jp/entry/20201119/1605754099


■Azure Functionsと組み合わせる

https://www.isoroot.jp/blog/3856/

■※参考: SNATのオプション

https://jpaztech.github.io/blog/network/snat-options-for-azure-vm/

規定の送信アクセス
https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/default-outbound-access

Azure Load Balancerのアウトバウンド規則
https://docs.microsoft.com/ja-jp/azure/load-balancer/outbound-rules

■参考: SNATポート枯渇問題

https://jpazpaas.github.io/blog/2021/09/29/app-service-snat.html

https://github.com/MicrosoftDocs/azure-docs.ja-jp/blob/master/articles/load-balancer/troubleshoot-outbound-connection.md

https://www.syuheiuda.com/?p=5074

https://qiita.com/oshimizu/items/52a68ba082f16dd5f957

https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-outbound-connections#4-default-outbound-access

https://it-rookieman.hatenablog.com/entry/2020/05/01/230547

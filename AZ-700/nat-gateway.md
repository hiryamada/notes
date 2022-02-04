# Virtual Network NAT 

※VNet NATとも

※リソースは「NATゲートウェイ」

2020/2/18 Virtual Network NAT プレビュー
https://azure.microsoft.com/ja-jp/updates/natpreview/

2020/3/12 Virtual Network NAT 一般提供開始
https://azure.microsoft.com/ja-jp/updates/virtual-network-nat-now-generally-available/


仮想ネットワークの送信専用(アウトバウンドのみ)のインターネット接続を簡素化

すべての送信接続で、仮想ネットワーク NAT に接続されているパブリック IP アドレスとパブリック IP プレフィックスのリソースの両方または一方を使用

送信接続は、ロードバランサーまたはパブリック IP アドレスを仮想マシンに直接接続せずに実行できます。

NAT は、仮想ネットワークの 1 つ以上のサブネットに対して構成できる

仮想マシンのオンデマンド接続を提供

事前割り当てなしでのインターネット接続へのオンデマンド送信 

フル マネージド、高い回復力(ソフトウェアによるネットワークを利用) 

スケーリング用の 1 つ以上の静的パブリック IP アドレス 

構成可能なアイドル タイムアウト 

認識されない接続に対する TCP リセット 

Azure Monitor の多次元メトリックとアラート 

可用性ゾーンにデプロイ可能（なし、ゾーン1，2, 3）※ゾーン冗長は選択不可

すべての Azure パブリック クラウド リージョンで使用できる

最大16個のIPアドレスを割り当て可能 https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/configure-public-ip-nat-gateway

サポートされるのは、TCP と UDP プロトコルのみです。 ICMP はサポートされていません。

Azure FirewallでもSNATが利用できるが、Firewallよりも低コスト。

■料金

https://azure.microsoft.com/ja-jp/pricing/details/virtual-network/

$0.045 / 時間、$0.045 /GB

時間料金は月換算で約2000円。https://www.google.com/search?q=0.024+*+24+*+30+%E3%83%89%E3%83%AB+%E5%86%86

他にパブリックIPアドレス/パブリックIPプレフィックスの料金も発生。

https://azure.microsoft.com/ja-jp/pricing/details/ip-addresses/

パブリックIPアドレス(standard)の場合 $0.005 / 時間

■NATゲートウェイ

サブネットに配置。

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

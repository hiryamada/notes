# ネットワーク セキュリティ グループ (NSG)

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

[2014/11/4 一般提供](https://azure.microsoft.com/ja-jp/blog/network-security-groups/)

[2018/1/9 拡張ルールが使えるようになった](https://azure.microsoft.com/ja-jp/updates/agumented-rules-ga-nsg/)

■ネットワークセキュリティグループの構造

- 名前
- セキュリティ規則
  - 受信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...
  - 送信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...

■「セキュリティ規則」のプロパティ (Azure portalの表示順)

- ソース - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- ソースポート範囲 - * 等
- 宛先 - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- サービス - HTTP等 (選択すると、プロトコルと宛先ポートが自動入力される)
- プロトコル Any / TCP / UDP / ICMP
- 宛先ポートの範囲 80 / 80-81 / 80,81 / 80,81-82 / * など
- アクション: 許可 / 拒否
- 優先度 100～4096, 小さいほど優先度が高い
- 名前: 作成後の変更は不可!!
- 説明

■受信セキュリティ規則のデフォルトの規則

- 65000 AllowVnetInBound
  - ソース: VirtualNetwork
  - 宛先: VirtualNetwork
- 65001 AllowAzureLoadBalancerInBound
  - ソース: AzureLoadBalancer
  - 宛先: 任意
- 65500 DenyAllInBound
  - ソース: 任意
  - 宛先: 任意

■送信セキュリティ規則のデフォルトの規則
- 65000 AllowVnetOutBound
  - ソース: VirtualNetwork
  - 宛先: VirtualNetwork
- 65001 AllowInternetOutBound
  - ソース: 任意
  - 宛先: Internet
- 65500 DenyAllOutBound
  - ソース: 任意
  - 宛先: 任意

■関連付け
- ネットワークインターフェース(NIC)
- サブネット

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-group-how-it-works#intra-subnet-traffic

> 特別な理由がない限り、ネットワーク セキュリティ グループをサブネット **または** ネットワーク インターフェイスに関連付けることをお勧めします。**両方に** 関連付けることは、お勧めしません。 サブネットに関連付けられたネットワーク セキュリティ グループの規則が、ネットワーク インターフェイスに関連付けられたネットワーク セキュリティ グループの規則と競合する可能性があるため、予期しない通信の問題が発生し、トラブルシューティングが必要になることがあります。

■受信トラフィックの規則の処理
- サブネットに関連付けられているNSGがあれば、まずその規則を処理
- 次にNICに関連付けられているNSGがあれば、その規則を処理
- ※サブネットにもNICにもNSGの関連付けがない場合は、トラフィックはすべて許可される

■送信トラフィックの規則の処理
- NICに関連付けられているNSGがあれば、その規則を処理
- 次にサブネットに関連付けられているNSGがあれば、その規則を処理
- ※NICにもサブネットにもNSGの関連付けがない場合は、トラフィックはすべて許可される

■サブネット内のトラフィック
- サブネットに関連付けたNSGのセキュリティ規則は、サブネットの内部にあるVM間の接続に影響する。
- 例: SSH接続を拒否するルールを持つNSGをサブネットに関連付ける
  - サブネットの外からサブネットの中のVMにSSH接続ができなくなる。
  - **サブネット内での** 、あるVMから別のVMへのSSH接続もできなくなる。

# サービス タグ

https://docs.microsoft.com/ja-jp/azure/virtual-network/service-tags-overview

[2018/1/15 サービスタグが使えるようになった](https://azure.microsoft.com/ja-jp/updates/service-tags-nsgs-ga/)


- AzureサービスのIPアドレス プレフィックスのグループ
- NSG, Azure Firewall, ユーザー定義ルートで使用できる
- 例
  - AppService (WebアプリとFunctions)
  - AzureCosmosDB
  - AzureBackup
  - Storage - Azure Storage （特定のストレージアカウントは表さない）
  - Sql - SQL Database等（特定のインスタンスは表さない）
  - AzureCloud - すべてのデータセンター パブリック IP アドレス
  - Internet
  - VirtualNetwork


# アプリケーション セキュリティ グループ (ASG)

[2018/3/30 一般提供](https://azure.microsoft.com/ja-jp/updates/applicationsecuritygroupsga/)

ASG を使用すると、明示的な IP アドレスではなく、ワークロード、アプリケーション、または環境に基づいてきめ細やかなネットワーク セキュリティ ポリシーを定義できる。

[ドキュメント（概要）](https://docs.microsoft.com/ja-jp/azure/virtual-network/application-security-groups)

[ドキュメント（作成方法）](https://docs.microsoft.com/ja-jp/azure/virtual-network/tutorial-filter-network-traffic#create-application-security-groups)

アプリケーション セキュリティ グループを使用すると、Web サーバーなど、同様の機能を持つサーバーをグループ化できる。

仮想マシンをグループ化して、それらのグループに基づくネットワーク セキュリティ ポリシーを定義できる。

# [メリット](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview#application-security-groups)

- NSGに具体的なIPアドレスを書く必要がなくなる。
- NSGの数を減らせる。

# ASGの作成

サブスクリプションとリソースグループの下につくる（普通のリソース）。

名前、サブスクリプション、リソースグループ、場所（リージョン）を指定して作成。

作成時点では特に関連付けなどは指定しない。

# NICとの関連付け

[ネットワークインターフェースをASGに関連付けすることができます。](https://docs.microsoft.com/ja-jp/azure/virtual-network/tutorial-filter-network-traffic#associate-network-interfaces-to-an-asg)

VM＞ネットワーク＞ASG で、ASGを選択。

ネットワーク インターフェイスは[複数のアプリケーション セキュリティ グループのメンバーにすることができる](https://docs.microsoft.com/ja-jp/azure/virtual-network/application-security-groups)。


# NSGの宛先でのASG指定

[NSGの「セキュリティ規則」の「ソース」または「宛先」に、ASGを指定できる。](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview#security-rules)

[1つの規則内で複数のASGを指定することはできない。](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview#security-rules)

[実際の設定例](https://docs.microsoft.com/ja-jp/azure/virtual-network/tutorial-filter-network-traffic#create-security-rules)

# 制約等

セキュリティ規則のソースおよび宛先として、1 つのアプリケーション セキュリティ グループを指定できる。 

送信元と送信先に複数のアプリケーション セキュリティ グループを指定することはできない。

All network interfaces assigned to an application security group have to exist in the same virtual network that the first network interface assigned to the application security group is in. (ASGに割り当てられたすべてのNICは、ASGに割り当てられた最初のNICと同じVNetに存在する必要があります)

※たとえば、あたらしいASGをつくり、VNet1のNIC1に関連付けたとする。続いて、NIC2を同じASGに関連付ける場合、NIC2はVNet1に存在しなければならない。ASG作成時点では、ASGそのものには「どのVNetのASG」といった情報は指定しないが、ASGに複数NICを含める場合、それらは全部同じVNetになければならない。ということ。

セキュリティ規則のソースおよび宛先としてアプリケーション セキュリティ グループを指定する場合、両方のアプリケーション セキュリティ グループのネットワーク インターフェイスが、同じ仮想ネットワークに存在している必要がある。 



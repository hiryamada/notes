
# ネットワークセキュリティグループ（NSG）

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

■ネットワークセキュリティグループの構造
- 名前
- セキュリティ規則
  - 受信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...
  - 送信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...

■各規則のプロパティ (Azure portalの表示順)
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
    - サブネット内で、あるVMから別のVMへのSSH接続もできなくなる。

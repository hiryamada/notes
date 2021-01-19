
# ネットワークセキュリティグループ（NSG）

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview)

[Azure Network Security Group(NSG) はじめてのDeep Dive](https://www.slideshare.net/ssusere44d0e1/azure-network-security-groupnsg-deep-dive-152300192)

Azure 仮想ネットワーク内の Azure リソースが送受信するネットワーク トラフィックは、Azure ネットワーク セキュリティ グループを使ってフィルター処理できます。

NSGには0個以上のセキュリティ規則が含まれています。セキュリティ規則は、優先順位に従って処理され、数値が小さいほど優先順位が高くなります。トラフィックが規則に一致すると、処理が停止します。規則のアクションは、許可または拒否です。

ネットワーク セキュリティ グループはステートフルな処理を行います。たとえば、ポート 80 経由で任意のアドレスに送信セキュリティ規則を指定した場合、送信トラフィックへの応答に受信セキュリティ規則を指定する必要はありません。

# アプリケーションセキュリティグループ (ASG)

[AZ-500のノート](../AZ-500/mod02-02-02-asg.md)
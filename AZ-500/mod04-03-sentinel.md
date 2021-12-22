# Azure Sentinel

クラウドネイティブ型の セキュリティ情報イベント管理 (SIEM) および セキュリティ オーケストレーション自動応答 (SOAR) ソリューション

※[sentinel(センチネル) = 歩哨、哨兵、番人、見張り、監視員、番兵](https://ja.wikipedia.org/wiki/%E3%82%BB%E3%83%B3%E3%83%81%E3%83%8D%E3%83%AB)

[製品ページ](https://azure.microsoft.com/ja-jp/services/azure-sentinel/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/azure-sentinel/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/sentinel/overview)

[マイクロソフトだからできる、IaaS, PaaS, SaaSとオンプレのセキュリティをまるっと監視・管理！ - Azure Security Center と Azure Sentinel](https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RE44nRw)


[もうセキュリティはやりたくない!! 第 3 弾～Azure Sentinel Deep Dive～](https://www.microsoft.com/cms/api/am/binary/RE4siMM)

[Microsoft Digital Trust Summit 2019](https://www.microsoft.com/ja-jp/biz/security/summit-online.aspx)

https://github.com/Azure/Azure-Sentinel

https://microsoft.github.io/AzureTipsAndTricks/blog/tip241.html

[Become an Azure Sentinel Ninja: The complete level 400 training](https://techcommunity.microsoft.com/t5/azure-sentinel/become-an-azure-sentinel-ninja-the-complete-level-400-training/ba-p/1246310)

# Microsoft Defender for Cloud と Azure Sentinelの関係

https://azure.microsoft.com/ja-jp/blog/securing-the-hybrid-cloud-with-azure-security-center-and-azure-sentinel/

Azure Sentinel は、脅威からの保護に関する情報を多数のデータ ソースから収集し、組織全体を把握できるようにします。Security Center はそのソースの 1 つです。

Microsoft Defender for Cloud は、わずか数クリックで Azure Sentinel に接続できます。

Azure Sentinel から Microsoft Defender for Cloud のデータにアクセスできるようになったら、ファイアウォール、ユーザー、デバイスなどの他のソースと組み合わせて、高度なクエリや人工知能によるプロアクティブな捜索や脅威の軽減が可能になります。

# Azure Monitor Log Analyticsとの関係

Azure Sentinel では、企業全体にわたってインテリジェントなセキュリティ分析が提供されます。この分析のデータは Azure Monitor Log Analytics ワークスペースに保存されます。

# 価格

Azure Sentinel では、Azure Sentinel での分析用に取り込まれるデータおよび Azure Monitor Log Analytics ワークスペースに保存されるデータの量に基づいて課金されます。

Azure Sentinel では、予測可能な柔軟性のある価格モデルが提供されます。Azure Sentinel サービスには次の 2 つのお支払い方法が用意されています:

- **容量予約**: 選択したサービス レベルに基づいて固定の料金が課金されるため、Azure Sentinel に対する総コストを予測することができます。容量予約では、従量課金制の価格と比較して、選択した容量予約に基づいて、コストに割引 (最大 60%) が提供されます。

- **従量課金制**: 分析のために Azure Sentinel に取り込まれたデータ、および Azure Monitor Log Analytics ワークスペースに保存されたデータの量に応じてギガバイト (GB) ごとに課金されます。

例: 
- 容量予約で100GB/日を選択すると $145/日
- 1日の容量予約を超えた場合は追加データについては従量課金制で計算され $2.9/GB

1日50GBを超える取り込みを行う場合は容量予約を使ったほうがお得。

Azure Sentinel は、最初の 31 日間は追加費用なしで Azure Monitor Log Analytics ワークスペース上で有効化できます。

# 用語

Sentinel
- ワークスペース
- データソース
  - Microsoft Defender for Cloud
  - Aaure AD
  - Office 365
  - AWS
  - CybarArk
- コネクタ
- イベントとアラート
- [アラートをインシデントに対応付ける](https://docs.microsoft.com/ja-jp/azure/sentinel/quickstart-get-visibility?WT.mc_id=docs-azuredevtips-azureappsdev)
- [インシデントの調査とクローズ](https://docs.microsoft.com/ja-jp/azure/sentinel/tutorial-investigate-cases?WT.mc_id=docs-azuredevtips-azureappsdev#closing-an-incident)
- [ワークフロー](https://docs.microsoft.com/ja-jp/azure/sentinel/tutorial-respond-threats-playbook): 脅威への自動対応
- [プレイブック](https://docs.microsoft.com/ja-jp/azure/sentinel/tutorial-respond-threats-playbook?WT.mc_id=docs-azuredevtips-azureappsdev): 脅威への対応



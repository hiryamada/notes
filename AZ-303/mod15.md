# Module 15 クラウド インフラストラクチャ監視の実装

■参考: インフラの監視

※Microsoft自身が、Azureのデータセンターなどのインフラをどのように監視・保護・運用しているかについて。

- [Azure インフラストラクチャの監視(Azureドキュメント)](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/infrastructure-monitoring)

■参考: Azureのグローバルインフラストラクチャー

https://azure.microsoft.com/ja-jp/global-infrastructure/

インタラクティブデモ
https://infrastructuremap.microsoft.com/

操作例
- Skip Intro
- Explore the globe
- 地球儀を回して日本を表示する
- マウスホイールで拡大・縮小
- 東日本リージョンをクリック

■参考: Azureのデータセンター

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/physical-security

バーチャルツアー
https://news.microsoft.com/stories/microsoft-datacenter-tour/

操作例
- Start Exploring
- Enter The Lobby
- Explore Lobby
- Enter Server Room
- Explore Server Room
- Server Blades

■監視（モニタリング）

- [Azure Monitor](mod15-01-monitor.md)
  - Log Analytics
  - Azure Application Insights

■仮想ネットワークの監視・診断

- [Network Watcher](mod15-02-network-watcher.md)

■Azure Advisor

信頼性、セキュリティ、パフォーマンス、コスト、オペレーショナル エクセレンス（効率性、ベストプラクティスへの準拠など）の5つの観点から、利用状況を分析し、推奨事項を表示。

- [Azure Advisor(Azureドキュメント)](https://docs.microsoft.com/ja-jp/azure/advisor/advisor-overview)

■クラウド リソースの正常性の監視

- [Azure Service Health(Azureドキュメント)](https://docs.microsoft.com/ja-jp/azure/service-health/overview)
  - Azureの状態
    - Azure サービスの停止に関する情報
  - Service Health
    - 使用している Azure サービスとリージョンの正常性についてのビュー
  - Resource Health
    - 特定の仮想マシン インスタンスなど、個々のクラウド リソースの正常性に関する情報

■セキュリティ

- [Microsoft Defender for Cloud]
  - [まとめPDF](../AZ-500/pdf/mod4/Microsoft%20Defender%20for%20Cloud%20まとめ.pdf)
- Microsoft Sentinel
  - [まとめPDF](../AZ-500/pdf/mod4/Azure%20Sentinel%20まとめ.pdf)

■コスト

- コストの分析
  - [Azure Cost Management](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/cost-management-billing-overview)
- コストの計算
  - [Azure Cost Calculator](https://azure.microsoft.com/ja-jp/pricing/calculator/)
  - [TCO Calculator](https://azure.microsoft.com/ja-jp/pricing/tco/calculator/)
- コストを削減する方法
  - リージョンの選択（リージョンによってコストが変わる）
  - [Azure Advisorの「コスト最適化」](https://docs.microsoft.com/ja-jp/azure/advisor/advisor-cost-recommendations)
  - [Azureの予約](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations)
  - VM
    - [VMを停止する](https://docs.microsoft.com/ja-jp/azure/virtual-machines/states-billing)
      - [VMの自動起動・自動停止](https://docs.microsoft.com/ja-jp/azure/automation/automation-solution-vm-management)
    - [スポットVM](https://azure.microsoft.com/ja-jp/services/virtual-machines/spot/#overview)
  - VM（Windows, RedHat, Suse）とSQL Server
    - [ハイブリッド特典](https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/)


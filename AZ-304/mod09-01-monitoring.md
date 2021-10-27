# Azureの監視の概要

■アプリケーションの監視

Application Insights
https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview

■コンテナーの監視

Azure MonitorのContainer insights
https://docs.microsoft.com/ja-jp/azure/azure-monitor/containers/container-insights-overview

2018/12/11 Azure Monitor for containers (別名「Container Insights」) 一般提供開始.
https://azure.microsoft.com/ja-jp/blog/azure-monitor-for-containers-now-generally-available/

わかりやすい解説(Microsoftにてコンテナ監視の製品Log Analytics Container Monitor Solutionを立ち上げたKeiko Haradaさん)
https://qiita.com/keikhara/items/8699d8e1fa45f2e61185#ga%E4%B8%80%E8%88%AC%E6%8F%90%E4%BE%9B%E9%96%8B%E5%A7%8B%E3%81%9D%E3%81%97%E3%81%A6

■ネットワークの監視

Network Watcher
https://docs.microsoft.com/ja-jp/azure/network-watcher/network-watcher-monitoring-overview

■運用管理のベストプラクティス

- ダッシュボードを使用する
  - https://docs.microsoft.com/ja-jp/azure/azure-portal/azure-portal-dashboards
- アラートと通知を利用する
  - https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/alerts-overview
- サブスクリプションの制限(使用量とクォータ)を確認する
  - https://jpazasms.github.io/blog/AzureSubscriptionManagement/20180910a/
- サポートプランを活用する
  - https://azure.microsoft.com/ja-jp/support/plans/
  - https://docs.microsoft.com/ja-jp/azure/azure-portal/supportability/how-to-create-azure-support-request
- 証明書の有効期限が切れないようにする(Azure Key Vaultの証明書の更新を利用する)
  - https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/overview-renew-certificate

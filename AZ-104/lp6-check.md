知識チェック

# ラーニングパス 6: [AZ-104:Azure リソースの監視とバックアップ](https://docs.microsoft.com/ja-jp/learn/paths/az-104-monitor-backup-resources/)
## モジュール 1: [ファイルとフォルダーのバックアップを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-file-folder-backups/)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-file-folder-backups/7-knowledge-check)
  - 問題1/2 バックアップデータはRecovery Servicesコンテナーに格納されるので、まずそれを作成する。Recovery Servicesコンテナーの画面内から、エージェントや資格情報をダウンロードできる。
  - 問題3 Azure Backupでは、無制限のデータ転送が可能。転送するインバウンド データまたはアウトバウンド データの量に制限がなく、転送されるデータに料金かからない。
## モジュール 2: [仮想マシンのバックアップを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-backups/)
- ユニット 11: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-backups/11-knowledge-check)
  - 問題1 Azure Backupで、Windows VM / Linux VMをバックアップできる。
  - 問題2 [ディスクだけのバックアップでは、スナップショットを使用する。](https://docs.microsoft.com/ja-jp/azure/backup/disk-backup-overview)
  - 問題3 [論理的な削除では、削除されたデータは14日間保持される。](https://docs.microsoft.com/ja-jp/azure/backup/backup-azure-security-feature-cloud)
## モジュール 3: [Azure Monitor を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-monitor/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-monitor/8-knowledge-check)
  - 問題1 [アクティビティログの「管理」カテゴリ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/activity-log-schema#categories)に、リソースの作成・削除などが記録される。
  - 問題2 [「アクティビティログ」「リソースログ」「仮想マシンのゲストOSのログ」など。](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/monitor-azure-resource#monitoring-data-from-azure-resources)
  - 問題3 [アクティビティログは90日間保存されたあと、削除される。](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/activity-log#retention-period)。診断設定を使用するとより長期間のログを記録できる。
## モジュール 4: [Azure アラートを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-alerts/)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-alerts/5-knowledge-check)
  - 問題1 [アラートの状態：「新規」「確認済み（正解）」「クローズ」](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/alerts-overview#manage-alerts)
  - 問題2 「[アクショングループ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/action-groups)」を作成する。アクショングループには、複数の「通知」「アクション」が含まれる。
  - 問題3 [アラートの構成](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/alerts-overview#overview)：リソース、条件、アクションなど
## モジュール 5: [Log Analytics の構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-log-analytics/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-log-analytics/6-knowledge-check)
  - 問題1 Azure Monitorのログデータ（KQLで検索するもの）は、「[テーブル](https://docs.microsoft.com/ja-jp/azure/data-explorer/kusto/query/#what-is-a-query-statement)」に格納される。
  - 問題2 エージェントからは1分に1回「[ハートビート](https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/data-ingestion-time#resources-that-stop-responding)」が送信される。[Azure 仮想マシンの利用不可状態を検出するために使用できる。](https://docs.microsoft.com/ja-jp/azure/azure-monitor/vm/tutorial-monitor-vm-alert)
  - 問題3 Log Analytics エージェントは他クラウドやオンプレミスを含むさまざまな環境にインストールできる。
## モジュール 6: [Network Watcher を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-watcher/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-network-watcher/6-knowledge-check)
  - 問題1 
  - 問題2 
  - 問題3 
## モジュール 7: [Azure のアラートを使用したインシデント対応の向上](https://docs.microsoft.com/ja-jp/learn/modules/incident-response-with-alerting-on-azure/)
- ユニット 2: [Azure Monitor でサポートされるさまざまなアラートの種類を確認する](https://docs.microsoft.com/ja-jp/learn/modules/incident-response-with-alerting-on-azure/2-explore-azure-monitor-alert-types)
  - ※ページ下部に知識チェックあり
  - 問題1 
  - 問題2 
  - 問題3 
## モジュール 8: [Azure Monitor ログを使用して Azure インフラストラクチャを分析する](https://docs.microsoft.com/ja-jp/learn/modules/analyze-infrastructure-with-azure-monitor-logs/)
- ユニット 2: [Azure Monitor ログの特徴](https://docs.microsoft.com/ja-jp/learn/modules/analyze-infrastructure-with-azure-monitor-logs/2-features-azure-monitor-log)
  - ※ページ下部に知識チェックあり
  - 問題1 
  - 問題2 
  - 問題3 
## モジュール 9: [Azure Monitor VM Insights を使用して仮想マシンのパフォーマンスを監視する](https://docs.microsoft.com/ja-jp/learn/modules/monitor-performance-using-azure-monitor-for-vms/)
- ユニット 2: [Azure Monitor ログと Azure Monitor VM Insights とは](https://docs.microsoft.com/ja-jp/learn/modules/monitor-performance-using-azure-monitor-for-vms/2-what-are-azure-monitor-logs-vms)
  - ※ページ下部に知識チェックあり
  - 問題1 
  - 問題2 
  - 問題3 

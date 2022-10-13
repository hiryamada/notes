# Azure Automation Update Management

https://learn.microsoft.com/ja-jp/azure/automation/update-management/overview

- Azure Automationの「更新」管理サービス。
- Windows / Linux のOS更新プログラムを管理
- Azure、その他クラウド（AWS/GCP等）、オンプレミス環境の物理マシン・VMがターゲット。


■更新プログラムの監視

https://learn.microsoft.com/ja-jp/azure/automation/update-management/overview#about-update-management

- 「Automation アカウント」と 「Log Analytics ワークスペース」をリンクしておく。
- ターゲットのマシン上に「Log Analytics エージェント」をインストールする。
- 「Log Analytics エージェント」は、各マシンの、更新プログラムのインストール状況を調べ、「Log Analytics ワークスペース」にログを書き込む（報告）。

■更新プログラムのデプロイ

https://learn.microsoft.com/ja-jp/azure/automation/update-management/overview#about-update-management

- デプロイ対象の「コンピューター グループ」を選択
  - サブスクリプション、リソースグループ、場所（リージョン）、タグに基づく選択が可能
  - https://learn.microsoft.com/ja-jp/azure/automation/update-management/plan-deployment#step-9---plan-deployment-targets
- デプロイのスケジュールを作成
- 更新プログラムは、Azure Automation の Runbook によってインストールされる
- 更新プログラム適用後に再起動が必要な場合は、再起動も実行される

■更新プログラムの分類

https://learn.microsoft.com/ja-jp/azure/automation/update-management/overview#update-classifications


分類（主なもの）:

- 緊急更新プログラム
- セキュリティ更新プログラム
- Feature Pack
- Service Pack

特定の「分類」に一致する更新プログラムのみインストールするように構成・スケジュールできる。


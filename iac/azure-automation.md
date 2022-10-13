# Azure Automation

Azure 環境と非 Azure 環境(AWS, GCP, オンプレミス等)を管理するクラウドベースの自動化・構成サービス。

製品ページ
https://azure.microsoft.com/ja-jp/products/automation/

ドキュメント
https://learn.microsoft.com/ja-jp/azure/automation/overview

価格
https://azure.microsoft.com/ja-jp/pricing/details/automation/

■Azure Automationでできること

https://learn.microsoft.com/ja-jp/azure/automation/overview#common-scenarios

- タスクの自動化、スケジュール実行
  - 仮想マシン (VM) の起動と停止
  - 古いデータの削除、SQL データベースのインデックスの再作成などを実行
  - VMのディスクのスナップショットの取得、古いスナップショットの削除
  - 任意のPython / PowerShellスクリプトの実行
- インベントリ（リソース一覧）の取得
- 変更の検出 - 構成エラーを引き起こす可能性があるマシン変更を検出、修復
- Windows と Linux のOS更新プログラムを管理

■Automation アカウント

https://learn.microsoft.com/ja-jp/azure/automation/quickstarts/create-azure-automation-account-portal

Azure Automation を使用するには、少なくとも 1 つの Azure Automation アカウントが必要。

基本的に1つあればよいが、環境（本番環境、開発環境等）ごとにAutomation アカウントを分けるといった運用もできる。

■Runbook (プロセスの自動化)

→ [Azure Automation の Runbook](azure-automation-runbook.md)

■Azure Automation State Configuration (構成管理)

→ [Azure Automation State Configuration](azure-automation-state-configuration.md)

■Azure Automation Update Management (更新管理)

→ [Azure Automation Update Management](azure-automation-update-management.md)

■共有機能

https://learn.microsoft.com/ja-jp/azure/automation/overview#shared-capabilities

環境を大規模かつ容易に自動化して構成するための、一連の共有リソースの管理機能。

- [スケジュール](https://learn.microsoft.com/ja-jp/azure/automation/shared-resources/schedules)
  - Runbookの実行のスケジュール構成
- モジュール
  - Automation アカウントで、PowerShell モジュールをインポートして管理
- 資格情報
  - ユーザー名とパスワードなどのセキュリティ資格情報を含むオブジェクトを保持
  - 認証を必要とする一部のアプリケーションまたはサービスに提供
- 接続
  - ユーザー名やパスワード、URL やポートなど、外部サービスやアプリに接続するための情報を保持
- 証明書
  - 認証に証明書を使用する Runbook および DSC 構成を作成
- 変数
  - Runbook と構成間で使用できるコンテンツを保持

■マネージドIDの利用

Azure Automation実行アカウントは 2023 年 9 月 30 日に廃止され、マネージド ID に置き換えられる。
https://learn.microsoft.com/ja-jp/azure/automation/whats-new#support-for-run-as-accounts


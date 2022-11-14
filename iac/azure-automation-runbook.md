# Azure Automation の Runbook （プロセスの自動化）

https://learn.microsoft.com/ja-jp/azure/automation/automation-runbook-execution

■（一般的に）Runbook（ランブック） とは?

作業指示書、作業手順書、問題の対処法を記載したもの。人手で実行する場合と、自動的に実行する場合がある。

https://kn.itmedia.co.jp/kn/articles/1602/16/news153.html

> ランブックとは、作業指示書や作業手順書のことを指す。

> ランブックオートメーションとはその名の通り、システム運用管理の作業手順書に記述された一連の作業をオートメーション化（プログラムによる自動実行）しようというものだ。

https://zenn.dev/panyoriokome/scraps/18e0ce0edd7e27

> Runbookは日々の運用等で頻繁に起こったりする問題に対して詳細な対処法を記載したもの。

■Azure Automation の Runbookの特徴

- 自動化のためのスクリプト
  - オプションでパラメーターを指定することができる。
- Azure Portal上で作成・編集できる
  - テスト実行ができる。
  - 作成が完了したら「発行」する
- ソースは以下で管理できる。
  - GitHub
  - Azure DevOps（Azure ReposのGitリポジトリ）
  - TFVC（Team Foundation Version Control）
- 「Runbookギャラリー」から、すぐに使えるRunbookを探してインポートすることができる
  - 特定のタグが付いたVMを起動・停止する
  - VMをスケーリング（サイズ変更）する
  - App Service Planをスケーリングする
  - 古いBlobを削除する
  - 空のリソースグループを削除する
  - SQLコマンドを実行する
  - hello world (example)

■実行の方法

- 手動で実行
- スケジュールを指定して実行（1回、または繰り返し）
- Webhookからの実行

■Runbook の形式

テキスト形式 - テキストエディターで編集
- Python 2/3
  - Python スクリプト(+ Azure Python SDK)に基づくテキスト形式の Runbook
- PowerShell
  - Windows PowerShell スクリプトに基づくテキスト形式の Runbook
- PowerShell **ワークフロー**
  - Windows PowerShell **ワークフロー** スクリプトに基づくテキスト形式の Runbook

グラフィカルエディター形式 - GUIで編集
- グラフィック
  - Windows PowerShell に基づくグラフィカル Runbook
- グラフィカル PowerShell **ワークフロー**
  - Windows PowerShell **ワークフロー** に基づくグラフィカルRunbook

※「**ワークフロー**」が付くものとつかないものの違いは？

- いずれもPowerShell形式
- **ワークフロー** の場合は並列処理を利用できる（一連のコマンドを並列して実行できる）
- その他、[いくつかの違いがある](https://docs.microsoft.com/ja-jp/azure/automation/automation-powershell-workflow)

[bashなどは現在のところサポートされていない](https://feedback.azure.com/forums/246290-automation/suggestions/13405419-allow-bash-perl-php-scripts-on-azure-automation)。

■スケジュール

- 複数の「スケジュール」を作成できる。
- 各スケジュール
  - 名前、説明
  - 1回、または繰り返し（1週間毎など）
  - 有効期限を設定できる

■ジョブ

- Runbook を開始すると、ジョブが作成される
- ジョブを実行するための worker が割り当てられる
- ジョブのログが最大 30 日間保存される

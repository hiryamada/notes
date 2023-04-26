# モジュール13 Azureツールを使用したインフラストラクチャと構成の管理

- IaCとは
- 構成管理とは
- 命令形と宣言型とは
- 冪等（べきとう）とは
- ARMテンプレートとは
- Azure CLIとは
- Azure PowerShellとは
- Azure Automationとは
  - Runbookとは
  - Desired State Configuration (DSC)とは

## コードとしてのインフラストラクチャ(IaC)と構成管理

■アプローチ

- 命令形
  - リソースを作成する命令を並べる
  - PowerShellスクリプト
  - Bashスクリプト
  - など
- 宣言型
  - リソースの最終的な状態を宣言する
  - ARMテンプレート
  - DSC
  - など

宣言型のほうが定義しやすい。

ただし命令形の方が小回りがきく場合もある。（変数、ループ、条件分岐などが使える）

■冪等 べきとう

リソースに、ある操作を、1度実行しても、2回以上実行しても、同じ結果が得られるという性質。

スクリプトやテンプレートは冪等であるべき。

## ARMテンプレート

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/)

[リンクされたテンプレートについての解説（PDF）](pdf/リンクされたテンプレート.pdf)

## Azure CLI

[ドキュメント](https://docs.microsoft.com/ja-jp/cli/azure/)

## Azure PowerShell

[ドキュメント](https://docs.microsoft.com/ja-jp/powershell/azure/?view=azps-4.8.0)

## Azure Automation

講義: [Azure Automation](../iac/azure-automation.md)

<!--
### Azure Automation とは?


■機能
- Runbook （後述）
- Azure Automation State Configuration （後述）
- Update Management
  - Windows と Linux 仮想マシンに対するOSの更新プログラムを管理
  - 
- 仮想マシン (VM) の起動と停止
- GitHub、Azure DevOps Git、Team Foundation バージョン管理 (TFVC) リポジトリとの統合
- アマゾン ウェブ サービス (AWS) のリソースの自動化
- 共有リソースの管理
- バックアップの実行

### Automationアカウント

Azure Automation を使用するには、少なくとも 1 つの Azure Automation アカウントが必要

### Runbook とは?

一般的な意味としては「手順書」

■Runbook とは?

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


## 参考: Azure Automanage

[ドキュメント](https://azure.microsoft.com/ja-jp/services/azure-automanage/)

[2021/3/2にプレビュー](https://azure.microsoft.com/ja-jp/updates/public-preview-announcing-new-capabilities-for-azure-automanage/)となった。[ブログ](https://techcommunity.microsoft.com/t5/azure-governance-and-management/azure-automanage-for-virtual-machines-public-preview-update/ba-p/2161199)


Microsoft Cloud Adoption Framework for Azure（CAF）に沿って、日々の様々なVM管理タスクを減らすことができるサービス。

- Azure **Automation**は、VM以外のリソースも管理できる。
- Azure **Automanage**は、VMの管理に特化。

## Desired State Configuration (DSC)

### 構成ドリフト

■「構成」とは？

サーバーなどのリソースの、あるべき状態。サーバーに特定のソフトウェアがインストールされ、特定の設定がされ、起動している、など。

設定ファイルなどで定義（宣言）される。

■構成ドリフトとは？

もともとの「構成」から逸脱した状態。

※Drift: Drift is the term for when the real-world state of your infrastructure differs from the state defined in your configuration. （ドリフトは、インフラストラクチャの実際の状態が構成で定義された状態と異なる場合の用語です。）[Terraform](https://www.hashicorp.com/blog/detecting-and-managing-drift-with-terraform)

■スノーフレークとは？

- 自動的に再現できない独自の構成（のサーバー）。
- ※snowflake: 雪の結晶。[同じ形のものが存在しない](https://ja.wikipedia.org/wiki/%E9%9B%AA%E7%89%87)。

■構成ドリフトはなぜ起こる？

- 構成後に人手で修正した
  - エンジニアの教育不足
  - 緊急対応
- プロセスやプログラムによって状態が変更された（リセットされた）
- 改ざん

■どうやって排除するか？

IaCの仕組み（DSCなど）を使用する。

- 設定ファイル（「構成」）を使ってリソースを設定する。
- 構成ドリフトを[検出・修復](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-remediate)する。
- [準拠状態を確認](https://docs.microsoft.com/ja-jp/azure/automation/tutorial-configure-servers-desired-state#check-the-compliance-status-of-a-managed-node)する。

### Desired State Configuration (DSC)

PowerShell による管理プラットフォーム。

「[構成](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/configurations/configurations?view=powershell-7.1)」（PowerShellスクリプト）を用いて、IT と開発インフラストラクチャをコードで管理する。

[ドキュメント](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/overview/overview?view=powershell-7.1)


■DSCの「構成」の例

```
# 構成
configuration LabConfig
{
    # 構成が適用さえるターゲットの指定
    Node WebServer
    {
        # IIS（Webサーバー）という「役割」をインストール
        WindowsFeature IIS
        {
            # 追加または削除されることを保証する役割の名前
            # Get-WindowsFeature コマンドレットからの Name プロパティと同じもの
            Name = 'Web-Server'
            # Present（機能を追加する） または Absent（機能を削除する）
            Ensure = 'Present'
            # すべての「子」の「役割」を含める
            IncludeAllSubFeature = $true
        }
    }
}
```

[ドキュメント](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/reference/resources/windows/windowsfeatureresource?view=powershell-7.1)


### Azure Automation State Configuration

任意のクラウドまたはオンプレミスのデータセンターのノードについて PowerShell Desired State Configuration (DSC) の構成を記述、管理、およびコンパイルできる Azure 構成管理サービス。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-overview)

■（ターゲット）ノード

Azure Automation State Configuration によって管理されるマシン。

- Azure 仮想マシン
- Azure 仮想マシン (クラシック)
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Windows マシン
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Linux マシン

■（組み込みの）プル サーバー

Azure Automation State Configuration では、Windows 機能 DSC サービスに似た DSC プル サーバーが提供されます。

■ターゲットノード

「ターゲット ノード」では、「プル サーバー」から「構成」を受信し、目的の状態に適合させ、コンプライアンスについて報告することができます。

[構成方法](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#enable-physicalvirtual-windows-machines)

- Azure VM: 拡張機能を入れる
- オンプレ等のマシン: 
  - Windows: PowerShell DSC [メタ構成](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#generate-dsc-metaconfigurations)を適用する。
  - Linux: PowerShell DSC for Linuxをインストール

■使い方

- 「構成」をローカルに保存する（.ps1）
- VMを起動
- Automationアカウントを作成
- Automationアカウント＞構成管理＞State Configuration(DSC)
- 「構成」タブで「＋追加」で、ローカルの構成（.ps1）をアップして構成を追加
- コンパイルする。「ノード構成」が作成される。
- 「ノード」タブで「＋追加」でVMをノードとして追加
- VMにノード構成を割り当てる。
- VMの状態が「保留中」となる
- 更新頻度（デフォルト：30分）ごとにノードが更新される

■ラボ

(1) Microsoft Learn [ARM テンプレートを使用して Azure インフラストラクチャをデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/)

- 「サンドボックス」ではなく、ご自身のAzure Passサブスクリプションをご利用ください
- 画面上部の「次」「前」でユニットを移動できます
- 基本的な知識が学べます。

(2) Microsoft Learn [GitHub Actions を使用して ARM テンプレートのデプロイを自動化する](https://docs.microsoft.com/ja-jp/learn/modules/deploy-templates-command-line-github-actions/)

- 「サンドボックス」ではなく、ご自身のAzure Passサブスクリプションをご利用ください
- 画面上部の「次」「前」でユニットを移動できます
- リンクされたテンプレート
- GitHub リポジトリにホスト
- GitHub Actionsを使って、CI/CDでテンプレートをデプロイ

(3) AZ-400 ラボ13 [Resource Manager テンプレートを使用した Azure デプロイ](https://microsoftlearning.github.io/AZ-400JA-Designing-and-Implementing-Microsoft-DevOps-solutions/Instructions/Labs/AZ400_M13_Azure_Deployments_Using_Resource_Manager_Templates.html)

- リンクされたテンプレート
- Blobコンテナーにホスト
- リンクされたテンプレートのSAS URLを生成してメインテンプレートに埋め込む
- 古典的（定番ではある）
-->

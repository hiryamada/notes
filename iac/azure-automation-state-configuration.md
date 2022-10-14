# Azure Automation State Configuration

https://learn.microsoft.com/ja-jp/azure/automation/automation-dsc-overview

- Azure Automationの「構成」管理サービス。
- PowerShell Desired State Configuration (DSC) の「構成」を適用できる
- 任意のクラウド(Azure, AWS, GCP)またはオンプレミスデータセンターの物理/仮想マシン（ノード）の構成が可能

■「構成」とは？

サーバーなどのリソースの、あるべき状態。サーバーに特定のソフトウェアがインストールされ、特定の設定がされ、起動している、など。

設定ファイルなどで定義（宣言）される。

■PowerShell の Desired State Configuration (DSC)とは？

https://learn.microsoft.com/ja-jp/powershell/dsc/getting-started/wingettingstarted?view=dsc-1.1

PowerShell による管理プラットフォーム。2013年10月に登場。PowerShellで「構成」を記述し、コンピュータに適用する。もともとWindows向けに開発されたが、2014年5月にLinuxにも対応。

https://www.buildinsider.net/enterprise/powershelldsc/01

> DSC（Desired State Configuration）は、... マイクロソフトが提供するWindowsインフラ環境の自動構築プラットフォーム

> Windows環境で動作する。

> 2014年5月3日に米国で開催されたMicrosoft TedEdで、Linuxで動作するDSCも発表された。

→ Linux 用 DSC のドキュメント https://learn.microsoft.com/ja-jp/powershell/dsc/getting-started/lnxgettingstarted?view=dsc-1.1

「[構成](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/configurations/configurations?view=powershell-7.1)」（PowerShellスクリプト）を用いて、IT と開発インフラストラクチャをコードで管理する。

■参考: 構成ドリフト

もともとの「構成」から逸脱した状態。

※Drift: Drift is the term for when the real-world state of your infrastructure differs from the state defined in your configuration. （ドリフトは、インフラストラクチャの実際の状態が構成で定義された状態と異なる場合の用語。）[Terraform](https://www.hashicorp.com/blog/detecting-and-managing-drift-with-terraform)

構成ドリフトはなぜ起こるのか:

- 構成後に人手で修正した
  - エンジニアの教育不足
  - 緊急対応
- プロセスやプログラムによって状態が変更された（リセットされた）
- 改ざん

Desired State Configuration (DSC)を使用すると、構成ドリフトの検出・修復が可能。

- 設定ファイル（「構成」）を使ってリソースを設定する。
- 構成ドリフトを[検出・修復](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-remediate)する。
- [準拠状態を確認](https://docs.microsoft.com/ja-jp/azure/automation/tutorial-configure-servers-desired-state#check-the-compliance-status-of-a-managed-node)する。

■参考: スノーフレーク

- 構成管理がされていないサーバー
- 長年にわたって手動で変更が行われており、もはや同じ環境を再現することができない
- 避けるべき。
- ※snowflake: 雪の結晶。[同じ形のものが存在しない](https://ja.wikipedia.org/wiki/%E9%9B%AA%E7%89%87)。

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

■（ターゲット）ノード

Azure Automation State Configuration によって管理されるマシン。

- Azure 仮想マシン
- Azure 仮想マシン (クラシック)
- オンプレミス、Azure、または Azure 以外のクラウド(AWS, GCP等)内の物理/仮想 Windows マシン
- オンプレミス、Azure、または Azure 以外のクラウド(AWS, GCP等)内の物理/仮想 Linux マシン

■（組み込みの）プル サーバー

Azure Automation State Configuration では、Windows の「DSC サービス」に似た DSC プル サーバーが提供される。

「ターゲット ノード」では、「プル サーバー」から「構成」を受信する。


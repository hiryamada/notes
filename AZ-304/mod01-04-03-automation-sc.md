

# Azure Automation State Configuration

https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-overview

Azure Automation内の1機能。

任意のクラウドまたはオンプレミスのデータセンターのノードについて PowerShell Desired State Configuration (DSC) の構成を記述、管理、およびコンパイルできる Azure 構成管理サービス。

■（ターゲット）ノード

Azure Automation State Configuration によって管理されるマシン。

- Azure 仮想マシン
- Azure 仮想マシン (クラシック)
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Windows マシン
- オンプレミス、Azure、または Azure 以外のクラウド内の物理/仮想 Linux マシン

■（組み込みの）プル サーバー

Azure Automation State Configuration では、Windows 機能 DSC サービスに似た DSC プル サーバーが提供される。

■ターゲットノード

「ターゲット ノード」では、「プル サーバー」から「構成」を受信し、目的の状態に適合させ、コンプライアンスについて報告することができる。

[構成方法](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#enable-physicalvirtual-windows-machines)

- Azure VM: 拡張機能を入れる
- オンプレ等のマシン: 
  - Windows: PowerShell DSC [メタ構成](https://docs.microsoft.com/ja-jp/azure/automation/automation-dsc-onboarding#generate-dsc-metaconfigurations)を適用する。
  - Linux: PowerShell DSC for Linuxをインストール

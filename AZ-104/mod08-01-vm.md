# Azure Virtual Machines (VM)

製品ページ: [シリーズ](https://azure.microsoft.com/ja-jp/pricing/details/virtual-machines/series/), [Windows](https://azure.microsoft.com/ja-jp/services/virtual-machines/windows/), [Linux](https://azure.microsoft.com/ja-jp/services/virtual-machines/linux/)

[料金](https://azure.microsoft.com/ja-jp/pricing/details/virtual-machines/windows/)

[サイズの名前付け規則](https://docs.microsoft.com/ja-jp/azure/virtual-machines/vm-naming-conventions): [ファミリ] + [サブファミリ*] + [vCPU の数] + [追加機能] + [アクセラレータの種類*] + [バージョン]

[FreeBSD](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/freebsd-intro-on-azure)や[OpenBSD](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/create-upload-openbsd)も利用可能

# VMの可用性

[可用性についてのインフォグラフィック](https://azure.microsoft.com/mediahandler/files/resourcefiles/infographic-reliability-with-microsoft-azure/InfographicRC2.pdf)

[解説](https://ascii.jp/elem/000/004/018/4018517/2/)

[仮想マシンのSLA](https://azure.microsoft.com/ja-jp/support/legal/sla/virtual-machines/v1_9/)


# 料金

→ [料金についてのまとめ](../general/cost.md)

概要:

- VMのサイズ - スペックに比例したコスト
- VMの状態 (停止・割り当て解除)
- OS - Ubuntu等一部のOSは無料
- 予約 - 1年/3年の予約で大幅割引
- ハイブリッド特典 - OSライセンスを節約
- スポット - 最大90% OFFでVMを利用

[料金計算ツール](https://azure.microsoft.com/ja-jp/pricing/calculator/)

# OSのアップグレード

※インプレース アップグレード

Windows: [Microsoft では、Azure VM のオペレーティングシステムのアップグレードはサポートされていません。](https://docs.microsoft.com/ja-jp/troubleshoot/azure/virtual-machines/in-place-system-upgrade)。新しいVMを作成し、ワークロードを移行します。

Linuxの例: [RHEL 7からRHEL 8へのアップグレード](https://docs.microsoft.com/ja-jp/azure/virtual-machines/workloads/redhat/redhat-in-place-upgrade)

# VM拡張機能

拡張機能は、Azure VM でのデプロイ後の構成と自動化を提供する小さなアプリケーションです。 Azure プラットフォームでは、VM の構成、監視、セキュリティ、およびユーティリティのアプリケーションを対象とする多くの拡張機能をホストします。 公開元は、アプリケーションを取得し、それを拡張機能にまとめて、インストールを簡略化します。 ユーザーは必須パラメーターを指定するだけで済みます。

## カスタム スクリプト拡張機能

Azure 仮想マシンでスクリプトをダウンロードし、実行します。 

[Windows](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/custom-script-windows), [Linux](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/custom-script-linux)

## DSC(Desired State Configuration) 

システムの構成、展開、および管理に使用する宣言型プラットフォームです。

[Windows](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/getting-started/wingettingstarted?view=powershell-7.1), [Linux](https://docs.microsoft.com/ja-jp/powershell/scripting/dsc/getting-started/lnxgettingstarted?view=powershell-7.1)

## VMスナップショット拡張機能

VM をシャットダウンしなくても Azure 仮想マシンのアプリケーション整合バックアップを作成できます。

[Windows](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/vmsnapshot-windows), [Linux](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/vmsnapshot-linux)


# エージェント

VMエージェント: [Windows - WindowsAzureGuestAgent.exe](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/agent-windows), 
[Linux - waagent](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/agent-linux)


[Azure Monitorのエージェント](https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/agents-overview)
# Azure 仮想マシン（Virtual Machine、VM）

■IaaSとは？

https://azure.microsoft.com/ja-jp/overview/what-is-iaas/

https://azure.microsoft.com/ja-jp/services/virtual-machines/secure-well-managed-iaas/

Infrastructure as a Service - サービスとしてのインフラストラクチャ。インフラを、サービスとして提供。

■Azure のIaaS

- 仮想マシン - [Azure Virtual Machine (Azure VM)](https://azure.microsoft.com/ja-jp/services/virtual-machines/)
- 仮想ネットワーク - [Virtual Network (VNet)](https://azure.microsoft.com/ja-jp/services/virtual-network/)
- ディスク - [Azure マネージドディスク](https://docs.microsoft.com/ja-jp/azure/virtual-machines/managed-disks-overview)

■IaaSのビジネスシナリオ

https://azure.microsoft.com/ja-jp/overview/what-is-iaas/

（「IaaSの一般的なビジネスシナリオ」を参照）

■仮想マシン作成のチェックリスト

■VM作成前の検討事項

Linux:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/overview#what-do-i-need-to-think-about-before-creating-a-vm

Windows:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/overview#what-do-i-need-to-think-about-before-creating-a-vm

- ネットワーク(VNet)を事前に計画・設計しておく
- 名前
  - Windows: 15文字まで
  - Linux: 64文字まで
- ロケーション（リージョン）
- サイズ（後述）
- 価格モデル
  - 従量課金制（通常の料金）
  - リザーブドVMインスタンス（後述）
  - スポット仮想マシン（後述）
  - ハイブリッド特典（後述）
- OSイメージ
  - 仮想マシン作成画面のイメージ選択欄では、Windows 10やUbuntuなどを選択できる
  - 仮想マシン作成画面のイメージ選択欄の下の「すべてのイメージを表示」をクリックすると、より多くのイメージが表示される

■VMのサイズ

https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes

主なタイプとシリーズ。

- 汎用 タイプ
  - [Aシリーズ(Av2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/av2-series)
  - [Bシリーズ(B)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-b-series-burstable)
  - [Dシリーズ(Dv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/dv4-dsv4-series)
- コンピューティング最適化 タイプ
  - [Fシリーズ(Fsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/fsv2-series)
- メモリの最適化 タイプ
  - [Eシリーズ(Ev4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ev4-esv4-series)
  - [Mシリーズ(M)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/m-series)
- ストレージの最適化 タイプ
  - [Lシリーズ(Lsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/lsv2-series)
- GPU タイプ
  - [NCシリーズ(NCv3)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ncv3-series)
  - [NVシリーズ(NVv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/nvv4-series)
- FPGA最適化済み タイプ
  - [NPシリーズ(NP)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/np-series)
- ハイ パフォーマンス コンピューティング タイプ
  - [Hシリーズ(H)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/h-series)

■可用性オプション

VMの可用性を高めるには。

[可用性に関するインフォグラフィック](https://azure.microsoft.com/mediahandler/files/resourcefiles/azure-resiliency-infographic/Azure_resiliency_infographic.pdf)

- 単一VM - 99.9% SLA
- 可用性セット - 99.95% SLA
- 可用性ゾーン - 99.99% SLA

[可用性セットまとめPDF](../AZ-104/pdf/mod08/可用性セット.pdf)

[可用性ゾーンまとめPDF](../AZ-104/pdf/mod08/可用性ゾーン.pdf)



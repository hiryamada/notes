# Azure Bastion

PDFまとめ: [Azure Bastion](../pdf/mod2/Azure%20Bastion.pdf)

VM へのシームレスで安全な RDP および SSH 接続を提供

https://docs.microsoft.com/ja-jp/azure/bastion/bastion-overview

2019/6/18 プレビュー https://azure.microsoft.com/ja-jp/updates/azure-bastion-now-available-for-preview/

2019/11/4 一般提供開始 https://azure.microsoft.com/ja-jp/updates/azure-bastion-is-now-generally-available/

※Bastion（バスティオン）：[要塞、とりで](https://ejje.weblio.jp/content/bastion)。IT用語としては、踏み台ホスト。ジャンプサーバー。

■しくみ

- ブラウザーと Azure portal を使用してVMに接続できるようにするサービス
- Bastionを仮想ネットワーク内でプロビジョニング
- TLS 経由で Azure portal から直接、仮想マシンに安全かつシームレスに RDP/SSH 接続
- HTML5ブラウザがあればOK。SSHクライアントやRDPクライアントは不要。
- ハブ&スポーク型での利用も可能。
  - ハブにBastionを配置
  - スポークのVNetのVMに接続

■Azure Bastionのレベル（SKU）

- Azure Bastion Basic
- [Azure Bastion Standard](https://azure.microsoft.com/ja-jp/updates/azure-bastion-standard-sku-public-preview/)
  - Azure BationホストのVMを手動でスケール可能
    - 5-20インスタンス
  - Azure Bastion Admin Panel
    - （まだ利用できない？）


■価格

- Azure Bastion Basic
  - 21.28円/h
  - 15,321円/月
- Azure Bastion Standard
  - 23.48円/h
  - 16,905.6円/月

他に送信データ料金が発生。
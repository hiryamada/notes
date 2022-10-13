# Azure Bastion

PDFまとめ: [Azure Bastion](../pdf/mod2/Azure%20Bastion.pdf)

VM へのシームレスで安全な RDP および SSH 接続を提供

https://docs.microsoft.com/ja-jp/azure/bastion/bastion-overview

2019/6/18 プレビュー
https://azure.microsoft.com/ja-jp/updates/azure-bastion-now-available-for-preview/

2019/11/4 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-bastion-is-now-generally-available/

2021/11/2 Azure Bastion Standard SKU（Standard レベル）一般提供開始
https://azure.microsoft.com/en-us/updates/general-availability-bastion-standard-sku/

- [Bastion を構成するホストVMを手動スケール可能に。](https://learn.microsoft.com/ja-jp/azure/bastion/configuration-settings#instance)
- Azure Bastion admin panel が利用可能に。
- [従来のもの（Basic SKU）からのアップグレードが可能。Basicに戻すことはできない。](https://learn.microsoft.com/ja-jp/azure/bastion/upgrade-sku)

※Bastion（バスティオン）：[要塞、とりで](https://ejje.weblio.jp/content/bastion)。IT用語としては、踏み台ホスト。ジャンプサーバー。

■しくみ

- ブラウザーと Azure portal を使用してVMに接続できるようにするサービス
- Bastionを仮想ネットワーク内でプロビジョニング
- TLS 経由で Azure portal から直接、仮想マシンに安全かつシームレスに RDP/SSH 接続
- 接続先の仮想マシンにはパブリック IP アドレスが不要。
- HTML5ブラウザがあればOK。SSHクライアントやRDPクライアントは不要。
- ハブ&スポーク型での利用も可能。
  - ハブにBastionを配置
  - スポークのVNetのVMに接続
  - グローバルピアリングでも利用可能
- [ネイティブクライアントによる接続も可能。](https://www.hondalabo.net/entry/2022/10/04/180000) ※Standardのみ


■Azure Bastionのレベル（SKU）

- Basic
- [Standard](https://azure.microsoft.com/ja-jp/updates/azure-bastion-standard-sku-public-preview/)
  - Azure BationホストのVMを手動でスケール可能
    - インスタンス数を増やすと、Azure Bastion でより多くの同時セッションを管理できる
    - 各インスタンスは、中程度のワークロードで、25 の同時 RDP 接続と 50 の同時 SSH 接続をサポート
    - 最大 50 個のホスト インスタンスをサポート
    - ホストのスケーリングを可能にするには、AzureBastionSubnet が /26 以上である必要がある

■Webブラウザーと Azure portal (Basic / Standard)

```
Webブラウザー
↓
Azure portal / Azure Bastion でVMに接続
↓
VM
```

■ネイティブクライアントによる接続 (Standardのみ)

```
リモートデスクトップクライアント / SSHクライアント
↓
Azure Bastion
↓
VM
```

[コマンドを使用する。](https://learn.microsoft.com/ja-jp/cli/azure/network/bastion?view=azure-cli-latest)

- az network bastion rdp
- az network bastion ssh


■価格

https://azure.microsoft.com/ja-jp/pricing/details/azure-bastion/

- デプロイされた時間に比例した料金
- Standardレベルで追加のインスタンスを使用した場合はその料金
- 送信データ料金

https://techblog.asia-quest.jp/azure%E3%82%B5%E3%83%BC%E3%83%93%E3%82%B9%E5%88%A5%E3%82%B3%E3%82%B9%E3%83%88%E5%89%8A%E6%B8%9B%E6%96%B9%E6%B3%95%E3%81%AE%E7%B4%B9%E4%BB%8B

Azure Bastionは起動・停止できず、課金停止のためにはリソースを削除する必要がある。

課金を抑える方法として、Azure Bastionを都度削除する方法や、Logic Appsを用いてAzure Bastionを定期的に自動作成・削除する方法がある。平日9時～18時のみAzure Bastionを実行するなど。


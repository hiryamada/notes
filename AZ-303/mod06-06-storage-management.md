ストレージの管理（さまざまなデータ転送ソリューション）

# Azure Import/Export

https://docs.microsoft.com/ja-jp/azure/import-export/storage-import-export-service

2016/8/24 GA https://devblogs.microsoft.com/azuregov/azure-import-export-service-generally-available-in-azure-government/

- 大量のデータ(40TBまで)をインポートまたはエクスポートするサービス
  - Azure Blob Storage と Azure Files にデータをインポート
  - Azure Blob Storageからデータをエクスポート
- お客様が所有するディスク ドライブを使用(1回で10台まで)
  - ※Microsoft提供のディスクを使用する場合はAzure Data Box の Diskを使用（後述）
- ディスク ドライブを Azure データセンターに送付

サポートされるディスクの種類:
https://docs.microsoft.com/ja-jp/azure/import-export/storage-import-export-requirements#supported-hardware

# Azure Data Box

https://azure.microsoft.com/ja-jp/services/databox/

2018/9 一般提供開始 https://azure.microsoft.com/ja-jp/blog/expanding-the-azure-data-box-family/

- Azure Blob Storage と Azure Files に大量のデータをインポートするためのサービス
- Microsoftが所有するストレージデバイスを使用
- ストレージデバイスをオンプレミスに送付
- オンプレミスでデータを書き込み、Azureに返送

ラインナップ:

- Azure Data Box Disk
  - メディア1台あたり: 8TBの容量
  - 1回の注文で 1台～5台 利用可能
  - 実際に転送可能な容量: 35TB
  - インターフェイス: USB 3.1 / SATA
- Azure Data Box
  - 100 TBの容量:
  - 1回の注文で 1台 利用可能
  - 実際に転送可能な容量: 80TB
  - インターフェイス: 1x1/10 Gbps RJ45、2x10 Gbps SFP+ 
- Azure Data Box Heavy
  - メディア1台あたり 1 PB
  - 1回の注文で 1台 利用可能
  - 実際に転送可能な容量: 800TB
  - インターフェイス: 4x1 Gbps、4x40 Gbps

Microsoft Learn: [Azure Data Box ファミリを使用して大量のデータをクラウドに移動する](https://docs.microsoft.com/ja-jp/learn/modules/move-data-with-azure-data-box/)


写真:
- https://www.slideshare.net/ssuser411bae/azure-data-box-family-overview-and-microsoft-intelligent-edge-strategy/14
- https://www.slideshare.net/ssuser411bae/azure-data-box-family-overview-and-microsoft-intelligent-edge-strategy/18
- https://www.slideshare.net/ssuser411bae/azure-data-box-family-overview-and-microsoft-intelligent-edge-strategy/22


# Azure Data Box Gateway

https://docs.microsoft.com/ja-jp/azure/databox-gateway/data-box-gateway-overview

2019/3 一般提供開始 https://azure.microsoft.com/en-us/blog/azure-data-box-family-meets-customers-at-the-edge/

- Azure にシームレスにデータを送信できるストレージ ソリューション
- Azure Blob Storage または Azure Files にデータを転送
- 「仮想デバイス」をオンプレミスにデプロイ
  - Hyper-V
  - VMware

# Azure Stack シリーズ

https://azure.microsoft.com/ja-jp/overview/azure-stack/#overview

- Azure Stack Edge
  - 旧: Azure Data Box Edge
  - エッジ コンピューティング
- [Azure Stack Hub](https://azure.microsoft.com/ja-jp/products/azure-stack/hub/) 
  - 旧 Azure Stack
  - Azure を拡張し、オンプレミス環境でお客様のアプリを実行
- [Azure Stack HCI](https://azure.microsoft.com/ja-jp/products/azure-stack/hci/#overview)
  - ハイパーコンバージド インフラストラクチャ (HCI) ソリューション
  - Windows Serverベースの「Azure Stack HCI」専用OSを利用

名称変更について:
- 2017/8 Azure Stack GA
- 2019/11 
  - Azure Stack が Azure Stack Hubに名称変更
  - Azure Stack HCIとAzure Stack Edgeが追加

# Azure Stack Edge (旧: Azure Data Box Edge)

https://azure.microsoft.com/ja-jp/products/azure-stack/edge/

2018/9/25 一般提供開始 https://azure.microsoft.com/ja-jp/updates/announcing-azure-data-box-edge/

2019/10/3 「新しいフォームファクター」を追加 https://blogs.microsoft.com/blog/2019/10/03/enabling-government-to-advance-tech-intensity-with-newest-cloud-product-innovations/

- AI 対応のエッジ コンピューティング機能を備えたオンプレミス アプライアンス
- ストレージ ゲートウェイとして機能
- Azure ストレージとの間でデータを転送

ラインナップ:

- Azure Stack Edge Pro シリーズ
  - Pro
  - Pro R
- Azure Stack Edge Mini シリーズ
  - Mini R

※「R」: ラグド Rugged：過酷な環境。砂漠や雪山、工場、建設現場など。野外調査、災害支援、軍事用。「ラグド ソリューション」、「ラグド 端末」などの言葉がある。

※ruggedized: 「耐久性のある」。（耐衝撃、防水、防塵性能を持った）コンピュータやケース等。


[Azure Stack Edge(旧: Azure Data Box Edge)と Azure Data Box Gatewayの使い分け](https://www.slideshare.net/ssuser411bae/azure-data-box-family-overview-and-microsoft-intelligent-edge-strategy/47)

- Azure Stack Edge(旧: Azure Data Box Edge)
  - ネットワークアプライアンス（ハードウェア）
  - エッジコンピューティング機能あり
    - データ変換、フィルタリングなどの前処理
    - エッジでのマシンラーニングの実行
- Azure Data Box Gateway
  - 仮想マシン
  - エッジコンピューティング機能なし
    - データ転送のみ可能

# AzCopy

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-v10

- Windows, macOS, Linuxに対応したコマンドラインツール
- Blob/Filesのデータ操作に特化
  - アップロード, ダウンロード
  - ストレージアカウント間でのコピー
  - 同期
  - Amazon S3, Google Cloud Storageとのデータ転送

# Azure Storage Explorer

https://azure.microsoft.com/ja-jp/features/storage-explorer/

- スタンドアロンのクライアントアプリケーション
- Windows, macOS, Linuxに対応
- ストレージアカウントに接続
- Blob, Files, Table, Queueを操作

# Azure CLIとAzure PowerShell

Azure CLI: https://docs.microsoft.com/ja-jp/cli/azure/storage/blob

Azure PowerShell: https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-powershell

- コマンドを使って、ストレージアカウントを操作
- Blobデータの操作なども可能

# blobfuse

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-how-to-mount-container-linux

Blob StorageをLinuxボリュームとしてマウントできる仮想ファイルシステムドライバー。

# Cyberduck

https://cyberduck.io/

- オープンソースソフトウェア
- Windos, macOSに対応したGUIクライアント
- Azure Blob Storageのほか、FTP/SFTP, S3, Google Drive, DropBox, OneDriveなどに接続できる

# データ転送のソリューションの選択

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-choose-data-transfer-solution
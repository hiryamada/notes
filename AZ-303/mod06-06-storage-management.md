# Azure Import/Export

https://docs.microsoft.com/ja-jp/azure/import-export/storage-import-export-service

2016/8/24 GA https://devblogs.microsoft.com/azuregov/azure-import-export-service-generally-available-in-azure-government/

- 大量のデータをインポートまたはエクスポートするサービス
  - Azure Blob Storage と Azure Files にデータをインポート
  - Azure Blob Storageからデータをエクスポート
- お客様が所有するディスク ドライブを使用
- ディスク ドライブを Azure データセンターに送付

# Azure Data Box

https://azure.microsoft.com/ja-jp/services/databox/

2018/9 一般提供開始 https://azure.microsoft.com/ja-jp/blog/expanding-the-azure-data-box-family/

- Azure Blob Storage と Azure Files に大量のデータをインポートするためのサービス
- Microsoftが所有するストレージデバイスを使用
- ストレージデバイスをオンプレミスに送付
- オンプレミスでデータを書き込み、Azureに返送

ラインナップ:

- Data Box Disk - 8TB
- Data Box - 100 TB
- Data Box Heavy - 1 PB

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


※「R」: ラグド Rugged：過酷な環境。砂漠や雪山、工場、建設現場など。野外調査、災害支援、軍事用。 

※ruggedized: 耐久性のある（耐久性を高めた）コンピュータやケース等。ラグド ソリューション、ラグド データセンターなどの言葉がある。

# AzCopy

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-v10

# Azure Storage Explorer

https://azure.microsoft.com/ja-jp/features/storage-explorer/

# Azure CLI

https://docs.microsoft.com/ja-jp/cli/azure/storage/blob?view=azure-cli-latest

# Azure PowerShell

https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-powershell

# データ転送のソリューションの選択

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-choose-data-transfer-solution


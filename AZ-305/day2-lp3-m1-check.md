
# 知識チェック

[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-data-storage-solution-for-non-relational-data/9-knowledge-check)

# ケーススタディ

https://github.com/MicrosoftLearning/AZ-305-DesigningMicrosoftAzureInfrastructureSolutions.ja-jp/blob/main/Instructions/CaseStudy/03-Nonrelationalstorage.md

- ストレージアカウント内で、適切なサービスを選択する
  - インターネットに公開される動画、PDFファイル: Blob Storage
  - WordやExcelなど、アプリで開くファイル: Azure Files ファイル共有
- Blobで、適切なアクセス階層を使用する
  - 頻繁にアクセスされるファイル: ホット
  - 年に数回しかアクセスされないファイル: クール
  - ほとんどアクセスされない（が、長期保存する必要がある）ファイル: アーカイブ

# ラボ22 Azure Cognitive Search ソリューションを作成する

Azure Cognitive Searchを使用して、PDFの検索が実行できるようにします。

Azure Cognitive Searchでは、Azure Cognitive Servicesを併用することで、以下のような高度な検索を実現できます。

- PDFに含まれる画像をキーワードで検索する
  - 例: スカイスクレイパー（高層建築物）を検索する
- 感情分析を使用して、肯定的な文章が含まれる文章を検索する
  - 例: 評判がよいホテルを検索する

最後に、WebアプリにAzure Cognitive Searchを組み込み、Webアプリから高度な検索を利用できるようにします。

## Azureリソースを作成する

- [Azure Cognitive Searchリソースの作成](https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#azure-cognitive-search-%E3%83%AA%E3%82%BD%E3%83%BC%E3%82%B9%E3%82%92%E4%BD%9C%E6%88%90%E3%81%99%E3%82%8B)
- [Azure Cognitive Services（マルチアカウント）リソースの作成](https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#cognitive-services-%E3%83%AA%E3%82%BD%E3%83%BC%E3%82%B9%E3%81%AE%E4%BD%9C%E6%88%90)
- [ストレージ アカウントの作成](https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#%E3%82%B9%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B8-%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88%E3%81%AE%E4%BD%9C%E6%88%90)

リソースを作成したら、以下の情報を調べてメモ帳などにコピーしておきます。

```
■Azure Cognitive Search
名前:
URL:
プライマリ管理者キー:

■ストレージアカウント
サブスクリプションID:
ストレージ アカウント名:
key1のキー:

■Azure Cognitive Services
名前:
キー 1:
```

## ストレージアカウントへのPDFデータのアップロード

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#azure-storage-%E3%81%AB%E3%83%89%E3%82%AD%E3%83%A5%E3%83%A1%E3%83%B3%E3%83%88%E3%82%92%E3%82%A2%E3%83%83%E3%83%97%E3%83%AD%E3%83%BC%E3%83%89%E3%81%99%E3%82%8B

## Azure Cognitive Searchで、PDFのインデックスを作成する

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#%E3%83%89%E3%82%AD%E3%83%A5%E3%83%A1%E3%83%B3%E3%83%88%E3%81%AE%E3%82%A4%E3%83%B3%E3%83%87%E3%83%83%E3%82%AF%E3%82%B9%E3%82%92%E4%BD%9C%E6%88%90%E3%81%99%E3%82%8B

## Azure Cognitive Searchで検索を行う

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#%E3%82%A4%E3%83%B3%E3%83%87%E3%83%83%E3%82%AF%E3%82%B9%E3%82%92%E6%A4%9C%E7%B4%A2%E3%81%99%E3%82%8B

## 「インデクサー」を更新する

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#%E6%A4%9C%E7%B4%A2%E3%82%B3%E3%83%B3%E3%83%9D%E3%83%BC%E3%83%8D%E3%83%B3%E3%83%88%E5%AE%9A%E7%BE%A9%E3%81%AE%E8%AA%BF%E6%9F%BB%E3%81%A8%E5%A4%89%E6%9B%B4

## Webアプリから検索を行う

https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp/blob/main/Instructions/22-azure-search.md#%E6%A4%9C%E7%B4%A2%E3%82%AF%E3%83%A9%E3%82%A4%E3%82%A2%E3%83%B3%E3%83%88-%E3%82%A2%E3%83%97%E3%83%AA%E3%82%B1%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%82%92%E4%BD%9C%E6%88%90%E3%81%99%E3%82%8B

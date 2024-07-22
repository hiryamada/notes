# Azure AI Searchの Document Intelligence カスタム スキルを構築する

https://learn.microsoft.com/ja-jp/training/modules/build-form-recognizer-custom-skill-for-azure-cognitive-search/

Azure Document Intelligence ソリューションをカスタム スキルとして使用して、Azure AI Search パイプライン内のコンテンツをエンリッチする方法について学習する。


このモジュールでは、Azure AI Document Intelligence のモデルを呼び出してドキュメントのインデックス作成を補助する AI Search カスタム スキルを作成する方法を学習します。

## シナリオ

世論調査会社で、投票者 ID やその他の値を抽出するために、記入済みの投票フォームを Azure AI Document Intelligence に送信するカスタム スキルを実装することを決断しました。 これらの値をAzure AI Searchインデックスに格納して、ユーザーが投票者 ID で検索し、必要な投票フォームを見つけられるようにする必要があります。

```
ユーザー
↓検索（投票者ID）↑検索結果
Azure AI Search
└インデックス
  └スキルセット
    └カスタムスキル (on Azure Functions)
      └Azure Document Intelligence（投票フォーム → キー・値ペア）
```

## 手順

- Azure サブスクリプションに Azure AI Document Intelligence リソースを作成します。
- Azure AI Document Intelligence で 1 つまたは複数のモデルを構成します。 請求書や名刺などの事前構築済みモデルを選択することも、通常とは異なる、または独自の種類のフォームに独自のモデルをトレーニングすることもできます。
- Azure AI Document Intelligence リソースを呼び出すことができる Web サービスを開発してデプロイします。 このモジュールでは、Azure 関数を使用してこのサービスをホストします。
- AI Searchスキルセットに、正しい構成のカスタム Web API スキルを追加します。 このスキルは、Web サービスに要求を送信するように構成する必要があります。

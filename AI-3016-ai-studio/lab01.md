# ラボ01 Model Catalog


## ハブの作成

- Azure AI Studio ( https://ai.azure.com ) にアクセス
- サインイン
- ホーム → Management → All hubs → + New Hub
- ハブ名、リソースグループ、リージョンを指定
- (同時にAzure AI Serviceリソース, Azure OpenAI Serviceリソースを作成するか選択する)
- (同時にAzure AI Searchリソースを作成するか選択する) ... オプション

作成を進めると、ストレージアカウント、Azure Key Vaultも作成される。

```
ハブ
├Azure AI Serviceリソース
├ストレージアカウント
└Azure Key Vault
```

ハブの「Connected resources」には、Azure AI Serviceリソースへの接続（Azure OpenAI用とAzure AI Services用）が作成される。

その他、Azure AI Search、Azure AI Content Safety、Serp、API Key、Custom Keysなどの接続を追加できる

## プロジェクトの作成


- Azure AI Studio ( https://ai.azure.com ) にアクセス
- サインイン
- ホーム → + New Project (または、ハブを選択した状態で + New Project)


## モデルカタログ


## GPTモデルのデプロイ

## チャットプレイグラウンドからの利用


# ラボ02 RAG

## Azure AI Studio

ハブ・プロジェクト・AI Search等のリソースを作成

## モデルをデプロイ

- `text-embeddings-ada-002`
- `gpt-35-turbo-16k`

https://learn.microsoft.com/ja-jp/azure/search/vector-search-how-to-create-index?tabs=config-2024-07-01%2Crest-2024-07-01%2Cpush%2Cportal-check-index#prerequisites

※Azure OpenAI では、text-embedding-ada-002 の場合、数値ベクトルの長さは 1536 です。 text-embedding-3-small または text-embedding-3-large の場合、ベクトルの長さは 3072 です。


## サンプルPDFデータをダウンロード

## インデックスを作成

`brochures-index`

serverless computeを使用。結構時間がかかる（10分程度）

## インデックスをテスト

chatプレイグラウンドで `New York` などと入力してその都市の情報がPDFの引用とともに出てくることを確認。

## プロンプトフロー

`Multi-Rouond Q&A on Your Data` をクローン。

※`This request is not authorized to perform this operation. Please grant workspace/registry read access to the source storage account` と出た場合: しばらく待って、フォルダ名を変更してクローンしたらエラー解消。

画面上部の「Compute seession」をクリックして開始。これをやらないと `lookup` のインデックス設定ができない。

`lookup` の `mlindex_context`, `query_type` を設定。
- `mlindex_context`
  - `index_type`: `Registered Index`
  - `acs_index_name`: `(作成したインデックスの名前)`
- `query_type`: `Hybrid (vector + keyword)`

`modify_query_with_history` と `chat_with_context` の2つのツール内で、以下を設定。
- Connection: `ai-hub...._aoai`
- deployment_name: `gpt-35-turbo-16k`
- response_format: `{"type":"text"}`

画面上部 `Save` をクリック。

## プロンプトフローをエンドポイントとしてデプロイ

画面上部の「deploy」をクリックしてデプロイを行う。

10分ほどかかる。

デプロイが完了したら `Deployments`からデプロイを開き `Test` でチャット形式のテストが可能。

■ベクトル（ベクター）vector

テキストを、浮動小数点数の配列に変換したもの。

```
"Hello, world!" => {1.2, 3.4, 5.6, 7.8, ...}
```

テキストをベクトルに変換する（ベクトル化）と、2つのベクトルから「コサイン類似度（Cosine Similarity）」（-1から1の値をとる）を計算できる。この数値が1に近いほど、2つのベクトル（文章）の類似度（関連性）が高いということになる。

たとえば、多数の議事録のテキストをベクトル化してデータベースに記録しておく。ユーザーがシステムに質問を入力すると、それもベクトル化し、データベースに記録された各ベクトルとの類似度を計算することで、質問に対する関連性が高い議事録を探すことができる。

■Embeddings（埋め込み）

https://platform.openai.com/docs/guides/embeddings

https://learn.microsoft.com/ja-jp/azure/ai-services/openai/how-to/embeddings?tabs=console

OpenAIやAzure OpenAI Service の Embeddings API（内部では`text-embedding-ada-002` といった埋め込み計算用のモデルが使用される）、テキストをベクトルに変換できる。

各テキストは、1536次元のベクトルに変換される。

■参考: Embedding(埋め込み)スキル

https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-skill-azure-openai-embedding

2023年11月、Azure OpenAI リソースにデプロイされているEmbedding(埋め込み)モデルに接続して、テキストのベクトルを生成できるスキルが追加された。

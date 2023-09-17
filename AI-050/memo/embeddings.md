# 埋め込み(embeddings)

■Embeddings（埋め込み）とは？

- 入力テキストをベクトル（浮動小数点の配列）に変換する。
- text-embedding-ada-002 (バージョン 1 または 2, 2が推奨) モデルをデプロイして使用する
- Azure OpenAI Studioには、Embeddings用のプレイグラウンドはない。

■モデル: text-embedding-ada-002 （など）

https://www.infoq.com/jp/news/2023/05/openai-embedding-model/

この新しいモデルは、従来のもっとも高性能なモデルであるDavinciをほとんどのタスクで上回り、しかも99.8%の大幅なコスト削減を実現している。また、text-embedding-ada-002はより使いやすくなっており、ユーザーにとってより便利な選択肢となっているのだ。

エンベッディングとは、コンピュータがその概念間の関係を理解できるようにするための概念の数値表現である。検索、クラスタリング、レコメンデーション、異常検知、多様性測定、分類などのタスクでよく使用されている。エンベッディングは、浮動小数点の演算による実数または複素数の整数のベクトルで構成され、2つのベクトル間の距離は、その関係の強さを示す。一般に、距離が近いほど強い関係を示し、遠いほど弱い関係を示す。

■Embeddings はどのように使うのか？

類似度が高いテキストを探し出すのに使用できる。

(1) 検索対象の大量のテキストに対してベクトルを求めて保存しておく
(2) ユーザーが入力したテキストに対してベクトルを求める
(3) (1)のベクトルと(2)のベクトルの「コサイン類似度」(-1 ～ 1)を計算する

コサイン類似度が1に近い＝テキストの類似性が高い。

■「コサイン類似度」(cosine simularity)とは？

https://atmarkit.itmedia.co.jp/ait/articles/2112/08/news020.html

- 2つのベクトルの類似度を数値化したもの。
- ベクトルXとYの内積 / (XのL2ノルム * YのL2ノルム)
- C#やPythonのライブラリで、コサイン類似度を計算できる。
- 簡単なコードを自分で書いて計算することもできる。

※参考
- [ベクトルの内積](https://univ-juken.com/vector-naiseki)
- [ノルム](https://manabitimes.jp/math/1269)
  - [ユークリッド距離](https://atmarkit.itmedia.co.jp/ait/articles/2111/10/news023.html)

■実際の使い方

- Embeddings APIを使用してベクトルを求める。
- Cosmos DB for MongoDB vCoreはネイティブのベクトル検索機能を持っている。


---


テキストの埋め込みベクトルを取得。

https://learn.microsoft.com/ja-jp/azure/ai-services/openai/how-to/embeddings?tabs=csharp

埋め込みは浮動小数点数のベクトル.

以下のようなコードで、埋め込みの浮動小数点数を表示できる。

```c#
var option = new EmbeddingsOption("テキスト");
var returnValue = openAIClient.GetEmbeddings("デプロイ名", option);

foreach (float item in returnValue.Value.Data[0].Embedding)
{
    Console.WriteLine(item);
}
```

https://learn.microsoft.com/ja-jp/azure/ai-services/openai/how-to/embeddings?tabs=csharp

ベクトル空間内の 2 つの埋め込み間の距離は、元の形式の 2 つの入力間のセマンティック類似性と相関します。 たとえば、2 つのテキストが似ている場合、それらのベクトル表現も似ているはずです。

https://devblogs.microsoft.com/dotnet/demystifying-retrieval-augmented-generation-with-dotnet/

「埋め込み」は、何らかのコンテンツとその意味論的な意味を表す浮動小数点値のベクトル (配列) と考えてください。 埋め込みに特に焦点を当てたモデルに、特定の入力に対してそのようなベクトルを作成するよう依頼し、そのベクトルとそれをシードしたテキストの両方をデータベースに保存できます。 **後で質問されたときに、同じモデルでその質問を同様に実行し、結果のベクトルを使用してデータベース内で最も関連性の高い埋め込みを検索できます。** 必ずしも完全に一致するものを探すわけではなく、十分に近いものだけを探します。 ここでの「近い」は文字通りに受け取ることができます。 ルックアップは通常、コサイン類似度などの距離測定を使用する関数を使用して実行されます。



# GraphRAGの概要

公式サイト
https://microsoft.github.io/graphrag/

GitHubリポジトリ
https://github.com/microsoft/graphrag

FAQ (GraphRAG: Responsible AI FAQ)
https://github.com/microsoft/graphrag/blob/main/RAI_TRANSPARENCY.md

Microsoftの Project GraphRAGのページ
https://aka.ms/graphrag

arXivのプレプリント(査読前論文) From Local to Global: A Graph RAG Approach to Query-Focused Summarization
https://arxiv.org/html/2404.16130v1#:~:text=na%C3%AFve%20RAG%20produces%20the%20most%20direct%20responses%20across%20all%20comparisons

## （GraphRAGの前に）RAGとは？

Retrieval-Augmented Generation（「検索拡張生成」、検索によって強化された生成）

大規模言語モデルに外部のデータを組み合わせ、外部のデータに沿った回答を生成すること。

https://www.ibm.com/blogs/solutions/jp-ja/retrieval-augmented-generation-rag/

> LLMが持つ知識の内部表現を補うために外部の知識ソースにモデルを接地させる（グラウンドさせる）ことで、LLMが生成する回答の質を向上するAIのフレームワーク

> 不正確な情報や誤解を招く情報の「幻覚（ハルシネーション）」を生成したりする可能性が低くなる。

Azureでは「Azure OpenAI on your data」を使用することで比較的簡単にRAGを実現できる。

https://learn.microsoft.com/ja-jp/azure/ai-services/openai/concepts/use-your-data?tabs=ai-search%2Ccopilot

## GraphRAGとは？

https://github.com/microsoft/graphrag/blob/main/RAI_TRANSPARENCY.md#what-is-graphrag

GraphRAGは、AIベースのコンテンツ解釈および検索機能。LLM を使用して、データを解析して「ナレッジ グラフ」を作成し、ユーザー提供のプライベート データセットに関するユーザーの質問に答える。

GraphRAGは、大規模言語モデル(LLM)を使用して、任意のテキストドキュメントのコレクションからエンティティとその関係を詳述する包括的なナレッジグラフを作成する。

文章の中に出てくる人物や場所などの「エンティティ」と、それらの関連性「リレーションシップ」をあらかじめ分析した「ナレッジグラフ」を作る。

このグラフにより、テキスト全体を広く理解する必要がある複雑なクエリに対する応答を生成できる。

ソーシャルメディア、ニュース記事、職場の生産性、化学など、さまざまなシナリオに適用した場合、従来のRAGアーキテクチャよりも有用な結果が得られることが確認されている。

GraphRAGに対し、従来型のRAGのことを「ナイーブなRAG」や「ベースラインRAG」と呼ぶ。

※ITの世界で「ナイーブな」といった場合、単純・シンプルな実装といった意味。

## GraphRAGが登場したことによって、ナイーブなRAGは不要となるか？ 常にGraphRAGを使うべきか？

No. GraphRAGの論文によれば、 従来の検索エンジンやベクトル検索を用いたRAGの得意とする分野、キーワード検索やセマンティック検索を用いた直接的な質問（例：「〇〇について教えてください」）の回答に対しては、従来のRAGの方が優れているとされている。

https://arxiv.org/html/2404.16130v1#:~:text=na%C3%AFve%20RAG%20produces%20the%20most%20direct%20responses%20across%20all%20comparisons

GraphRAGは、テキスト全体を広く理解する必要がある複雑なクエリに対する、より正確な応答を生成できる。

## GraphRAGが出力する回答は正確か？

従来のRAGよりも高い精度で回答することができるが、必ずしも「正解」を出力するとは限らない。

https://github.com/microsoft/graphrag/blob/main/RAI_TRANSPARENCY.md#what-are-graphrags-intended-uses

> GraphRAGは、複雑な情報トピックについて高度な洞察を提供することができますが、GraphRAGが生成した応答を検証し、強化するためには、その答えをドメインの専門家が人間で分析する必要があります。

## GraphRAGは誰が（どこが）開発している？

https://www.microsoft.com/en-us/research/blog/graphrag-unlocking-llm-discovery-on-narrative-private-data/

GraphRAGは、Microsoft Researchの研究者達によって開発された。現在はオープンソース化されており、世界中の開発者が開発に参加している。

## GraphRAGはマイクロソフトの製品か？

No. GraphRAGそのものはMicrosoft Researchによって研究されているが、実装（ https://github.com/microsoft/graphrag ）はMIT Licenseが適用されるオープンソースソフトウェアである。

（現在のところ）特にAzureのサービスなどとしては製品化されていない。

## GraphRAGはどのようなテクノロジで開発されているか？

Python。操作のためのJupyter Notebookインターフェースも利用できる。

以下のGitHubリポジトリからコードを入手できる。

https://github.com/microsoft/graphrag

## GraphRAGのコストは？

GraphRAGそのものはオープンソースであり、無料で利用できる。Microsoftからライセンスを購入する必要はない。

ただしGraphRAGを実際に動かすためには大規模言語モデルやサーバーといったリソースが必要となり、その部分の料金がかかる。

データ量や使い方にもよるが、1回の環境構築と実験で、数千円程度の費用がかかる場合が多い。

特にインデックス（ナレッジグラフ）作成の時点で多くの費用が発生する。


## GraphRAGはどうやって利用すればよいのか？

GraphRAGの実態はPythonのライブラリであり、以下のコマンドでインストールできる。

```
pip install graphrag
```

インストールしたら、ワークスペース（作業場所のディレクトリ）を初期化（作成）し、設定ファイルにLLMの種類・エンドポイントのアドレス・APIキー・モデル名などをセットし、ナレッジベース（インデックス）を作成する。

ナレッジベースが作成されたら、質問文をGraphRAGに送信すると、内部でナレッジベースを使用した検索が行われ、取り出した情報を使用して、LLMによる回答が生成される。

これら一連の操作にはPythonのノートブックが利用できる。

## GraphRAGを利用するにはAzureやOpenAIが必要か？

GraphRAGを利用するためにはAzureやOpenAIを使うことができるが、必ずしもAzureやOpenAIを使う必要はない。

AWSやGoogle Cloud、オンプレミスサーバーなどでも実装できる。
https://qiita.com/orc_jj/items/5d0858663fb663cd3f7d

https://active.nikkeibp.co.jp/atcl/act/19/00012/080501295/

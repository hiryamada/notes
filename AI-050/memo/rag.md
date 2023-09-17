# RAG



■RAG

RAG パイプライン
Retrieval Augmented Generation

RAGを比較的簡単に実現する方法として注目されているのが、Azure OpenAI Serviceの「on your data」

https://devblogs.microsoft.com/dotnet/demystifying-retrieval-augmented-generation-with-dotnet/

https://blog.shibayan.jp/entry/20230904/1693828326
https://zenn.dev/microsoft/articles/ad14d45121abe7

これまでも、いわゆる Retrieval Augmented Generation (RAG) というデザインパターンに則ればユーザー独自のデータに対するチャット検索を実現することはできましたが、やや複雑な処理を実装する必要がありました。この開発を省力化してくれる点が On Your Data のブレイクスルーのひとつです。


既に広く認識され始めていますが、生成系の大規模言語モデル (LLM) はあくまでも Web 上の膨大なテキストデータをもとに学習を行い、次に来る可能性の高い単語の予測を繰り返すことでそれらしいテキストを生成します。そのため、(事実として) 正しくない情報が出力されるハルシネーションが起こり得ることに留意する必要があり、LLM に対して直接知識を問うのはあまり適した使い方ではありません。

しかし、一方で LLM を情報検索に応用したいというモチベーションが少なからず存在していることも事実で、最近はその解決策として Retrieval Augmented Generation (RAG) と呼ばれるデザインパターンが一般的になりつつあります。RAG は一言で表現するとナレッジベースの外部化で、RAG ではユーザーからの問いに対して、バックエンドに置いたナレッジベース (e.g. Azure Cognitive Search) で検索を行い、その結果を踏まえてユーザーのからの問いかけに対する回答を生成します。

ちなみに、このように LLM に根拠の情報 (e.g. 独自データに対する検索、Web 検索、等) に基づかせて回答を行うことをグラウンディング (Grounding) と呼びます。


■ハルシネーションとグラウンディング、RAG

https://zenn.dev/microsoft/articles/ad14d45121abe7


既に広く認識され始めていますが、生成系の大規模言語モデル (LLM) はあくまでも Web 上の膨大なテキストデータをもとに学習を行い、次に来る可能性の高い単語の予測を繰り返すことでそれらしいテキストを生成します。そのため、(事実として) 正しくない情報が出力されるハルシネーションが起こり得ることに留意する必要があり、LLM に対して直接知識を問うのはあまり適した使い方ではありません。

しかし、一方で LLM を情報検索に応用したいというモチベーションが少なからず存在していることも事実で、最近はその解決策として Retrieval Augmented Generation (RAG) と呼ばれるデザインパターンが一般的になりつつあります。RAG は一言で表現するとナレッジベースの外部化で、RAG ではユーザーからの問いに対して、バックエンドに置いたナレッジベース (e.g. Azure Cognitive Search) で検索を行い、その結果を踏まえてユーザーのからの問いかけに対する回答を生成します。

ちなみに、このように LLM に根拠の情報 (e.g. 独自データに対する検索、Web 検索、等) に基づかせて回答を行うことをグラウンディング (Grounding) と呼びます。

■.NETでのRAG実装例

https://devblogs.microsoft.com/dotnet/demystifying-retrieval-augmented-generation-with-dotnet/


■Cosmos DB

https://learn.microsoft.com/ja-jp/azure/cosmos-db/rag-data-openai

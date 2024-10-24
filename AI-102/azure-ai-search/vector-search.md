# Azure AI Search の ベクトル検索

参考: Microsoft社員Nobusuke Hanagasakiさんが書いた解説記事
https://qiita.com/nohanaga/items/f710cac82072b63bc73f


https://learn.microsoft.com/ja-jp/azure/search/search-get-started-vector

2023/7/18 ベクトル検索 パブリックプレビュー。
https://azure.microsoft.com/ja-jp/updates/public-preview-vector-search-a-feature-of-azure-cognitive-search/

https://techcommunity.microsoft.com/t5/ai-azure-ai-services-blog/announcing-general-availability-of-vector-search-and-semantic/ba-p/3978525
2023/11/15 一般提供開始

「HotelName」に対して「HotelNameVector」、「Description」に対して「DescriptionVector」といったように、検索用のベクトル情報を持ったインデックスを作成する。

クエリ実行時に、検索用のベクトル（ベクトルクエリ）を指定する。

[ベクトル検索のドキュメント](https://learn.microsoft.com/ja-jp/azure/search/search-get-started-vector#run-queries)では、以下のようなベクトル検索のバリエーションが紹介されている。

- 単一ベクトル検索
  - フィルター:なし、キーワードクエリ:なし、セマンティックランキング:なし
- フィルターを使用した単一ベクトル検索
  - フィルター:指定、キーワードクエリ:なし、セマンティックランキング:なし
- ハイブリッド検索
  - フィルター:なし、キーワードクエリ:指定、セマンティックランキング:なし
- フィルターを使用したセマンティック ハイブリッド検索
  - フィルター:指定、キーワードクエリ:指定、セマンティックランキング:使用

■ハイブリッド検索

ベクトル検索の一種で、ベクトルクエリとキーワードクエリの両方を指定するパターンのこと。

■どれがいちばんよい検索結果となるのか？

https://techcommunity.microsoft.com/t5/ai-azure-ai-services-blog/azure-cognitive-search-outperforming-vector-search-with-hybrid/ba-p/3929167

上記の調査結果によれば、「ハイブリッド検索＋セマンティックランキング」のパターンのとき、もっともよい検索結果が得られた。

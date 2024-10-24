# Azure AI Searchの「価格レベル」

価格
https://azure.microsoft.com/ja-jp/pricing/details/search/

価格レベル（サービスレベル）の選択
https://learn.microsoft.com/ja-jp/azure/search/search-sku-tier

コストの計画と管理
https://learn.microsoft.com/ja-jp/azure/search/search-sku-manage-costs


■価格レベル

- F(Free) 50 MB、最大 1 個のレプリカ、最大 1 個のパーティション、最大 1 個の検索ユニット。サブスクリプションで1つだけ利用可
- B(Basic): 15 GB、最大 3 個のレプリカ、最大 3 個のパーティション、最大 9 個の検索ユニット
- S(Standard): 160 GB/パーティション、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S2(Standard 2): 512 GB/パーティション、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S3(Standard 3): 1 TB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- S3HD(Standard High Density): 1 TB/パーティション*、最大 12 個のレプリカ、最大 3 個のパーティション、最大 36 個の検索ユニット
- L1(ストレージ最適化): 2 TB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット
- L2(ストレージ最適化): 4 TB/パーティション*、最大 12 個のレプリカ、最大 12 個のパーティション、最大 36 個の検索ユニット


価格レベルにより、使用できる機能が変化する。https://learn.microsoft.com/ja-jp/azure/search/search-sku-tier#feature-availability-by-tier

リソースを作成後に価格レベルを変更することはできない。必要であれば、リソースを作り直す。インデックスはバックアップとリストアによって移行するか、再作成する。以下を参照。

- 価格レベル変更は不可 https://learn.microsoft.com/ja-jp/azure/search/search-sku-tier#tier-upgrade-or-downgrade
- インデックスのバックアップとリストア（等）のツール https://github.com/Azure-Samples/azure-search-dotnet-utilities

- リソースを作り直す手順 https://learn.microsoft.com/ja-jp/azure/search/search-howto-move-across-regions

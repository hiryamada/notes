## 価格レベル

https://azure.microsoft.com/ja-jp/pricing/details/search/

※検索ユニット＝パーティション数 x レプリカ数

- Free
  - 50 MB x パーティション (1)
  - 1 レプリカ
  - 無料
- Basic
  - 15 GB x パーティション (1 - 3)
  - 1 - 3 レプリカ
  - $97.09 x 検索ユニット
- Standard S1
  - 160 GB x パーティション (1 - 12)
  - 1 - 12 レプリカ
  - $324.12 x 検索ユニット
- Standard S2
  - 512 GB x パーティション (1 - 12)
  - 1 - 12 レプリカ
  - $1295.02/月 x 検索ユニット
- Standard S3
  - 1 TB x パーティション (1 - 12)
  - 1 - 12 レプリカ
  - $2,592.96/月 x 検索ユニット
- Standard S3 高密度
  - 1 TB x パーティション (1 - 3)
  - 1 - 12 レプリカ
  - $2,642.69/月 x 検索ユニット
- Storage Optimized L1
  - 2 TB x パーティション (1 - 12)
  - 1 - 12 レプリカ
  - $2,802.47/月 x 検索ユニット
- Storage Optimized L2
  - 4 TB x パーティション (1 - 12)
  - 1 - 12 レプリカ
  -$5,604.21/月 x 検索ユニット

## リソース作成後にパーティション数は変更できる？

できる。
https://learn.microsoft.com/ja-jp/azure/search/search-capacity-planning
## リソース作成後にレプリカ数の変更はできる？

できる。
https://learn.microsoft.com/ja-jp/azure/search/search-capacity-planning
## リソース作成後に価格レベルの変更はできる？

できない。
https://learn.microsoft.com/ja-jp/azure/search/search-sku-manage-costs#faq
## 使用していない間リソースを停止させてコストを節約できる？

できない。
https://learn.microsoft.com/ja-jp/azure/search/search-sku-manage-costs#faq

# Azure SQL Database と Azure SQL Managed Instance のサービス レベル

https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tiers-general-purpose-business-critical

■歴史

2010/2/1 Microsoft SQL Azure Database (SQL Azure Database) 一般提供開始. エディションはWebとBusiness（データベースの容量に応じた課金）。
https://azure.microsoft.com/ja-jp/blog/sql-azure-database-now-generally-available-slas-in-effect/

```
SQL Azure Database (単一データベース)
  エディション: Web, Business
```

2014/4/3 Windows AzureがMicrosoft Azureへと名称変更
https://azure.microsoft.com/en-us/blog/upcoming-name-change-for-windows-azure/

```
Azure SQL Database (単一データベース)
  エディション: Web, Business
```

2014/5/26頃 Basic, Standard, Premium サービス層、DTU購入モデルを発表。
https://sqlazure.jp/b/windows-azure/1847/

2014/8/26 Azure SQL Database で、Basic, Standard, Premium サービス層の提供を開始
https://azure.microsoft.com/en-us/blog/new-azure-sql-database-service-tiers-generally-available-in-september-with-reduced-pricing-and-enhanced-sla/

2015/9 Web, Businessエディションが廃止
https://satonaoki.wordpress.com/2015/08/05/azure-sql-db-web-business-retirement/

```
Azure SQL Database (単一データベース)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
```

2016/5/11 Azure SQL Database で、エラスティック プール の一般提供を開始
https://azure.microsoft.com/en-us/blog/azure-sql-database-elastic-pools-now-generally-available/

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
```

2018/4/4 「購入モデル」として「仮想コア購入モデル」が追加。従来の「DTU 購入モデル」よりも[いくつかのメリットが利用できる](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tiers-sql-database-vcore)。「仮想コア購入モデル」では「General Purpose」 と 「Business Critical」 の 2 つのサービス レベルが導入された。
https://azure.microsoft.com/ja-jp/blog/a-flexible-new-way-to-purchase-azure-sql-database/

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
  仮想コア購入モデル: サービスレベル General Purpose, Business Critical
```

2018/3/7 Azure SQL Database Managed Instance 一般提供開始
https://azure.microsoft.com/en-us/blog/migrate-your-databases-to-a-fully-managed-service-with-azure-sql-database-managed-instance/

2018/9/24 Azure SQL Database Managed Instance 汎用版(General Purpose) 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-sql-database-managed-instance-general-purpose-coming-soon/

※[Azure SQL Database Managed InstanceではDTU購入モデルはサポートされていない。](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tiers-dtu)

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
  仮想コア購入モデル: サービスレベル General Purpose, Business Critical
Azure SQL Database Managed Instance
  仮想コア購入モデル: サービスレベル General Purpose
```

2019/5/6 Azure SQL Database Hyperscale 単一データベースでのサポート 一般提供開始。スケーラビリティに優れ、ワークロードのニーズにオンデマンドで適応できる新しいサービス レベル。データベースごとに最大 100 TB まで迅速にスケールアップ可能。ストレージ リソースの事前プロビジョニングが不要。
https://azure.microsoft.com/en-us/updates/azure-sql-database-hyperscale-support-for-single-databases-is-now-available/

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
  仮想コア購入モデル: 
    サービスレベル General Purpose, Business Critical, Hyperscale
Azure SQL Database Managed Instance
  仮想コア購入モデル: サービスレベル General Purpose
```

2019/5/23 Azure SQL Managed Instance で、Business Critical 一般提供開始
https://techcommunity.microsoft.com/t5/azure-sql/azure-sql-managed-instance-business-critical-tier-is-generally/ba-p/386284

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
  仮想コア購入モデル: 
    サービスレベル General Purpose, Business Critical, Hyperscale
Azure SQL Database Managed Instance
  仮想コア購入モデル: サービスレベル General Purpose, Business Critical
```

2019/11/4 Azure SQL Database サーバーレス 一般提供開始。使用されているコンピューティングリソースを毎秒測定して課金
https://azure.microsoft.com/ja-jp/updates/azure-sql-database-serverless-is-now-generally-available/

```
Azure SQL Database (単一データベース/エラスティック プール)
  DTU購入モデル: サービスレベル Basic, Standard, Premium
  仮想コア購入モデル: 
    サービスレベル 
      General Purpose (プロビジョニング/サーバーレス)
      Business Critical
      Hyperscale
Azure SQL Database Managed Instance
  仮想コア購入モデル: サービスレベル General Purpose, Business Critical
```

■購入モデル

https://docs.microsoft.com/ja-jp/azure/azure-sql/database/purchasing-models

「DTU購入モデル」または「仮想コア購入モデル」。「仮想コア購入モデル」が推奨となっている。

- DTU購入モデル
  - 2014/8/26～
  - 「Azure SQL Database」でのみ利用できる
  - 必要な性能を「データベース トランザクション ユニット (DTU)」で指定。
  - DTUは、CPU、メモリ、IO（入出力）を組み合わせた、性能の目安の値。
  - データベースの負荷が高い場合、データベースによりたくさんのDTUを割り当てる。
- 仮想コア購入モデル
  - 2018/4/4～
  - 「Azure SQL Database」と「Azure SQL Database Managed Instance」で利用できる
  - ハードウェアの世代、仮想コア（論理CPU）数、メモリ量、ストレージサイズなどを事前に指定する「プロビジョニング済み」、または、使用されているコンピューティングリソースを毎秒測定して課金を計算する「[サーバーレス](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/serverless-tier-overview)」から選択。

■「DTU購入モデル」のサービス レベル

https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tiers-dtu

「Basic」、「Standard」、「Premium」の3種類がある。

いずれも99.99% のアップタイムSLAをサポート。

- Basic
  - 最大バックアップ保持期間: 7日
  - IO待機時間（概算）: 読み取り 5 ミリ秒, 書き込み 10 ミリ秒
- Standard
  - 最大バックアップ保持期間: 35日
  - IO待機時間（概算）: 読み取り 5 ミリ秒, 書き込み 10 ミリ秒
- Premium
  - 最大バックアップ保持期間: 35日
  - IO待機時間（概算）: 読み取り 2 ミリ秒, 書き込み 2 ミリ秒
  - 「[インメモリOLTP](https://docs.microsoft.com/ja-jp/sql/relational-databases/in-memory-oltp/overview-and-usage-scenarios?view=sql-server-ver15)」をサポート

■「仮想コア購入モデル」のサービス レベル

https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tiers-sql-database-vcore#service-tiers

「General Purpose」、「Business Critical」、「Hyperscale」の3種類がある。

- [General Purpose](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tier-general-purpose)
  - 一般的なパフォーマンスと可用性の要件を持つほとんどのワークロード向け
  - 予算を抑えたレベル
  - SLA: 99.99%
  - 2018/4/4～
- [Business Critical](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tier-business-critical)
  - 厳しい可用性要件を持つパフォーマンスに依存するワークロード向け
  - SLA: 99.995%
  - 2018/4/4～
- [Hyperscale](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/service-tier-hyperscale)
  - ほとんどのビジネス ワークロード向け
  - 拡張性の高いストレージ、読み取りスケールアウト、およびデータベースの高速復元機能を備える
  - SLA: 99.95% (セカンダリレプリカが1つの場合) / 99.99% (2つ以上の場合)
  - 2019/5/6～

■SQLエラスティックプール

適用対象: Azure SQL Database のみ

[2016/5/11 Azure SQL Database で、エラスティック プール の一般提供を開始](https://azure.microsoft.com/en-us/blog/azure-sql-database-elastic-pools-now-generally-available/)

[解説PDF](../AZ-500/pdf/mod3/Elastic%20Pool.pdf)

サーバー内には、「SQLエラスティックプール」（以下、プール）を作成することができる。

プールの作成時に、プールの名前や性能（後述）などを指定。

新しいデータベースは、プールの中に作成することも、プールの外（サーバー内）に作成することもできる。

また、プールの外に作成されている既存のデータベースを、プールに移動したり、プールの中にあるデータベースを、プールの外に移動したりすることができる。

プール内の複数のデータベースは、プールに指定された性能を共有する。

コスト: 

- プールが存在していた時間の最上位の eDTU または仮想コアを使用して 1 時間単位で行われる。
- プール内のデータベース単位の請求はない。

使い方:

- 使用パターンが変動し、予測が難しいような、複数のデータベースを束ねる
- トータルのコストを節約することができる

[コストの例(グラフ)](../AZ-303/pdf/mod08/elastic%20pool説明用グラフ.pdf)
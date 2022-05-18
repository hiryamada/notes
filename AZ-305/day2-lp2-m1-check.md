# 知識チェック 解説

[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-for-high-availability/8-knowledge-check)

# 1. HR（人事）システムで、VM（仮想マシン）を使用している。99.99% の SLA が必要である

→可用性ゾーンを使用し、複数のVMを複数の可用性ゾーンにデプロイすることで、99.99% のSLAが提供される。

# 2. Azure SQL Databaseを運用している。同じリージョンまたはセカンダリ リージョンにデータベース レプリカを作成したい

→Azure SQL Databaseの [「アクティブな地理的レプリケーション」（Active geo-replication）](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/active-geo-replication-overview?view=azuresql) を使用する。プライマリ データベースに対し、継続的に同期される、読み取り可能なセカンダリ データベースを作成できる。セカンダリデータベースは、プライマリと同じリージョンでも、別のリージョンでもよい。

# 3. Web アプリケーションをプライマリリージョンとセカンダリ リージョンで稼働させている。WebアプリケーションではTLS（SSL）を使用したい。また、平常時はプライマリリージョンでトラフィックを処理し、プライマリリージョンに障害が発生した場合、トラフィックがセカンダリリージョンに自動的にフェールオーバーされるようにしたい。

→Azure Front Doorを使用する。Azure Front Doorでは、エンドツーエンドの [TLS/SSL 暗号化（TLS/SSLオフロード）](https://docs.microsoft.com/ja-jp/azure/frontdoor/concept-end-to-end-tls) がサポートされている。また、複数のリージョンへのトラフィックのルーティング、[正常性プローブ](https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-health-probes)による、[正常なリージョンへのトラフィックのルーティング](https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-routing-architecture?pivots=front-door-standard-premium#select-origin)（自動的なフェールオーバー）可能。

# 複数のリージョンを使用した冗長構成例

https://docs.microsoft.com/ja-jp/azure/architecture/reference-architectures/app-service-web-app/multi-region

```
        ユーザー <-----> Azure DNS(名前解決)
        ↓
        Azure Front Door
         |            |
プライマリリージョン   セカンダリリージョン
         |            |
    App Service     App Service
         |            |
    SQL Database    SQL Database
         │            ↑
         └────────────┘ アクティブgeoレプリケーション
```


- プライマリリージョン
  - 平常時に使用
- セカンダリリージョン
  - プライマリリージョンが使用できない場合に使用
- Azure Front Door
  - アプリケーションのパフォーマンスを高速化
  - 静的なコンテンツのキャッシュ
  - SSLオフロード
  - WAF
  - [優先順位に基づくルーティング](https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-routing-methods#priority-based-traffic-routing)を使用
    - プライマリの正常性を監視（正常性プローブ）
    - 正常であればプライマリにトラフィックをルーティング
    - プライマリに障害が発生した場合はセカンダリ（次の優先度のバックエンド）へトラフィックをルーティング
- Azure SQL Database
  - [アクティブgeoレプリケーション](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/active-geo-replication-overview)
  - 自動または手動でフェールオーバー

■複数のリージョンを使用するアプリケーションの構成パターン

- アクティブ/アクティブ
  - プライマリとセカンダリを両方とも使用
  - プライマリまたはセカンダリの障害発生時の切り替えが不要
  - 障害発生を見越して、すべてのトラフィックを処理できるキャパシティを、プライマリ・セカンダリ双方に確保する必要がある
  - RTO: 短い
  - コスト: 高
- アクティブ/パッシブ(ホットスタンバイ)
  - プライマリに障害発生時にセカンダリに切り替え
  - セカンダリ側のVM等を起動させておく
  - RTO: 中
  - コスト: 中
- アクティブ/パッシブ(コールドスタンバイ)
  - プライマリに障害発生時にセカンダリに切り替え
  - セカンダリ側のVM等を停止させておく（または切替時にデプロイする）
    - DBはレプリケーションが必要なため、セカンダリ側も起動させておく
  - RTO: 長い
  - コスト: 低い

■参考: リージョンペア

[リージョンペアの解説](../general/region-pair.md)
# 信頼性

https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/


■信頼性（Reliability）とは？

https://docs.microsoft.com/ja-jp/azure/architecture/framework/

障害から回復して動作を続行するシステムの能力。

■クラウドにおける信頼性の考え方

https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/overview

https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/principles

抜粋:

- 障害は起こりうるものと考える
  - 単一障害点を避ける
- 障害からの回復を考慮する
  - 複数の可用性ゾーンを利用する
  - 可用性セット（障害ドメイン・更新ドメイン）を利用する
- 障害に備えてアプリケーションを設計・テストする
  - サービス呼び出しの再試行ロジックをアプリに組み込む
  - 障害を想定したテストを行う
    - [Chaos Engineering](https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/chaos-engineering)
- 災害からの回復（ディザスタリカバリー）を計画する
  - 複数のリージョンを利用する
  - リージョン間でレプリケーションを行う
- 監視を行う

■Azureのサービスにおける回復性

https://docs.microsoft.com/ja-jp/azure/architecture/checklist/resiliency-per-service

抜粋:

- Azure Load Balancer + VM
  - 少なくとも2つのVMをプロビジョニングする
- Application Gateway
  - 少なくとも2つのインスタンスをプロビジョニングする
- Cosmos DB
  - リージョン間でデータベースをレプリケートする
- ストレージアカウント
  - RA-GRSを使用する
  - プライマリリージョンの障害時、セカンダリリージョンからデータを読み込むことができる
- VM（仮想マシン）
  - 可用性セットを利用する
  - マネージドディスクを利用する
  - VMをバックアップする


■参考: Skillpipe資料（Azure公式ドキュメントとの整合性がない）

- 要件を定義する
- アーキテクチャのベスト プラクティスを使用する
- Azure サービスの依存関係
- シミュレーションと強制フェールオーバーを使用したテスト
- 常にアプリケーションをデプロイ
- アプリケーションの正常性を監視する
- 障害や災害への対応

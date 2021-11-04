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

■可用性セット

https://docs.microsoft.com/ja-jp/azure/virtual-machines/availability-set-overview

- 1つのデータセンター内の論理的なグループ。
- 同じ「役割」の複数のVMを運用する際に、可用性セットに入れることで、可用性を向上させることができる。
- 1つの「可用性セット」は「障害ドメイン」と「更新ドメイン」で構成される。
  - 「障害ドメイン」: 電源やネットワークスイッチを共有する範囲。
  - 「更新ドメイン」: 基盤となるプラットフォームの更新による再起動が行われる範囲。
- 可用性セットは、可用性ゾーンが使えないリージョンでも利用できる（西日本など）

使い方
- 「可用性セット」というリソースを作成
- 「可用性セット」内にVMをデプロイする

[可用性セットまとめPDF](../AZ-104/pdf/mod08/可用性セット.pdf)

■可用性ゾーン

https://docs.microsoft.com/ja-jp/azure/availability-zones/az-overview?context=/azure/virtual-machines/context/context#availability-zones

- リージョンによっては可用性ゾーンに対応している。
  - 東日本リージョンなど
  - 対応しているリージョンでは、少なくとも3つのゾーンが利用できる
    - ゾーン1
    - ゾーン2
    - ゾーン3
    - ※「少なくとも3つ」とあるが、実際には、4つ以上のゾーンを持ったリージョンは今の所存在しない。
- ゾーン
  - 1つ以上のデータセンターで構成されている。
  - 電源・冷却・ネットワークが独立して備わっている。
    - あるゾーンの電源障害があったとしても、別のゾーンはその影響をうけない。

可用性ゾーンに対応したリージョン:

https://docs.microsoft.com/ja-jp/azure/availability-zones/az-region#azure-regions-with-availability-zones

[可用性ゾーンまとめPDF](../AZ-104/pdf/mod08/可用性ゾーン.pdf)


■可用性セット、可用性ゾーン、複数のリージョンによるSLAの違い

https://azure.microsoft.com/mediahandler/files/resourcefiles/azure-resiliency-infographic/Azure_resiliency_infographic.pdf

- 単一のVMでプレミアムストレージを利用: 99.9% SLA
- 可用性セット: 99.95% SLA
- 可用性ゾーン: 99.99% SLA
- 複数のリージョン (リージョンレベルの障害や自然災害に対応。SLA定義はない)

※「可用性ゾーン」、「複数のリージョン」の活用に関してはモジュール11で解説。

■信頼性を高めるためのクラウド設計パターン

https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/reliability-patterns

参考:
- [AWSのクラウドデザインパターン](http://aws.clouddesignpattern.org/index.php/)
- [Microsoftのクラウド設計パターン](https://docs.microsoft.com/ja-jp/azure/architecture/patterns/)


クラウドデザインパターンとは: （「[AWSのクラウドデザインパターン](http://aws.clouddesignpattern.org/index.php/)」より抜粋）

> クラウドを使ったシステムアーキテクチャ設計を行う際に発生する、典型的な問題とそれに対する解決策・設計方法を、分かりやすく分類して、ノウハウとして利用できるように整理したものである。

> これまで多くのクラウドアーキテクト達が発見してきた、もしくは編み出しきた設計・運用のノウハウのうち、クラウド上で利用が可能なものをクラウドデザインのパターンという形式で一覧化し、暗黙知から形式知に変換したものであるといえる。


■信頼性のためのベストプラクティス（Skillpipe資料より）

- 要件を定義する
  - 可用性メトリック
    - [MTBF - 平均故障間隔 (Mean Time Between Failure)](https://ja.wikipedia.org/wiki/%E5%B9%B3%E5%9D%87%E6%95%85%E9%9A%9C%E9%96%93%E9%9A%94)
      - 故障が発生してから、次回の故障が発生するまでの平均の長さ
      - 故障しにくさ
    - [MTTR - 平均修復時間 (Mean Time To Repair)](https://ja.wikipedia.org/wiki/%E5%B9%B3%E5%9D%87%E4%BF%AE%E5%BE%A9%E6%99%82%E9%96%93)
      - 修理に要する時間
      - 修理しやすさ
  - 復旧メトリック
    - [RPO - 復旧時点目標 (Recovery Point Objective)](https://ja.wikipedia.org/wiki/%E5%9B%9E%E5%BE%A9%E3%83%9D%E3%82%A4%E3%83%B3%E3%83%88%E7%9B%AE%E6%A8%99)
      - 短いほど、障害発生時に、より直近のデータが維持される。
      - 例: 「RPO=24時間」
        - 24時間ごとにバックアップ
        - 最悪ケース:
          - 次のバックアップが始まる直前に障害発生
          - 直近24時間分のデータが失われる
    - [RTO - 目標復旧時間 (Recovery Time Objective)](https://ja.wikipedia.org/wiki/%E3%83%87%E3%82%A3%E3%82%B6%E3%82%B9%E3%82%BF%E3%83%AA%E3%82%AB%E3%83%90%E3%83%AA#%E7%9B%AE%E6%A8%99%E5%BE%A9%E6%97%A7%E6%99%82%E9%96%93)
      - 障害発生時から回復までの目標時間。短いほど早く回復。
        - 例: 「RTO=1時間」
          - 障害発生時、1時間以内にシステムが復旧し、利用可能になる
- アーキテクチャのベスト プラクティスを使用する
  - [障害モード分析](https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/design-resiliency#build-resiliency-with-failure-mode-analysis)
- Azure サービスの依存関係
  - [リージョン別の利用可能なAzure製品](https://azure.microsoft.com/ja-jp/global-infrastructure/services/)
- シミュレーションと強制フェールオーバーを使用したテスト
  - [Chaos Engineering](https://docs.microsoft.com/ja-jp/azure/architecture/framework/resiliency/chaos-engineering)
- 常にアプリケーションをデプロイ
  - [インフラのデプロイを自動化するツールを利用する](https://docs.microsoft.com/ja-jp/azure/virtual-machines/infrastructure-automation)
- アプリケーションの正常性を監視する
  - 正常性プローブ
- 障害や災害への対応
  - ディザスタリカバリーを計画・テストする
  - 特定リージョン全体の障害を想定する
    - 別リージョンへのデプロイを計画・テストする


## セルフホステッド エージェントの設定



### Azure Pipelines との通信

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#communication)

エージェント（Azure Pipelinesのエージェントソフトウェアが登録されたマシン）とAzure Pipelineの通信は、エージェントから開始される。

エージェントがオンプレミスにある場合、オンプレミスからインターネットへのHTTPS（TCP ポート443番）が許可されていればよい。

エージェントは、Azure Pipelinesに定期的にアクセスし、実行すべきジョブがあれば、ジョブを実行する。

### ターゲットサーバーに展開する通信

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#communication-to-deploy-to-target-servers)

「ターゲットサーバー」とは、デプロイ先のサーバーを表す。ターゲットサーバーは、Azure VMの場合もあれば、オンプレミスのサーバーの場合もある。

Azure pipelineから、オンプレミスのサーバーにデプロイを行いたい場合、オンプレミスの「セルフホステッド エージェント」からデプロイを行う必要がある。

なお、Skillpipeドキュメントに「LOS」「見通し線」「視界」などと書かれているもの「Line of sight」（見通し、直接通信ができること）の略およびその日本語訳だが、デプロイやファイアウォールの分野における一般的な表現（IT用語）ではないと思われる。
- 無線通信の[LOS](https://www.sophia-it.com/content/LOS) - 無線通信における送信機（トランスミッタ）と受信機（レシーバ）の間を結ぶ直線距離
- 軍事（火気、射撃）用語の「[照準線(line of sight)](https://www.mod.go.jp/atla/nds/Y/Y0005B.pdf)」 - 照準具又は照準装置と目標を結ぶ線

オンプレミスのKubernetesクラスターをコントロールすることもできる。[事例](https://yomon.hatenablog.com/entry/2020/04/pipeline_private)

### その他の考慮事項

- 認証
  - エージェントを登録するには「エージェントプールの管理者」である必要がある
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser#security)
- 個人用アクセストークン（PAT）
  - エージェントの登録時、PATは登録にのみ使用され、その後は使用されない。
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#personal-access-token-pat)
- 対話型とサービス
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#interactive-or-service)
- エージェントのバージョンとアップグレード
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#agent-version-and-upgrades)
- セルフホステッドエージェントのメリット
  - Microsoftホステッドはジョブ実行のたびにVMが破棄さえる
  - セルフホステッドエージェントは破棄されない
  - そのためキャッシュが効く、エージェントがすぐに稼働できる、といったメリットがある
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#private-agent-performance-advantages)
- 同じマシンへの複数のセルフホステッドエージェントのインストール
  - 可能
  - エージェントであまり多くの作業を行わない場合など

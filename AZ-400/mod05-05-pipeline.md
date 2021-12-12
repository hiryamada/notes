


### ジョブの種類

ジョブがどこで実行されるか。

- エージェントプールジョブ
  - 最も一般的な種類のジョブ
  - [エージェントプール](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/pools-queues?view=azure-devops&tabs=yaml%2Cbrowser)内のエージェントで実行される
- [コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
  - エージェント プール内のエージェント上のDocker/Windowsコンテナーでジョブを実行
  - 複数のコンテナーに対してそれぞれジョブを実行することもできる
    - [複数のジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops#multiple-jobs)
    - [方法（戦略）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/yaml-schema?view=azure-devops&tabs=schema%2Cparameter-schema#strategies)
- [デプロイグループジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-group-phases?view=azure-devops&tabs=yaml)
  - 「クラシック」のみ
  - [デプロイグループ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/deployment-groups/?view=azure-devops)（デプロイ先となるAzure VMのグループ）のVM上で実行されるジョブ
- [エージェントレスジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#agentless-tasks)
  - エージェントが不要なジョブ
    - [遅延](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/utility/delay?view=azure-devops)、[REST API呼び出し](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/utility/http-rest-api?view=azure-devops)など

## パイプラインとコンカレンシー（ジョブの同時実行）

複数のジョブを並列で実行するには。

プロジェクトで多数のジョブを実行する場合、基本的にはジョブはキュー（待ち行列）に入り、順番に実行されていく。

ただし、ジョブが「承認を待つ」状態になった場合は、別のジョブが起動される。承認が完了したらまたそのジョブはキューに入る。

[並列ジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted#what-is-a-parallel-job)を使用することで、複数のジョブを並列で実行することができる。

この仕組みを使うには追加の料金を支払う必要がある。（Azure Pipelines以外のCI/CDサービスでもだいたいそのような課金体系となっている）

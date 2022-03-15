
## エージェントプール

エージェントプールとは。

- エージェントプール
  - 定義
    - エージェントの集まり
    - 組織で共有される
  - 使用方法
    - パイプラインを作成するときに、パイプラインで使用するプールを指定
    - [要求](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/demands)を満たすエージェントでタスクが実行される
  - エージェントプールの応用
    - [複数のチームでAzure Pipelinesを運用する場合、プールを使って、エージェントをグループ化して整理することができる](https://qiita.com/uhooi/items/66a669290226138639b0)
    - [エージェントプールの中のエージェントはランダムで選択されるので、特定のエージェントを使いたい場合には、そのエージェントが含まれるプールを作って、プールを指定する](https://qiita.com/uhooi/items/66a669290226138639b0)
  - デフォルトのエージェントプール
    - 「Azure Pipelines」という名前の事前定義されたエージェントプールがある
    - 「[Microsoft によってホストされるエージェント(Microsoft-hosted agents)](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml)」が用意されていて、すぐに利用できる
      - windows-2019
      - ubuntu-20.04
      - ubuntu-18.04
      - macOS-10.14
      - など
  - 作成方法
    - 組織の設定で、エージェントプールを作成
  - [エージェントのアップデート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/agents/agents?view=azure-devops&tabs=browser#agent-version-and-upgrades)
    - エージェントプールのエージェントをすべて（あるいは選択したものを）アップデートできる

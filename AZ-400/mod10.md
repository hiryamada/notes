# モジュール10: リリース戦略の設計

モジュール説明前の注意：モジュール10, 11では、再びパイプライン（Azure Pipeline）の話題に戻り、リリースおよびデプロイについて解説していく。

[モジュール5](mod05.md)で解説したように、Azure Pipelinesでは、「YAML」と「クラシック」と呼ばれる2種類のパイプラインを利用できる。

[2019年9月10日より、YAMLパイプラインが利用可能になり](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2018/sep-10-azure-devops-launch#configure-builds-using-yaml)、それまでのGUIで設定するパイプラインは「クラシック」と呼ばれるようになった。

- [クラシック](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-the-classic-interface)
  - ビジュアルデザイナー（GUI）で編集できる
  - **ビルドパイプライン**
  - **リリースパイプライン**
- [YAML](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax)(azure-pipelines.yml)
  - YAMLファイルを使用してパイプラインを定義
  - YAMLファイルは、コードと一緒に、リポジトリに格納できる

上記のように、「クラシック」のパイプラインでは、「ビルドパイプライン」と「リリースパイプライン」という2種類のパイプラインを組み合わせていた。一方、新しい「YAML」のパイプラインでは、「ビルドパイプライン」と「リリースパイプライン」といった区別はなく、一つのパイプラインの中でビルドとリリースを実行する。

[2020/6現時点で、クラシックパイプラインは、廃止になる予定はないが、Azure Pipelinesの新機能はYAMLパイプラインに先に追加されるとされている](https://github.com/MicrosoftDocs/azure-devops-docs/issues/6828)。実際、「[コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
」や「[テンプレート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)」といったいくつかの便利な機能は、YAMLパイプラインでしか利用できない。

クラシックのパイプラインは[YAMLパイプラインに移行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/migrate/from-classic-pipelines?view=azure-devops)することができる。

これらのことから、新規のプロジェクトでは、YAMLパイプラインを使用すべきと思われる。

以上の理由により、以降、本資料では、Azure Pipelineについて取り上げる場合、**「クラシック」のパイプラインの説明は省略し**、新しい「YAML」のパイプラインだけを説明する。



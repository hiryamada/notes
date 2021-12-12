
# YAMLパイプラインとクラシックパイプライン

ドキュメント上「YAML」と「クラシック」と呼ばれる。

[2019年9月10日より、YAMLパイプラインが利用可能になり](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2018/sep-10-azure-devops-launch#configure-builds-using-yaml)、それまでのパイプラインは「クラシック」と呼ばれるようになった。

- [クラシック](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-the-classic-interface)
  - ビジュアルデザイナー（GUI）で編集できる
  - 「クラシック」と呼ばれる
  - ビルドパイプライン
  - リリースパイプライン
- [YAML構文](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax)(azure-pipelines.yml)
  - YAMLファイルを使用してパイプラインを定義
  - YAMLファイルは、コードと一緒に、リポジトリに格納される


[YAMLとクラシックで利用できる機能](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#feature-availability)

たとえば「[コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
」や「[テンプレート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)」はYAMLでしか利用できない。

クラシックのパイプラインは[YAMLに移行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/migrate/from-classic-pipelines?view=azure-devops)することができる。

[クラシックパイプラインは、廃止になる予定はないが、Azure Pipelinesの新機能はYAMLパイプラインに先に追加されるとされている](https://github.com/MicrosoftDocs/azure-devops-docs/issues/6828)。このことから、新規のプロジェクトでは、YAMLパイプラインを使用すべきと思われる。


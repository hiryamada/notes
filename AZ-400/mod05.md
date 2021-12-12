# モジュール5 Azure Pipelinesの構成


- [DevOps のCI/CDパイプラインの概念](mod05-01-cicd.md)
- [Azure Pipelines](mod05-02-azure-pipeline.md)
- [エージェント](mod05-03-agent.md)
- [エージェントプール](mod05-04-agent-pool.md)
- [パイプライン](mod05-05-pipeline.md)
- [オープンソースでのAzure Pipelinesの利用](mod05-06-azure-pipeline-oss.md)
- [YAMLパイプラインとClassicパイプライン](mod05-07-yaml-and-classic.md)


## ラボ

- 基本
  - Azure DevOpsの「Organization Settings」に移動
  ![](images/ss-2021-12-12-22-27-43.png)
    - PipelinesのParallel Jobsを選択
    ![](images/ss-2021-12-12-22-28-00.png)
    - Private projectsのMicrosoft-hostedのChangeをクリック
    ![](images/ss-2021-12-12-22-28-23.png)
    - Pipelines for private projectsのMS Hosted CI/CDのPaid parallel jobsを1に変更して、画面下部のSaveをクリック
    ![](images/ss-2021-12-12-22-28-51.png)
  - パイプラインの設定と実行
    - プロジェクトのAzure Pipelines をクリック
    ![](images/ss-2021-12-12-22-30-59.png)
    - Create Pipelineをクリック
    ![](images/ss-2021-12-12-22-31-13.png)
    - Azure Repos Gitをクリック
    ![](images/ss-2021-12-12-22-31-24.png)
    - Gitリポジトリ（プロジェクト名と同じ名前がついている）をクリック
    ![](images/ss-2021-12-12-22-31-34.png)
    - Python packageをクリック
    ![](images/ss-2021-12-12-22-31-52.png)
    - Save and runをクリック
    ![](images/ss-2021-12-12-22-32-02.png)
    - 画面右下のSave and runをクリック
    ![](images/ss-2021-12-12-22-32-12.png)
    - しばらく待つ。
    - パイプライン内で4つのJobが生成され、実行される。
    ![](images/ss-2021-12-12-22-32-55.png)
    - 2～3分ですべてのJobが完了し、それぞれのStatusはSuccessとなる。
- 応用
  - [Enabling Continuous Integration with Azure Pipelines](https://azuredevopslabs.com//labs/azuredevops/continuousintegration/)
  - 短いラボなので30分ほどで完了できる。


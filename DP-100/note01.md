
キーワード
機械学習
機械学習モデル
データインジェスト
Azure Machine Learning
- Azure Machine Learningワークスペース
  - コンピューティング
    - コンピューティング インスタンス
    - コンピューティング クラスター
    - 推論クラスター
    - アタッチされたコンピューティング
  - データストア
    - ストレージアカウント
    - Azure Data Lake Storage (Gen2)

■Azure Machine Learning スタジオ
https://studio.azureml.net/ ... Machine Learning Studio (classic) 2024/8/31 にリタイア。

http://services.azureml.net ... 2016/7/29 に発表された「Azure Machine Learningの新しいウェブサービス機能」

https://ml.azure.com/ ... 現在のスタジオ

コンピューティングターゲット（コンピューティング先）


Azure Databricks
Azure Synapse Analytics
Azure AI Services
CPU
GPU
Spark
Jupyterノートブック

ジョブ
モデル
チューニング
トレーニング
エンドポイント
デプロイ
ユーザーがモデルを使用できるようにするには、モデルをエンドポイントにデプロイする必要がある。
モデルをデプロイするとエンドポイントができる
アプリはエンドポイントを経由してモデルを利用できる
Azure Machine Learning ワークスペース

自動ML automated machine learning
- https://learn.microsoft.com/ja-jp/training/modules/use-automated-machine-learning/4-what-is-automated-machine-learning
- Azure Machine Learning には、複数の事前処理手法とモデルトレーニング アルゴリズムを並行して自動的に試行する "自動機械学習" 機能が含まれています。 
- これらの自動化された機能は、クラウド コンピューティングの能力を活用して、データに対して最も優れたパフォーマンスを発揮する、教師あり機械学習モデルを検出します。
- 自動機械学習を使用すると、データ サイエンスやプログラミングに関する豊富な知識がなくてもモデルをトレーニングすることができます。 
- データ サイエンスとプログラミングの経験がある人に対しては、アルゴリズムの選択とハイパーパラメーターのチューニングを自動化することによって時間とリソースを節約する手段が提供されます。

Azure Machine Learning CLI v2
https://learn.microsoft.com/ja-jp/azure/machine-learning/concept-v2?view=azureml-api-2


Azure Machine Learning Python SDK v2
https://learn.microsoft.com/ja-jp/azure/machine-learning/concept-v2?view=azureml-api-2#azure-machine-learning-python-sdk-v2

MLOps: 機械学習のための DevOps
https://learn.microsoft.com/ja-jp/azure/machine-learning/overview-what-is-azure-machine-learning?view=azureml-api-2#mlops-devops-for-machine-learning

キュレーションされた環境 Curated Environments
https://learn.microsoft.com/ja-jp/azure/machine-learning/resource-curated-environments?view=azureml-api-2

Azure Machine Learning デザイナーの機械学習アルゴリズム チート シート
https://learn.microsoft.com/ja-jp/azure/machine-learning/algorithm-cheat-sheet?view=azureml-api-1#download-machine-learning-algorithm-cheat-sheet

https://learn.microsoft.com/ja-jp/azure/machine-learning/tutorial-deploy-model?view=azureml-api-2
モデルを作る
エンドポイントを作る
エンドポイントにモデルをデプロイする（デプロイを作成する）
デプロイは、instance_count を増減することでスケーリングできます。
エンドポイントに複数のデプロイを作成できる。
運用環境のトラフィックをデプロイ間で分割できる。

マネージド オンライン エンドポイントを使用している場合は、仮想マシン (VM) の種類とスケーリング設定のみを指定する必要があります。 コンピューティング能力のプロビジョニングやホスト オペレーティング システム (OS) の更新など、他の処理はすべて自動で行われます。

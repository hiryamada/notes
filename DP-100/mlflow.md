■MLflow
機械学習のライフサイクル管理（MLOps）を目的としたライブラリ
Databricks によって開発された

https://mlflow.org/
MLflow is an open source platform to manage the ML lifecycle, including experimentation, reproducibility, deployment, and a central model registry.


■MLflow: A platform for the machine learning lifecycle
https://mlflow.org/
MLflowは、実験、再現、デプロイ、モデルの保存など、機械学習のライフサイクルを管理するためのオープンソースプラットフォームです。 MLflowを使用すると、機械学習の実験結果を追跡して整理し、他の機械学習エンジニアに説明したり、機械学習モデルをパッケージ化し、デプロイしたりすることができます。

コードの実行ごとに実験記録を作成してくれる便利なライブラリです。OSSのため、誰でも無料で使用することができます

MLflow Tracking
	Azure Machine Learning では、実験のメトリック ログ記録と成果物のストレージに MLflow Tracking が使用されます。
MLflow Projects
	MLflow プロジェクト (プレビュー) を使って、トレーニング ジョブを Azure Machine Learning に送信できます。
MLflow Models
Model Registry

■Azure Machine Learning ワークスペースとMLflow

https://learn.microsoft.com/ja-jp/azure/machine-learning/concept-mlflow?view=azureml-api-2

MLflow は、機械学習のライフサイクル全体を管理するように設計されたオープンソース フレームワークです。 さまざまなプラットフォームでモデルをトレーニングして提供する機能により、実験が実行されている場所に関係なく、一貫した一連のツールを使用できます

Azure Machine Learning ワークスペースは MLflow と互換性があります。つまり、MLflow サーバーを使うのと同じ方法で Azure Machine Learning ワークスペースを使用できるという意味です。



■DP-100 出題範囲（4トピック）でのMLflow

2023/10/18 更新

機械学習ソリューションの設計と準備 (20 - 25%)
データの探索とモデルのトレーニング (35 - 40%)
	MLflow を使用してモデル トレーニングを追跡する
デプロイ用のモデルを準備する (20 - 25%)
	MLflow を使用してジョブ実行からメトリックをログする
	MLflow モデルの出力について説明する
モデルのデプロイと再トレーニング (10 - 15%)



■Azure Machine LearningでのMLflow

https://learn.microsoft.com/ja-jp/azure/machine-learning/concept-mlflow?view=azureml-api-2

Azure Machine Learning ワークスペースは MLflow と互換性があります。つまり、MLflow サーバーを使うのと同じ方法で Azure Machine Learning ワークスペースを使用できるという意味です。

ワークスペースでは MLflow API 言語を使用できる。

MLflow を使用する任意のトレーニング ルーチンを、変更することなく Azure Machine Learning で実行できる。

Azure Machine Learning SDK v1 とは異なり、SDK v2 にログ機能はないため、ログ記録には MLflow の使用をお勧めします。 このような方法により、トレーニング ルーチンはクラウドに依存せず、移植可能になり、Azure Machine Learning に関するコード内のすべての依存関係がなくなります。

Azure Machine Learning は MLflow の互換エンドポイントを提供しており、今回はこの互換エンドポイント目当てに Azure Machine Learning をデプロイしています。要するに MLflow-as-a-Service 

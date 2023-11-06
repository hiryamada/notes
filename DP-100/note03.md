■事例
https://learn.microsoft.com/ja-jp/training/modules/introduction-to-machine-learning/1-introduction

たとえば、スパム フィルターでは機械学習が使用されます。 20 年前は、スパム フィルターに学習させるための例が少なかったため、スパムとそうではないものを十分に識別することができませんでした。 受信され、人間のユーザーによってジャンクとしてラベル付けされるスパムが増えるにつれて、機械学習アルゴリズムはより多くの経験を積み、その役割を十分に果たすようになってきました。
https://learn.microsoft.com/ja-jp/training/modules/use-automated-machine-learning/7-knowledge-check
ある車の販売代理店が、車の売上履歴データを使用して機械学習モデルをトレーニングしたいと考えています。 このモデルでは、車名、車種、排気量、走行距離などに基づいて、事前に所有されている自動車の価格を予測する。

ある銀行が、ローンの再支払い履歴レコードを使用して、ローン金額、借り手の収入、ローン期間などの特性に基づいて、ローン申請を低リスクまたは高リスクとして分類する。

https://learn.microsoft.com/ja-jp/azure/machine-learning/tutorial-auto-train-image-models?view=azureml-api-2&tabs=cli

画像に缶、箱、牛乳瓶、水のボトルなどのオブジェクトが含まれているかどうかを識別します

https://learn.microsoft.com/ja-jp/azure/machine-learning/tutorial-automated-ml-forecast?view=azureml-api-2

自転車シェアリング サービスのレンタル需要を予測する

https://learn.microsoft.com/ja-jp/azure/machine-learning/tutorial-train-deploy-image-classification-model-vscode?view=azureml-api-2

TensorFlow と Azure Machine Learning Visual Studio Code 拡張機能を使用して、手書きの数字を認識する画像分類モデルをトレーニングおよびデプロイする。0 から 9 の手書きの数字を分類する画像分類機械学習モデルを TensorFlow を使用してトレーニング。

https://japan.zdnet.com/article/35160540/
PyTorchと「Microsoft Azure Machine Learning」を組み合わせて使用することで、大量のデータを処理して、薬、疾患、遺伝子、タンパク質、分子などの間にある複雑なつながりに関する、新たな知見を獲得する

https://learn.microsoft.com/ja-jp/azure/architecture/example-scenario/ai/risk-stratification-surgery
デプロイされたモデルを使って、患者の過去の健康情報に基づいて考えられるリスクを推測することができます。 臨床医と患者は、手術のリスクを理解し、適切な治療コースを決定することができます。

https://learn.microsoft.com/ja-jp/azure/architecture/example-scenario/ai/predict-hospital-readmissions-machine-learning
病院の再入院率を予測する

■TensorFlow
https://ai-kenkyujo.com/programming/tensorflow/
TensorFlowとは、Google社が開発しているディープラーニング向けのフレームワークです。
ニューラルネットワークを使用した学習を行う


■ワークスペース
Azure Machine Learning を使用するには、まず Azure サブスクリプションに "ワークスペース" を作成する。


■スタジオ（Azure Machine Learning Studio）

作成したワークスペースを Azure Machine Learning スタジオから操作する。

※AWSで言うところのAmazon SageMaker Studio

■資産（アセット）

ワークスペースに関連付けられたデータ、ジョブ、コンポーネント、パイプライン、環境、モデル、エンドポイントなどを指す。

ワークスペースから管理できる。

■データ資産（データアセット）

以下のような場所からデータ資産を作成できる（データを取得できる）

Azure Blob Storage
Azure Files
Azure Data Lake
Azure SQL Database
Azure Database for PostgreSQL
ローカルファイル
Web URL
Azure Open Datasets

■自動機械学習（AutoML）

データに基づいて最適なモデルを見つける機能。

※AWSで言うところのAmazon SageMaker Autopilot

データに対して最も優れたパフォーマンスを発揮する、教師あり機械学習モデルを検出する。

- 分類 (カテゴリまたはクラスの予測): yes/no, blue/red/green等
- 回帰 (数値の予測)
- 時系列予測 (特定の時点での数値の予測)
- 自然言語処理
- コンピュータビジョン

スタジオで「自動機械学習ジョブ」を作成する。

■ジョブ

Azure Machine Learning で実行される演算のこと。

■実験

MLには実験的な性質がある（いろいろな構成を実際に試してみないとわからない）。

機械学習において実験は数多く繰り返される。

記録、再現性も重要。

- 計画する
- 環境を準備・選択する
- モデルを選択する
- データを準備する
- コードを書く
- モデルのトレーニングを行う
- トレーニングされたモデルの評価・テストを行う
- 考察する
- 以上に名前をつけて記録する
- 実験結果を他のデータサイエンティストに共有する

https://www.nogawanogawa.com/entry/experiment_management
AutoMLなどのフレームワークを使用する

■MLOps

機械学習（ML）と運用（Operations）を組み合わせた造語

https://cloud.google.com/architecture/mlops-continuous-delivery-and-automation-pipelines-in-machine-learning?hl=ja

MLOps を実践すると、統合、テスト、リリース、デプロイ、インフラストラクチャ管理など、ML システム構築のすべてのステップで自動化とモニタリングを推進できます。


■一般的なモデル開発のライフサイクル

https://learn.microsoft.com/ja-jp/azure/machine-learning/concept-compute-target?view=azureml-api-2

- 最初に、少量のデータを開発して実験します。 この段階では、コンピューティング ターゲットとしてローカル環境 (ローカル コンピューターやクラウド ベースの仮想マシン (VM) など) を使用します。
- より大きなデータにスケールアップするか、またはこれらのトレーニング コンピューティング ターゲットのいずれかを使用して分散トレーニングを実行します。
- モデルの準備ができたら、これらのデプロイ コンピューティング ターゲットのいずれかを使用して、そのモデルを Web ホスティング環境にデプロイします。

■Jupyter Notebook

https://learn.microsoft.com/ja-jp/azure/machine-learning/tutorial-explore-data?view=azureml-api-2

通常、機械学習プロジェクトの開始には、探索的データ分析 (EDA)、データ前処理 (クリーニング、特徴エンジニアリング)、仮説を検証するための機械学習モデルのプロトタイプの構築が含まれます。 この "プロトタイプ作成" のプロジェクト フェーズは高度に対話的です。 "Python 対話型コンソール" を使用し、IDE または Jupyter ノートブックでの開発に適しています。 


■コンピューティング ターゲット compute target(s) 

■トレーニング コンピュート ターゲット Training compute targets


■推論 inference

「バッチ推論」と「リアルタイム推論」の2つがある。

推論はDockerコンテナー内で実行される。

AKS, Azure Arc-enabled Kubernetes(Azure Arc 対応 Kubernetes、任意の場所で実行されているKubernetesクラスター)compute terget や、「Azure Machine Learning endpoints」compute targetへとデプロイされる。

ACIはv1 SDK/CLIで利用できた。

テスト・デバッグ段階では、「ローカルWebサービス」compute terget へとデプロイされる。


■「特徴」features と「ラベル」label
https://learn.microsoft.com/ja-jp/training/modules/use-automated-machine-learning/5-machine-learning-steps

■サポートチームBlog
https://jpmlblog.github.io/blog/2020/01/01/about-jpmlblog/
https://jpmlblog.github.io/blog/2021/01/13/AML-model-inference/

■よさそうな教材
https://learn.microsoft.com/ja-jp/training/paths/machine-learning-foundations-using-data-science/
機械学習の基礎。


https://learn.microsoft.com/ja-jp/training/modules/introduction-to-machine-learning/
コンピューター サイエンスおよび統計学に関する知識がほとんど、またはまったくない方向けの機械学習の概要。 ここでは、いくつかの重要な概念を確認し、データについて調べ、実際の場合と同様に、Python を使って機械学習モデルをトレーニングし、保存し、使うという機械学習のライフサイクル全体を対話形式で体験します。

犬用ハーネスから犬用ブーツのサイズを推定。

https://learn.microsoft.com/ja-jp/training/modules/optimize-model-performance-roc-auc/
ROC と AUC でモデルのパフォーマンスを測定および最適化する

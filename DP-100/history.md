
■歴史

※この記事がわかりやすい https://qiita.com/satonaoki/items/a02ce1fe04356ceaf758

2014/6/17 マイクロソフト、機械学習サービス「Azure ML」のプレビュー版を7月に公開へ
https://japan.cnet.com/article/35049477/

2014/6/17 Microsoft Azure Machine Learning 公開プレビューを来月から開始と発表
https://www.publickey1.jp/blog/14/microsoft_azure_machine_learning.html

2015/2/20 Azure Machine Learning 正式リリース. Azure Machine Learning Studio
https://www.publickey1.jp/blog/15/azure_machine_learningpythonr.html
https://azure.microsoft.com/ja-jp/updates/general-availabilty-azure-machine-learning/

2016/7/29 Azure Machine Learningの新しいウェブサービス機能を2016年7月29日に発表
https://memo.tyoshida.me/azure/azure-machine-learning-with-new-web-service-portal/

- https://azure.microsoft.com/en-us/updates/new-azure-machine-learning-web-services-available/
- 新しいウェブサービスを作成するには、従来のウェブサービスのデプロイと同じ方法ですが、「Classic」から「New」を選択できます。このときに「New」を選択します。
- 新しいウィンドウで新ポータル（https://services.azureml.net/）が立ち上がり、ウェブサービスがデプロイされます。

2018/12/4 Azure Machine Learning サービスの一般提供の発表
https://azure.microsoft.com/en-us/blog/azure-machine-learning-service-a-look-under-the-hood/
https://azure.microsoft.com/ja-jp/updates/azure-machine-learning-service-now-generally-available/

2020/7/8 Azure Machine Learning Studio Webエクスペリエンス(ml.azure.com) 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-machine-learning-studio-web-experience-is-generally-available/




■Azure Machine Learningのv1/v2がある

API
CLI
Python SDK

■CLI
2021/5/25 Azure Machine Learning の CLI (v2) の発表
https://learn.microsoft.com/ja-jp/azure/machine-learning/azure-machine-learning-release-notes-cli-v2?view=azureml-api-2#announcing-the-cli-v2-for-azure-machine-learning

https://learn.microsoft.com/ja-jp/azure/machine-learning/how-to-configure-cli?view=azureml-api-2&tabs=public
Azure CLI に対する ml 拡張機能は、Azure Machine Learning の拡張インターフェイスです。 これにより、コマンド ラインからモデルをトレーニングおよびデプロイできます。

az extension add -n ml
az ml -h
az ml workspace create -n $WORKSPACE -g $GROUP -l $LOCATION

Azure Machine Learning 用の ml CLI 拡張機能 ("CLI v2" とも呼ばれる) により、パブリック インターネット経由で運用データ (YAML パラメーターとメタデータ) が送信されます。 ml CLI 拡張機能のすべてのコマンドは、Azure Resource Manager と通信します。 この通信は、HTTPS/TLS 1.2 を使ってセキュリティ保護されます。

■Python SDK
Azure ML Package client library for Python
(Azure Machine Learning Python SDK v2)
https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/ml/azure-ai-ml

https://pypi.org/project/azure-ai-ml/

https://anaconda.org/microsoft/azure-ai-ml/

■API

https://learn.microsoft.com/ja-jp/azure/machine-learning/how-to-configure-network-isolation-with-v2?view=azureml-api-2&tabs=python

v1 と v2 の API の操作では、Azure Resource Manager (ARM) と Azure Machine Learning ワークスペースの 2 種類が使用されます。

v1 API では、ほとんどの操作でワークスペースが使用されました。

v2 では、ほとんどの操作でパブリック ARM が使用されるようになりました。

v2: ワークスペース、コンピューティング、データストア、データセット、ジョブ、環境、コード、コンポーネント、エンドポイントなどのほとんどの操作。

Azure Machine Learning CLI v2 では、新しい v2 API プラットフォームが使用されます

■v1/v2

Azure Machine Learning では、インターフェイス間で機能と用語を統一するためにバージョン 2 (v2) が導入されました

Azure ML SDK v2はv1から大きく変更が加えられ、使い方もほとんど原型がないレベルで変わっています。
https://tech.isid.co.jp/entry/2022/12/22/Azure_Machine_Learning_SDK_v2%E3%81%AE%E5%9F%BA%E6%9C%AC%E7%9A%84%E3%81%AA%E4%BD%BF%E3%81%84%E6%96%B9%E7%B4%B9%E4%BB%8B
Pythonパッケージのazure-ai-mlをインストールします（ちなみにSDK v1はazureml-coreです）。SDK v2の主要な変更の一つとして、上記のMLClientが挙げられます。SDK v1では、ExperimentやRunなど様々なクラスを用途に応じて使い分ける必要がありましたが、v2におけるAMLの操作は全てこのMLClientから実行します。

https://qiita.com/ShuntaIto/items/2add3778fac62db898d5
2022/5  AzureML v2 が登場したタイミングで Azure Machine Learning CLI v2 も GA になりました。
2022/10 Azure Machine Learning SDK v2 が GA になりました。


# KEDA

ケイダー

Kubernetes Event-driven Autoscaling

https://keda.sh/

さまざまな「イベントソース」から情報を読み取ってスケーリングを行うしくみ。Kubernetesクラスターに組み込んで利用する。

# スケーラー

さまざまな「イベントソース」から情報を読み取る「スケーラー」が利用できる。

例: ストレージアカウントのBlobコンテナー内のBlobの数に応じたスケーリング

例: SQL Server、MySQL、PostgreSQLなどのクエリー結果に基づくスケーリング

例: AWSのサービス（CloudWatch、DynamoDB、Kinesis、SQS）に基づくスケーリング

# 参考

KEDA：Kubernetesのイベントドリブンコンテナとサーバーレスコンテナ-Jeff Hollan、Microsoft（英語動画）
https://www.youtube.com/watch?v=ZK2SS_GXF-g

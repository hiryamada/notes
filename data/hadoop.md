
■Apache Hadoop 2006～

Javaで書かれている

Apacheのトップレベルプロジェクトの1つ

Hadoopクラスタにサーバを追加することで処理性能を向上させることができる。

■Apache Spark 2012～

大量データをインメモリで高速に分散処理を行うフレームワーク。

分散キャッシュであるRDD（Resillient Distributed Datasets）により、繰り返し処理で高パフォーマンスを実現

■Apache Kafka 2011～

LinkedInで開発されたオープンソースの分散メッセージングシステム。

open-source distributed event streaming platform


従来のメッセージブローカーの代わりとしても利用できる。

運用監視

IoT

ログの集約

ストリーミング処理

オープンソースストリーム処理ツールにはApache StormとApache Samzaも利用可能。

https://openstandia.jp/solution/kafka/

Kafkaクラスター内にキューを構築。
1台のKafkaサーバで秒間10万メッセージ（20MB）以上の送受信が可能

■Kafka and Hadoop

KafkaとHadoopは、ビッグデータ処理に関連するオープンソースのプロジェクト。
KafkaとHadoopは、ビッグデータ処理において、相互に補完的な役割を持っている。

- Kafkaは、分散メッセージングシステム
- Hadoopは、分散処理フレームワーク
- Kafkaは、HadoopのMapReduceジョブの結果を受け取り、ストリーム処理を行うことができる。
- Kafkaは、HadoopのHDFSにデータを書き込むことができる。
- Hadoopは、Kafkaのストリームデータを処理することができる。

■Samza 2013～、1.0リリース 2018

https://g3-enterprise.com/2018/12/07/samza/

LinkedInは2013年から開発を進めてきた分散ストリームプロセッシングフレームワーク「Samza 1.0」のリリースを発表しました。現在はApache Software Foundationのもとでオープンソースソフトウェア「Apache Samza」として開発が続けられている

Samzaは基本的に（Hadoopの）YARN上にデプロイされ、KafkaやHDFS、Amazon Kinesis、Azure Eventhubsなどのデータソースから取り込んだストリームデータをAPIで処理(ストリーミングETL、イベントベースアプリケーション、リアルタイムアナリティクスなど)し、出力先(Kafka、HDFS、ElasticSearchなど)にストリームデータとして結果を渡します。


■Databricks社 2013～

Databricks社は、2013年にApache Sparkの生みの親であるマテイ・ザハリアと共に、アリ・ゴディシが設立した企業。

■Apache Kafka vs Azureサービス

https://learn.microsoft.com/ja-jp/azure/event-hubs/azure-event-hubs-kafka-overview#is-apache-kafka-the-right-solution-for-your-workload

Apache Kafka ユーザーがこれまで Kafka で実現した通信パスは、Event Grid または Service Bus を使用することで、基本的な複雑さが非常に低く、より強力な機能で実現できます。

Apache Kafka インターフェイス用 Event Hubs を介して利用できない Apache Kafka の特定の機能が必要な場合、または実装パターンが Event Hubs のクォータを超える場合は、ネイティブ Apache Kafka クラスターを Azure HDInsight で実行することもできます。

■Apache Kafka vs Azure Event Hubs

https://learn.microsoft.com/ja-jp/azure/event-hubs/azure-event-hubs-kafka-overview#apache-kafka-and-azure-event-hubs-conceptual-mapping

概念的には、Kafka と Event Hubs は非常に似ています。

■Azure Event Hubs

Azure Event Hubs では、イベント ハブ上に Apache Kafka エンドポイントを提供します。これにより、ユーザーは Kafka プロトコルを使用してイベント ハブに接続できます。

完全修飾ドメイン名を持つエンドポイントである名前空間を作成し、その名前空間内に Event Hubs (トピック) を作成します。

■Azure Service Bus


■AMQP


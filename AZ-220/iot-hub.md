# Azure IoT Hub

[製品ページ](https://azure.microsoft.com/ja-jp/services/iot-hub/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/iot-hub/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/iot-hub/)

[価格の説明](https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-pricing)


- マネージド サービス
- IoT アプリケーションとデバイスの間のメッセージ ハブ
- デバイスからクラウドへと、クラウドからデバイスへの、両方の通信をサポート
- 数百万のデバイスの同時接続、毎秒数百万のイベントに対応するようにスケーリング

# レベルとサイズ

IoT Hubのリソース作成時に「管理」タブで指定。

リソース作成後は「価格とスケール」から変更可能（Freeを除く）

- Free, Basic, Standardの「レベル」
- FreeはF1, BasicはB1/B2/B3, StandardはS1/S2/S3という「サイズ」がある
  - 数字が大きいほうが性能が高い（よりたくさんのメッセージを送信できる）

Free
- サイズ: F1のみ
- ユニット数: 
- PoC（概念実証）用
- 1 日あたり合計 8,000 メッセージまで送信でき、最大 500 台までのデバイス ID を登録できます
- Free エディションから有料エディションのいずれかに切り替えることはできません。
- IoT Edge利用可能

Basic
- サイズ: B1/B2/B3
- ユニット数: B1,B2は1～200, B3は1～10
- Basic レベルから Standard レベルにアップグレードできますが、Standard レベルから Basic レベルにダウングレードすることはできません。
- 「cloud-to-device」, 「IoT Edge」, 「デバイス管理」は使用できない

Standard
- サイズ: S1/S2/S3
- ユニット数: S1,S2は1～200, S3は1～10
- Defender for IoTが使用できる（オプション、デフォルト値は「オン」）
- [cloud-to-deviceメッセージ送信はFree/Standardレベルで使用可能](https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-messages-c2d)
- IoT Edge利用可能

ユニット数
- 「ユニット数」を変更できる。
- デフォルトは1。
- ユニット数に比例したコストがかかる
- ユニット数に比例して、1日の最大メッセージ送信可能数が決まる




# 設定＞ネットワーク（IPフィルター）

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-ip-filtering

「パブリックアクセス」タブ

- 「無効」「選択したIP範囲」「すべてのネットワーク」を選べる。
- 1 つの IPv4 アドレスか、または CIDR 表記法で記述した IP アドレス ブロックを指定
- 10個まで
- 順序付けはない
- IPv6アドレスの設定はできない

「プライベートエンドポイント接続」タブ

- [プライベートエンドポイント(Private Link)](https://docs.microsoft.com/ja-jp/azure/private-link/private-link-overview?toc=/azure/virtual-network/toc.json#availability)を設定できる。

- [サービスエンドポイントは非対応](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-service-endpoints-overview)

# プロトコルサポート

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-protocols

- MQTT - port 8883sknrM9m
- MQTT over WebSocket - port 443
- AMQP - port 5671
- AMQP over WebSocket - port 443
- HTTPS - port 443

# az コマンドによるIoT Hub作成例

```
az group create -n <group> -l <location>
az iot hub create -n <name> -g <group> --sku <sku>
```

`-g` ( `--group-name` )は必須。

`--sku` はオプション、省略時は`S1`

# メッセージルーティング

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-messages-d2c

メッセージ ルーティングを使用すると、自動化された、スケーラブルで信頼性の高い方法で、デバイスからクラウド サービスにメッセージを送信することができます。

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-routing-query-syntax

メッセージ ルーティングでは、メッセージ プロパティとメッセージ本文に基づいてクエリを実行できるほか、デバイス ツインのタグとプロパティに基づいてクエリを実行することもできます。


各メッセージは、一致するルーティング クエリを持つすべてのエンドポイントにルーティングされます。 つまり、メッセージは複数のエンドポイントにルーティングできます。

IoT Hub では現在、次のエンドポイントがサポートされています。
- 組み込みのエンドポイント
- Azure Storage
- Service Bus キューと Service Bus トピック
- Event Hubs

# ルートのテスト

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-messages-d2c#testing-routes

新しいルートを作成したり、既存のルートを編集したりする場合は、サンプル メッセージを使用してルート クエリをテストする必要があります。

個々のルートをテストすることも、すべてのルートを一度にテストすることも可能で、テスト中にメッセージがエンドポイントにルーティングされることはありません。

テストには、Azure portal、Azure Resource Manager、Azure PowerShell、および Azure CLI を使用することができます。 

結果は、サンプル メッセージがクエリに一致したか、メッセージがクエリに一致しなかったか、サンプル メッセージまたはクエリ構文が正しくないためにテストを実行できなかったかを識別するのに役立ちます。

# IoT Hub の Event Grid との統合

Azure Event Grid は、発行-サブスクライブ モデルを使用する、フル マネージドのイベント ルーティング サービスです。 IoT Hub と Event Grid は、Azure サービスと Azure 以外のサービスに IoT Hub イベントを統合するために、ほぼリアルタイムで連携します。 IoT Hub は、デバイス イベント とテレメトリ イベントの両方を発行します。

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-event-grid-routing-comparison

（IoT Hub メッセージ ルーティング : この IoT Hub の機能を使用して、Azure Storage コンテナー、Event Hubs、Service Bus キュー、Service Bus トピックなどのサービス エンドポイントに、device-to-cloud メッセージをルーティングすることができます。 また、ルーティングでは、エンドポイントにルーティングする前にデータをフィルター処理するクエリ機能も提供されています。 デバイスのテレメトリ データに加えて、アクションのトリガーに使用できる非テレメトリ イベントも送信できます。）

# デバイスを監視する - monitor-events コマンド

デバイスから送信されたテレメトリを表示する

https://docs.microsoft.com/ja-jp/azure/iot-hub/quickstart-send-telemetry-cli#view-messaging-metrics-in-the-portal

az iot hub monitor-events コマンドを実行します。 これにより、シミュレートされたデバイスの監視が開始されます。 出力には、シミュレートされたデバイスから IoT hub に送信されたテレメトリが表示されます。

https://docs.microsoft.com/ja-jp/cli/azure/ext/azure-iot/iot/hub?view=azure-cli-latest#ext_azure_iot_az_iot_hub_monitor_events

Monitor device telemetry & messages sent to an IoT Hub.

```
az iot hub monitor-events -n {iothub-name} -d {device-name}
```


# サービスポリシー

# SharedAccessKey

# ファイルアップロード

https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-devguide-file-upload

ファイルのアップロードを使用して、断続的に接続されたデバイスでアップロードされた、または帯域幅を節約するために圧縮されたメディア ファイルや大容量のテレメトリ バッチを送信します。


デバイスは、デバイス向けエンドポイント ( /devices/{deviceId}/files) を介して通知を送信することで、ファイルのアップロードを開始できます。 アップロードが完了したことをデバイスが IoT Hub に通知すると、IoT Hub はサービス向けエンドポイント ( /messages/servicebound/filenotifications) を介してファイル アップロード通知メッセージを送信します。


https://docs.microsoft.com/ja-jp/azure/iot-hub/iot-hub-configure-file-upload

IoT Hub でファイルのアップロード機能を使用するには、最初に Azure Storage アカウントとハブを関連付ける必要があります。

# ログの収集

https://docs.microsoft.com/ja-jp/azure/iot-hub/tutorial-use-metrics-and-diags

Azure Monitor を使用して、IoT ハブのメトリックとログを収集できます。これらは、ソリューションの操作の監視と、発生した問題のトラブルシューティングに役立ちます。 

IoT Hub は、操作の複数のカテゴリに対応する**リソース ログ**を出力します。ただし、これらのログを**表示**するには、送信先に送るための**診断設定**を作成する必要があります。 そのような送信先の 1 つが、**Log Analytics ワークスペース**で収集される **Azure Monitor ログ**です。

リソースログ：

https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/tutorial-resource-logs


リソース ログを収集すると、Azure リソースの詳細な操作に関する分析情報が提供され、正常性と可用性を監視するのに役立ちます。 Azure リソースではリソース ログが自動的に生成されますが、**リソース ログを収集する場所を構成する必要があります**。 


# IoTエクスプローラ

https://docs.microsoft.com/ja-jp/azure/iot-pnp/howto-use-iot-explorer

Azure IoT エクスプローラーは、IoT ハブに接続されている任意のデバイスと対話するためのグラフィカル ツールです。 

# iothub-diagnostics tool

https://github.com/azure/iothub-diagnostics

This tool is provided to help diagnose issues with a device connecting to Azure IoT Hubs.

デバイスの接続の診断に使用できるツール。注意：Archived


The tool will run, and will provide high level information about success and failure to the command prompt. 

```
iothub-diagnostics HostName=<my-hub>.azure-devices.net;SharedAccessKeyName=<my-policy>;SharedAccessKey=<my-policy-key>
```

# IoT Hub のデバイス ツイン

"デバイス ツイン" は、デバイスの状態に関する情報 (メタデータ、構成、状態など) を格納する JSON ドキュメントです。

IoT Hub でデバイス ID を作成または削除したときに、デバイス ツインは暗黙的に作成または削除されます。

デバイス ツインには、デバイスに関連する次のような情報が格納されます。

- デバイスの状態と構成を同期するために使用するデバイスとバックエンド。
- 実行時間の長い操作にクエリを行い、ターゲットを設定するために使用するソリューション バックエンド。

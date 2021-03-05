# Azure IoT Central

IoT Central は、エンタープライズ レベルの IoT ソリューションの開発、管理、および保守の負担とコストを削減する IoT アプリケーション プラットフォームです。 

[製品ページ](https://azure.microsoft.com/ja-jp/services/iot-central/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/iot-central/core/overview-iot-central)

# デバイステンプレート


https://docs.microsoft.com/ja-jp/azure/iot-central/core/concepts-architecture#devices

Azure IoT Central では、デバイスがアプリケーションと交換できるデータはデバイス テンプレートで指定されます。

https://docs.microsoft.com/ja-jp/azure/iot-central/core/concepts-device-templates

デバイス テンプレート により、デバイスと IoT Edge のモジュールの機能が定義されます。 機能には、モジュールが送信するテレメトリ、モジュール プロパティ、モジュールが応答するコマンドが含まれます。

# デバイステンプレートの発行

https://docs.microsoft.com/ja-jp/azure/iot-central/core/howto-set-up-template#publish-a-device-template

デバイス モデルを実装するデバイスを接続する前に、デバイス テンプレートを発行する必要があります。

# IoT Edge

Azure IoT SDK を使用して作成されたデバイスと同様に、Azure IoT Edge デバイスを IoT Central アプリケーションに接続することもできます。

IoT Edge を使用すると、IoT Central によって管理されている IoT デバイスで、クラウド インテリジェンスやカスタム ロジックを直接実行できます。

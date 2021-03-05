# Azure IoT Edge

これまでクラウドで行っていた**分析とカスタム ビジネス ロジックをデバイス側で実行できるようにする**ものです。

[製品ページ](https://azure.microsoft.com/ja-jp/services/iot-edge/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/iot-edge/?view=iotedge-2018-06)

# デプロイ マニフェスト

https://docs.microsoft.com/ja-jp/azure/iot-edge/module-composition?view=iotedge-2018-06

インストールするモジュールとそれらを連携させるための構成方法をデバイスに伝えるには、デプロイ マニフェストを使用します。

Visual Studio Code を使用して配置マニフェストを作成します。 


# IoT Edgeエージェント

https://docs.microsoft.com/ja-jp/azure/iot-edge/iot-edge-runtime?view=iotedge-2018-06#iot-edge-agent

IoT Edge エージェントは、Azure IoT Edge ランタイムを構成する 2 つのモジュールの 1 つです。 **このモジュールは、モジュールをインスタンス化し、モジュールの実行を継続し、IoT Hub にモジュールのステータスを報告します**。

デバイスの起動時に、IoT Edge セキュリティ デーモンが IoT Edge エージェントを開始します。

IoT Edge エージェントは、IoT Edge デバイスのセキュリティ上、重要な役割を果たします。 たとえば、起動前のモジュール イメージの検証などの操作を実行します。

# IoT Edgeハブ

IoT Edge ハブは、Azure IoT Edge ランタイムを構成するもう 1 つのモジュールです。 

**Edge ハブは、IoT Hub と同じプロトコル エンドポイントを公開することで IoT Hub のためのローカル プロキシとして動作します**。 この整合性により、クライアントは、IoT Hub と同じように IoT Edge ランタイムに接続できます。

# デバイスの登録

https://docs.microsoft.com/ja-jp/azure/iot-edge/how-to-register-device?view=iotedge-2018-06&tabs=azure-cli#option-1-register-with-symmetric-keys

https://docs.microsoft.com/en-us/cli/azure/ext/azure-iot/iot/hub/device-identity?view=azure-cli-latest


```
az iot hub device-identity create --device-id [device id] --hub-name [hub name] --edge-enabled
```
# 自動デプロイ

（「標準の自動デプロイ」とも？ standard automatic deployment）

https://docs.microsoft.com/ja-jp/azure/iot-edge/module-deployment-monitoring?view=iotedge-2018-06#deployment

IoT Edge の自動デプロイでは、実行する IoT Edge モジュール イメージが、一連のターゲット IoT Edge デバイス上のインスタンスとして割り当てられます。

# 多層デプロイ (layered-deployment)

https://docs.microsoft.com/ja-jp/azure/iot-edge/module-deployment-monitoring?view=iotedge-2018-06#layered-deployment

多層デプロイは、組み合わせることで、作成する必要がある一意のデプロイの数を減らすことができる自動デプロイです。 多層デプロイは、多くの自動デプロイで同じモジュールを異なる組み合わせで再利用するシナリオで役立ちます。

システムのランタイム モジュールである edgeAgent と edgeHub は、多層デプロイの一部として構成されません。 多層デプロイのターゲットとなる任意の IoT Edge デバイスでは、最初に標準の自動デプロイを適用する必要があります。 自動デプロイでは、多層デプロイを追加できるベースが提供されます。

IoT Edge デバイスで適用できる標準の自動デプロイは 1 つだけですが、多層の自動デプロイは複数適用できます。 デバイスをターゲットとする多層デプロイには、そのデバイスに対する自動デプロイより高い優先順位が設定されている必要があります。

# コンテナー エンジン

https://docs.microsoft.com/ja-jp/azure/iot-edge/development-environment?view=iotedge-2018-06#container-engine

IoT Edge の主要概念は、コンテナーにパッケージ化することで、リモートからビジネス ロジックやクラウド ロジックをデバイスに配置できるようにするというものです。 コンテナーをビルドするには、開発用マシンでコンテナー エンジンが必要になります。

**運用環境の IoT Edge デバイスでサポートされているコンテナー エンジンは、Moby のみです**。 

ただし、Docker などの Open Container Initiative と互換性のあるコンテナー エンジンでは、IoT Edge モジュール イメージをビルドできます。

# OPC UA

https://www.fa.omron.co.jp/product/special/sysmac/nx1/opcua.html

Open Platform Communications Unified Architecture

産業オートメーションなどの業界で、安全で信頼性あるデータ交換を行うために策定されたオープンな国際標準規格です。

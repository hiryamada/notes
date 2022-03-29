# Azure SQL Edge

ドキュメント: https://docs.microsoft.com/ja-jp/azure/azure-sql-edge/overview

価格: https://azure.microsoft.com/ja-jp/pricing/details/azure-sql-edge/

■特徴

- IoT および IoT Edge のデプロイ向けに最適化されたリレーショナル データベース エンジン
  - 短い待機時間で、IoTデータをデータベースに格納し、処理できる
- 最新バージョンの SQL Server データベース エンジンに基づいて構築されている。
  - SQL Server / Azure SQLと同様の、開発・管理エクスペリエンスを利用できる。
  - コードとツールを再利用できる
  - 他のSQL Server / Azure SQLとデータを簡単に交換できる
  - 強力な暗号化・データ分類機能が実装されている
- ストリーミングデータの分析機能などを備える。
- JSONデータ、グラフデータを扱うこともできる。

※Azure SQL Edge は、Linux 上で実行されている ARM64 および x64 デバイスをサポート。Windows のサポートは近日提供予定

■エディション

https://docs.microsoft.com/ja-jp/azure/azure-sql-edge/features#azure-sql-edge-editions

- Azure SQL Edge Developer
  - 開発専用
- Azure SQL Edge
  - 運用環境向け

■デプロイ方法

- [Azure IoT Edge](https://docs.microsoft.com/ja-jp/azure/iot-edge/about-iot-edge?view=iotedge-2020-11) のモジュールとしてデプロイ（[ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-sql-edge/deploy-portal)）
- Docker コンテナーとして、[Dockerエンジンにデプロイ（ドキュメント）](https://docs.microsoft.com/ja-jp/azure/azure-sql-edge/disconnected-deployment) / [Kubernetesクラスターにデプロイ（ドキュメント）](https://docs.microsoft.com/ja-jp/azure/azure-sql-edge/deploy-kubernetes)

※[Azure IoT Edge](https://docs.microsoft.com/ja-jp/azure/iot-edge/about-iot-edge?view=iotedge-2020-11): センサーから取り込んだデータ分析などの処理を、センサーに近い場所に配置された「エッジデバイス」側で実行できるようにするしくみ。「エッジデバイス」上で動作する「ランタイム」と、「ランタイム」上で動作する「モジュール」（Dockerコンテナー）で構成される。

■Azure IoT Edgeでの構成例

```
リーフデバイス
│├アクチュエータ
│└センサー
│
エッジデバイス（Windows / Linux / Raspberry PI等）（ARM / x64）
└Azure IoT Edge ランタイム
  ├IoT Edge モジュール<センサーデータの取り込み/アクチュエータの制御>
  ├IoT Edge モジュール<機械学習>
  ├IoT Edge モジュール<Azure SQL Edge> ※現在 Linux, ARM64 / x64 のみサポート
  ├IoT Edge モジュール<Azure Stream Analytics>
  └IoT Edge モジュール<Azure IoT Hubとの通信>
                             ↓
                   Azure IoT Hub: デバイスの管理、デバイスとの通信
```

※Azure Stream Analytics: ストリーミング データの分析

※Azure SQL Edge: ストリーミング データの分析 ＋ SQLによるデータ管理


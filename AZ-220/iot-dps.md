# Azure IoT Hub Device Provisioning Service (DPS)

IoT Hub Device Provisioning Service (DPS) は、IoT ハブへのゼロタッチの Just-In-Time プロビジョニングを人間の介入を必要とせずに実現する、IoT Hub のヘルパー サービスです。これにより、安全かつスケーラブルな方法で多数のデバイスをプロビジョニングできます。


[ドキュメント](https://docs.microsoft.com/ja-jp/azure/iot-dps/)

[デモビデオ（3分弱）](https://azure.microsoft.com/ja-jp/resources/videos/iot-hub-dps-demo/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/iot-hub/)

レベルはS1のみ。1000操作ごとに$0.145。

[InfoQの紹介記事](https://www.infoq.com/jp/news/2018/01/azure-iot-provisioning-available/)

[たかはしまさる さん IoT Hub Device Provisioning Service とは？超概要](https://qiita.com/mstakaha1113/items/231c859d7427b466d4ad)


[DPSで使われる用語](https://docs.microsoft.com/ja-jp/azure/iot-dps/concepts-service)

DPSを使うと、通常「IoT Hub＞エクスプローラ＞IoTデバイス＞＋追加」からデバイスを1つずつ登録する必要がなくなる。

1つのDPSで多数のIoT Hubに対応できる

# エンドポイント

- Service operations endpoint
- Device provisioning endpoint

# 割り当てポリシー

https://docs.microsoft.com/ja-jp/azure/iot-dps/concepts-service#allocation-policy

- Evenly weighted distribution(均等に重み付けされた分散) : リンクされた各 IoT Hub にデバイスが同程度にプロビジョニングされます。 既定の設定です。 デバイスを 1 つの IoT ハブにのみプロビジョニングする場合は、この設定のままでかまいません。
- Lowest latency(最も短い待機時間) : デバイスに対する待機時間が最も短い IoT Hub にデバイスをプロビジョニングします。 複数の IoT Hub にリンクしていて、同様に最も短い待機時間になっている場合、プロビジョニング サービスはそれらのハブ全体のデバイスをハッシュします。**待ち時間は Traffic Manager と同じ方法を使用して決定されます。**
- Static configuration via the enrollment list(enrollment listによる静的構成) : enrollment listの目的の IoT Hub の仕様が、サービス レベルの割り当てポリシーよりも優先されます。
- カスタム (Azure 関数を使用) :カスタム割り当てポリシーを使用すると、デバイスを IoT ハブに割り当てる方法をより細かく制御できます。 これは、デバイスを IoT ハブに割り当てる際に、Azure 関数でカスタム コードを使用することで実現されます。 Device Provisioning Service により、デバイスと登録に関するすべての関連情報をコードに提供する Azure 関数コードが呼び出されます。 関数コードが実行され、デバイスのプロビジョニングに使用する IoT ハブ情報が返されます。

# Enrollment

- Enrollment group
- Individual enrollment

# Attestation 


デバイスのIDを確認する方法

- X.509 certificated
- Trusted Platform Module (TPM)
- Symmetric Key

X.509証明書とSymmetric Keyは、HSM（Hardware Security Module）に格納することができる

# リソースの作成

「デバイス プロビジョニング サービス」を作成

一意な名前を指定して作成。

以下のエンドポイントが表示される。

- サービスエンドポイント: mydps34534.azure-devices-provisioning.net
- グローバルデバイスエンドポイント：global.azure-devices-provisioning.net

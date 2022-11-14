# Azure Container Registryのセキュリティ


■イメージのセキュリティ スキャンを行う

「Microsoft Defender for Containers」を使用することで、Azure Container Registries (APR) 内のイメージの脆弱性スキャンを行うことができる。

https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-containers-introduction#vulnerability-assessment

- プッシュ時: イメージがストレージのレジストリにプッシュされると、Defender for Containers によってイメージが自動的にスキャンされる。
- 最近プルされたもの: 過去 30 日間にプルされたイメージを毎週でスキャンする。
- インポート時: ACR にイメージをインポートすると、Defender for Containers でサポートされているイメージがスキャンされる。

■イメージに署名を行う（「コンテンツの信頼」モデル）

https://learn.microsoft.com/ja-jp/azure/container-registry/container-registry-content-trust

- レジストリにプッシュするイメージには、イメージの発行者が「署名」（電子署名）することができる
- イメージのコンシューマー (レジストリからイメージをプルする人またはシステム) は、署名済みのイメージのみをプルするように各自のクライアントを構成することができる
- このモデルでは、レジストリに存在する署名済みのイメージが確かに本人によって発行され、また発行された後に改変されていないということが確実となる。

■サービスエンドポイント / プライベートエンドポイントを使用する

サービス エンドポイント:特定のVNetからのみ、レジストリにアクセスできるように、ネットワークを設定。
https://learn.microsoft.com/ja-jp/azure/container-registry/container-registry-vnet

プライベートエンドポイント:特定のVNet、ピアリングされたVNet、オンプレミスからのみ、レジストリにアクセスできるように、ネットワークを設定。
https://learn.microsoft.com/ja-jp/azure/container-registry/container-registry-private-link

■カスタマーマネージドキーを使用して、イメージを暗号化する

https://learn.microsoft.com/ja-jp/azure/container-registry/tutorial-customer-managed-keys

Azure Key Vaultに格納した「カスタマーマネージドキー」による暗号化を行うように設定する。

キーのローテーションのタイミングを制御できる。

キーの利用を監査できる。

■Azure Policyを使用して、レジストリのセキュリティを維持する。

https://learn.microsoft.com/ja-jp/azure/container-registry/security-controls-policy

「Azure セキュリティベンチマーク」（Azure policyのイニシアチブ）を使用して、コンテナーレジストリのセキュリティ設定についての推奨事項を得ることができる。



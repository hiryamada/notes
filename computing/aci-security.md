# Azure Container Instances のセキュリティ

※というタイトルだが、ここで説明される考え方は、ACIだけではなくコンテナーの運用全体に適用可能。

ドキュメント（Azure Container Instances のセキュリティに関する考慮事項）
https://learn.microsoft.com/ja-jp/azure/container-instances/container-instances-image-security

Microsoft Learn  AZ-500: プラットフォーム保護の実装  / コンテナーのセキュリティを有効にする / Azure Container Instances のセキュリティを構成する
https://learn.microsoft.com/ja-jp/training/modules/enable-containers-security/3-configure-azure-container-instances-security

■プライベートレジストリを使用する

パブリックなコンテナー リポジトリ（Docker Hub等）に格納されているイメージのセキュリティは保証されない。

https://www.infoq.com/jp/news/2021/03/dockerhub-image-vulnerabilities/

> Docker Hubにある400万近いイメージを分析した結果、51パーセント以上のイメージに悪用可能な脆弱性のあることが判明した。

> 多くは暗号通貨のマイニングに関するもの

> 6,432のイメージにはマルウェアが発見された

> Apache TomcatやJenkinsといった一般的なソフトウェアを含むイメージの一部にもマルウェアが見つかっている

> 公式にメンテナンスされているイメージに限って使用すべき

攻撃の脅威を減らすには、Azure Container Registry や Docker Trusted Registry などのプライベート レジストリにイメージを格納して、そこから取得する。

プライベート レジストリは、悪意のある第3者によって危険なイメージを格納される心配がないため、パブリックなリポジトリよりも安全と考えられる。

■コンテナー イメージを監視してスキャンする

Microsoft Defender for Cloud と統合して、レジストリにプッシュされたすべてのイメージを自動的にスキャンする。

（Microsoft Defender for Cloud＞強化されたセキュリティ機能＞Microsoft Defender for Containers）

イメージの脆弱性が検出され、それらが分類され、修復のガイダンスが提供される。

脆弱性評価:
https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-containers-introduction#vulnerability-assessment

- レジストリとランタイムの推奨事項
- 修復ガイダンス
- 新しいイメージのクイック スキャン
- 実際の悪用に関する分析情報
- など

詳細: 
https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/agentless-vulnerability-assessment-azure

■資格情報を保護する


コンテナー内に資格情報（アクセスキー、APIキー、パスワードなど）を埋め込まない。

コンテナー運用のためのサービスで利用可能な、機密情報を管理する仕組みを用いて、機密情報を利用する。

例: ACI + マネージドID + Azure Key Vault

```
ACI + マネージドID
↑ シークレットを読み取る
Azure Key Vault
└シークレット（パスワード等）
```




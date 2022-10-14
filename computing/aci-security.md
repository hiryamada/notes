# Azure Container Instances のセキュリティ

※というタイトルだが、ACIだけではなくコンテナーの運用全体に適用可能。

ドキュメント（Azure Container Instances のセキュリティに関する考慮事項）
https://learn.microsoft.com/ja-jp/azure/container-instances/container-instances-image-security

Microsoft Learn  AZ-500: プラットフォーム保護の実装  / コンテナーのセキュリティを有効にする / Azure Container Instances のセキュリティを構成する
https://learn.microsoft.com/ja-jp/training/modules/enable-containers-security/3-configure-azure-container-instances-security

■プライベートレジストリ内の（安全性が確認された）イメージを使用する

パブリックなコンテナー リポジトリ（Docker Hub等）に格納されているイメージのセキュリティは保証されない。

https://www.infoq.com/jp/news/2021/03/dockerhub-image-vulnerabilities/

> Docker Hubにある400万近いイメージを分析した結果、51パーセント以上のイメージに悪用可能な脆弱性のあることが判明した。

> 多くは暗号通貨のマイニングに関するもの

> 6,432のイメージにはマルウェアが発見された

> Apache TomcatやJenkinsといった一般的なソフトウェアを含むイメージの一部にもマルウェアが見つかっている

> 公式にメンテナンスされているイメージに限って使用すべき

攻撃の脅威を減らすには、Azure Container Registry や Docker Trusted Registry などのプライベート レジストリにイメージを格納して、そこから取得する。

プライベート レジストリは以下の観点でパブリック レジストリよりも安全と考えられる。

- 認証された正規のユーザー（Azure ADで認証された組織内のユーザー）だけがイメージを格納できる。
- 悪意のある第3者によって危険なイメージを格納される心配がない。


■機密情報を保護する（コンテナー内に機密情報を埋め込まない）

コンテナー運用のためのサービスに組み込まれている、機密情報を管理する仕組みを用いて、機密情報を利用する。

例: ACI + マネージドID + Azure Key Vault

```
ACI + マネージドID
↑ シークレットを読み取る
Azure Key Vault
└シークレット（パスワード等）
```




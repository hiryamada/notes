Azure Container Registry

- プライベートな Docker レジストリ サービス
- Docker コンテナー イメージおよび関連する成果物を保存、管理する

※Azure portalでは「コンテナー レジストリ」と検索。

[製品ページ](https://azure.microsoft.com/ja-jp/services/container-registry/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-intro)

■SKU

https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-skus

上位の SKU を選択すると、高いパフォーマンスとスケーリング、追加機能が提供される。

- Basic
- Standard
- Premium
  - プライベートエンドポイント接続
  - カスタマーマネージドキーによる暗号化
  - geoレプリケーション

■geoレプリケーション

https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-geo-replication

イメージが実行される各リージョンにコンテナー レジストリを配置してネットワーク上の近い場所での操作を可能にすることで、高速で信頼性の高いイメージ レイヤー転送を実現。

geo レプリケーションは、Premium レジストリの機能。

■コマンド

az acrコマンド - レジストリの操作に使用。az acr login, az acr build など。

dockerコマンド - レジストリに対するイメージのプッシュやプルに使用。docker push, docker pull など。

■Azure Container Registry での認証

https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-authentication

ACRは「プライベートなレジストリ」である。つまり、使用する前に認証が必要。

- Azure ADでの個々のログイン
  - 開発者が、自分のAzure ADユーザーとしてサインインして、ACRを使用するための方法。
    - `az login`
  - ACRにログインする
    - `az acr login --name レジストリ名.azurecr.io`
    - このログイン（トークン）は3時間有効。有効期限が切れたら再度`az acr login`を実行する。
  - 以降, docker コマンドでACRを利用できる
- サービス プリンシパルによる ACR 認証
  - レジストリに対するプル、プッシュとプル、またはその他のアクセス許可を持つ「サービスプリンシパル」を作成するための方法。
  - 人間ではなく、スクリプトなどで使用（自動化、無人化、ヘッドレス）
  - 「サービス プリンシパル」を作成し、acrpull / acrpush / owner などのロールを割り当てる
    - `az ad sp create-for-rbac --name サービスプリンシパル名 --scope レジストリのID --role acrpull --query password`
  - 上記コマンドで指定したサービスプリンシパル名と、出力されたパスワードを使って、ACIでイメージをプルして実行する例
    - `az container create --registory-login-server レジストリ名.azurecr.io --registry-username サービスプリンシパル名 --registory-password パスワード`
- 管理者アカウント
  - デフォルトでは無効
  - Azure portal＞コンテナー レジストリ＞アクセスキー＞管理者ユーザー を「有効」にする
  - レジストリに対する完全なアクセス権がある
  - `docker login レジストリ名.azurecr.io` に続き、ユーザー名とパスワードを入力

■脆弱性スキャン(Microsoft Defender for Cloudとの統合)

https://azure.microsoft.com/ja-jp/updates/vulnerability-scanning-for-images-in-azure-container-registry-is-now-generally-available/

https://docs.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-container-registries-introduction

- ACR にイメージをプッシュすると、Microsoft Defender for container registries によってそのイメージが自動的にスキャンされ、パッケージまたはファイルで定義されている依存関係の既知の脆弱性が確認される。
- スキャンが完了すると(通常2分以内)、検出された各脆弱性の詳細およびセキュリティの分類と共に、問題を修正して脆弱な攻撃面を保護する方法についてのガイダンスが Microsoft Defender for container registries によって提供される。
- この機能は、情報セキュリティの主要プロバイダーである Qualys によって提供されている。(Qualysスキャナー)

# モジュール7 アプリケーション構成とシークレットの管理

DevOpsの速度に合わせ、セキュリティ対策も速度を上げる必要がある。そのためには、自動化を行う。

## セキュリティの概要

### セキュリティの概要

DevOpsにおけるセキュリティの考え方とは。

- 多層防御 
  - [複数の防衛線を用意する](https://ascii.jp/elem/000/004/040/4040381/)。
  - [ベストプラクティス](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/best-practices-and-patterns)に従う。
- DevOpsにセキュリティを組み込む 
  - [DevSecOps](https://azure.microsoft.com/ja-jp/solutions/devsecops/)
- セキュリティ対策はチーム全体の責任。
  - [DevOps は開発チームや運用チームだけのものではありません(Red Hat)](https://www.redhat.com/ja/topics/devops/what-is-devsecops)。
  - セキュリティを常に意識して「作り込む」（あとから対策を付け足すのではない）
- セキュリティ対策を自動化する
  - コードの脆弱性スキャン - [SonarQube](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube)をAzure Pipelineに組み込むなど
  - Dockerコンテナの脆弱性スキャン - Azure Container Registryで[Qualysスキャナ](https://azure.microsoft.com/ja-jp/updates/vulnerability-scanning-for-images-in-azure-container-registry-is-now-generally-available/)を使用
  - プロジェクトでの脆弱性があるパッケージの使用のチェック - Azure Pipelines[WhiteSource](https://marketplace.visualstudio.com/items?itemName=whitesource.whitesource)

なお、Azureのセキュリティの学習については[AZ-500 Security Technologies](https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-500t00)というコースもご利用いただけます。

### SQL インジェクション攻撃

SQLインジェクション攻撃（SQL Injection、SQLi）とは何か。

悪意のあるSQLステートメントの実行を可能にする攻撃。
- [SQLインジェクション（Wikipedia）](https://ja.wikipedia.org/wiki/SQL%E3%82%A4%E3%83%B3%E3%82%B8%E3%82%A7%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3)
- [OWASPのドキュメント](https://owasp.org/www-community/attacks/SQL_Injection)

対策
- [OWASPのドキュメント](https://owasp.org/www-community/attacks/SQL_Injection)のガイドに従う
  - プリペアードステートメントを使う
  - ストアドプロシージャを使う
  - 許可リストを使う
  - ユーザーの入力すべてをエスケープする
- [Azure Web アプリケーション ファイアウォール（Azure WAF）](https://azure.microsoft.com/ja-jp/services/web-application-firewall/)で防ぐ
- [IPA「安全なウェブサイトの作り方」](https://www.ipa.go.jp/security/vuln/websecurity.html)の別冊[「安全なSQLの呼び出し方」](https://www.ipa.go.jp/files/000017320.pdf)

※このページに書かれた「シミュレーション」手順についてはラボで実施

## 安全な開発プロセスの実装

脅威モデリング

デモンストレーション: 脅威モデリング

重要な検証ポイント

継続的インテグレーション

## アプリケーション構成データの再考

アプリケーション構成データの再考

懸念事項の分離

外部構成ストア パターン

Azure Key Vault と Azure Pipeline の統合

## 秘密、トークン、および証明書を管理する

シークレット、トークン、および証明書の管理

DevOps の内側と外側のループ

## ID 管理システムとの統合

GitHub とシングル サインオン (SSO) の統合

サービス プリンシパル

管理サービス ID

## アプリケーション構成の実装

Azure App Configuration の概要

キーと値のペア

App Configuration 機能の管理

## ラボ

Skillpipe モジュール7 「アプリケーション構成とシークレットの管理 / セキュリティの概要 / SQLインジェクション攻撃」のページを参照しながら、実際にSQLインジェクション攻撃をシミュレーションしてみる。

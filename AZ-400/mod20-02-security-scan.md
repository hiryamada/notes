# 脆弱性セキュリティチェックツール

- OWASPとは
- SonarCloud
- CodeQL
- Dependabot

### OWASP セキュア コーディング プラクティスの実装計画

■OWASPとは？

https://owasp.org/www-chapter-japan/

> OWASP - Open Web Application Security Project とは、Webをはじめとするソフトウェアのセキュリティ環境の現状、またセキュアなソフトウェア開発を促進する技術・プロセスに関する情報共有と普及啓発を目的としたプロフェッショナルの集まる、オープンソース・ソフトウェアコミュニティです。The OWASP Foundationは、NPO団体として全世界のOWASPの活動を支えています。

## 継続的なセキュリティ検証の実装

### OWASP ZAP 侵入テスト

[IPA（情報処理推進機構）による、脆弱性検査ツールの紹介](https://www.ipa.go.jp/about/technicalwatch/20131212.html)。[OWASP ZAP](https://owasp.org/www-project-zap/)、Paros、Ratproxyを比較している。

### SonarCloud

https://sonarcloud.io/

[Azure Pipelineの拡張機能](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarcloud)として利用できる。

パブリックプロジェクト（GitHubのパブリックリポジトリでホスティングされているプロジェクト等）では[無料で使用することができる](https://sonarcloud.io/pricing)。

※SonarQubeとSonarCloudの違い

- SonarQube
  - オンプレミスで運用できる
  - インストールが必要
  - Community editionは無料、その他は有料
  - Azure DevOps Serverにも対応
- SonarCloud
  - クラウド型(SaaS)
  - インストール不要
  - パブリックプロジェクトでは無料、その他は有料
  - GitHub, Bitbucket, GitLab, Azure DevOps Servicesと組み合わせて利用できる

SonarSource社による情報:

- [価格と機能](https://www.sonarsource.com/plans-and-pricing/)
- [Q&A](https://community.sonarsource.com/t/sonarcloud-vs-sonarqube/9557/2)

### GitHub の CodeQL

コードの脆弱性診断を行うツール。

パブリックプロジェクトでは[無料で使用することができる](https://project.nikkeibp.co.jp/idg/atcl/19/00002/00052/)。

[CodeQL for research](https://securitylab.github.com/tools/codeql/)

[Githubの新しいセキュリティ機能 CodeQLを使ってみる](https://security-index.hatenablog.com/entry/2020/06/05/211454)

### GitHub Dependabot アラートとセキュリティ更新プログラム

脆弱性があるライブラリをプロジェクトで使用している場合、自動的に通知したり、プルリクエストを作って知らせてくれたりするツール。

[対応するパッケージ管理ツール](https://docs.github.com/ja/code-security/supply-chain-security/understanding-your-software-supply-chain/about-the-dependency-graph#supported-package-ecosystems)

- [Dependabot アラート](https://docs.github.com/ja/code-security/supply-chain-security/managing-vulnerabilities-in-your-projects-dependencies/about-alerts-for-vulnerable-dependencies)
  - 脆弱性のある依存関係を検出すると通知（アラート）を作成。
  - リポジトリの通知設定に従って通知を行う
- [Dependabot セキュリティアップデート](https://docs.github.com/ja/code-security/supply-chain-security/managing-vulnerabilities-in-your-projects-dependencies/about-dependabot-security-updates)
  - 脆弱性のある依存関係を修正するプルリクエストを自動生成
- [Dependabot バージョンアップデート](https://docs.github.com/ja/code-security/supply-chain-security/keeping-your-dependencies-updated-automatically/about-dependabot-version-updates)
  - 古い依存関係を最新バージョンに更新するプルリクエストを発行
  - （脆弱性の有無に関係なく、古いバージョンの依存関係を発見して最新化）

[Dependabot](https://dependabot.com/)

使用条件はページ下部に記載されている。（GitHubでホスティングされているオープンソースであること等）

[Dependabotを導入してみた](https://dev.classmethod.jp/articles/dependabot-101/)

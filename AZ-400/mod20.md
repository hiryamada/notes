# モジュール20 コンプライアンス向けのコード ベースの検証

■前半: オープンソースソフトウェア

- オープンソースソフトウェアとは
- ライセンスとは

■後半: 脆弱性セキュリティチェックツール

- OWASPとは
- SonarCloud
- CodeQL
- Dependabot

## オープンソース ソフトウェア

### ソフトウェアのビルト方法

注: タイトルに「ビルド方法」とあるが、ここはOSSの使用に関する解説。

■ライセンス

参考: http://www.it-houmu.com/archives/1848

利用するソフトウェアの各ライセンスを確認し、それを遵守することが重要。

■オープンソースとクローズドソース


### オープンソース ソフトウェアとは?

■オープンソースの定義

■Microsoftとオープンソースの関係

### オープンソース ソフトウェア コンポーネントに関する企業の懸念

OSS利用時の課題

### オープンソース ライセンス

オープンソースの定義による、ライセンスでしてはいけないこと。

### 一般的なオープンソース ライセンス

GPL、MPL、BSDなどの分類

### ライセンスの意味と評価

## セキュリティおよびコンプライアンス ポリシーの管理

### コンプライアンスのためのコード ベースの検査と検証

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

### GitHub の CodeQL

コードの脆弱性診断を行うツール。

パブリックプロジェクトでは[無料で使用することができる](https://project.nikkeibp.co.jp/idg/atcl/19/00002/00052/)。

[CodeQL for research](https://securitylab.github.com/tools/codeql/)

[Githubの新しいセキュリティ機能 CodeQLを使ってみる](https://security-index.hatenablog.com/entry/2020/06/05/211454)

### GitHub Dependabot アラートとセキュリティ更新プログラム

脆弱性があるライブラリをプロジェクトで使用している場合、自動的にプルリクエストを作って知らせてくれるツール。

使用条件はページ下部に記載されている。（GitHubでホスティングされているオープンソースであること等）

[Dependabot](https://dependabot.com/)

[Dependabotを導入してみた](https://dev.classmethod.jp/articles/dependabot-101/)

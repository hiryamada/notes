

# Chef

Chef社（元 Opscode社, 2013年頃に社名を変更）が開発する構成管理ツール。

オンプレミスのコンピュータや、Azure VMの構成を行うことができる。構成は「レシピ」と呼ばれる。VMの作成を行うこともできる。

[chef](https://ejje.weblio.jp/content/chef): 料理人、コック、コック長

■ドキュメント

- Microsoft Docsのドキュメント:
  - [Azure 上の Chef](https://docs.microsoft.com/ja-jp/azure/developer/chef/)
  - 現在はすべてのコンテンツは削除されている。
  - 代わりに [Chefのサイトのドキュメント](https://docs.chef.io/azure_portal)を見るように案内がある

[公式サイト](https://www.chef.io/)

■特徴

- Ruby / Erlangで実装。
- レシピ（Ruby DSL）を使用して構成を定義。
- クライアント・サーバー型
  - Chefサーバー
  - ノード（Chefクライアント）：管理対象のVM
  - ワークステーション：管理者用
- Chef Solo: スタンドアロン版のChef。
  - 後続の Chef Zero もある。
- knifeコマンド
  - Chefインフラを操作するためのコマンド。
- [Azure VMの拡張機能](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/chef)が利用可能
  - Azure VMに対してChefを簡単に有効化できる

■製品群

- Chef
  - インフラ（データセンター）の自動化
- Chef Habitat
  - [2016年6月に発表](https://www.publickey1.jp/blog/16/chefhabitatdocker.html)
  - アプリケーションの自動化
- [InSpec](https://community.chef.io/tools/chef-inspec)
  - アプリとインフラの状態をテスト・監査するためのフレームワーク
  - Compliance as Code
  - [Serverspec](https://serverspec.org/)を拡張したもの
- Chef Automate
  - [2016年7月に発表](https://www.publickey1.jp/blog/16/chefchef_automate.html)
  - Chef、Habitatなどを統合管理、可視化

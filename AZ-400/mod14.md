# モジュール14 Azureで利用可能なコード ツールとしてのサードパーティ インフラストラクチャの利用

代表的なサードパーティ製の構成管理ツールを学ぶ。

- Chef
- Puppet
- Ansible
- Terraform


## Chef（シェフ）

Chef社（元 Opscode社, 2013年頃に社名を変更）が開発する構成管理ツール。

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

## Puppet（パペット）

Puppet社が開発する構成管理ツール。

[puppet](https://ejje.weblio.jp/content/puppet): 操り人形

[公式サイト](https://puppet.com/)

■特徴

- Rubyで実装。
- クライアント・サーバー型
  - サーバー: 「Puppetマスター」
  - クライアント：「Puppetエージェント」をインストール
- 「Puppet プログラム ファイル」（～.pp）を使用して状態を宣言
- [Azure VMの拡張機能](https://azure.microsoft.com/ja-jp/updates/puppet-extension-is-now-available-for-azure/)が利用可能（だった？）
  - 現在、VMの拡張機能の一覧には存在しない模様。

■製品群

- Puppet
- Puppet Enterprise
  - OSの設定と更新、およびミドルウェアやアプリケーションの導入・設定・更新を自動化するソフトウェア
  - Azure Marketplaceからインストールが可能

## Ansible （アンシブル）

Red Hat社が開発する構成管理ツール。

■公式サイト
- [1](https://www.ansible.com/)
- [2](https://www.redhat.com/ja/technologies/management/ansible) 

■ドキュメント

- Microsoft Docsのドキュメント:
  - [Azure での Ansible の使用](https://docs.microsoft.com/ja-jp/azure/developer/ansible/overview)
  - [クイック スタート:Linux 仮想マシンを構成する](https://docs.microsoft.com/ja-jp/azure/developer/ansible/vm-configure?tabs=ansible)
- Ansibleのガイド
  - [Ansibleユーザーガイド](https://docs.ansible.com/ansible/2.9_ja/user_guide/index.html)
  - [Microsoft Azure ガイド](https://docs.ansible.com/ansible/2.9_ja/scenario_guides/guide_azure.html)

■名前の由来：[アンシブル](https://ja.wikipedia.org/wiki/%E3%82%A2%E3%83%B3%E3%82%B7%E3%83%96%E3%83%AB) （SFに登場する超光速通信技術）

■デプロイできるもの
- VM、コンテナー
- 仮想ネットワーク、ストレージ、サブネット、リソース グループなど

■特徴

- Pythonで実装。
- 各環境に容易にインストールが可能。Pythonのpipコマンドでもインストールできる。
- サーバーを管理する際、管理対象のサーバーに「エージェント」を入れる必要がない（エージェントレス）。
  - SSHとPythonが使えればOK.
- 「モジュール」を使って機能を拡張できる。
  - Azure: [Ansible collection for Azure](https://github.com/ansible-collections/azure)
  - ARMを介して、Azureリソースを操作できる
- 冪等性をツール側で保証。
- プレイブック（YAML）を使用して構成を定義。
  - ～.yml という名前で保存
- コマンド（ansible-playbook）がCloud Shellにインストール済みで、すぐに利用できる
- リソースの作成だけではなく、[VMの起動や終了](https://docs.microsoft.com/ja-jp/azure/developer/ansible/vm-manage#stop-a-virtual-machine)も可能

■製品群

コミュニティ版
- Ansible Project: Ansible Engineに相当
- AWX Project: Ansible Towerに相当

エンタープライズ版（Red Hat社のサポートあり）
- Ansible Engine
- [Ansible Tower](https://www.ansible.com/products/tower)

■プレイブック（～.yml）

```
- name: example
  hosts: localhost
  connection: local
  tasks:
  - name: Create resource group
    azure_rm_resourcegroup:
      name: ansibleTestResouceGroup
      location: eastus
```

■使用手順（Azure Cloud Shell）

- プレイブック（～.yml）を作成
- `ansible-playbook ～.yml`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。

## Terraform（テラフォーム）

[公式サイト](https://www.terraform.io/)

[HashiCorp社](https://www.hashicorp.com/)が開発する構成管理ツール。

[テラフォーミング](https://ja.wikipedia.org/wiki/%E3%83%86%E3%83%A9%E3%83%95%E3%82%A9%E3%83%BC%E3%83%9F%E3%83%B3%E3%82%B0)

■特徴

- [Goで実装](https://github.com/hashicorp/terraform)。
- 「プロバイダー」を使用して機能を拡張できる。
  - [Azureプロバイダー](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs)
- 冪等性をツール側で保証。
- HCL(HashiCorp Configuration Language)を使用して構成を定義。
  - ～.tf という名前で保存
- コマンド（terraform）がCloud Shellにインストール済みで、すぐに利用できる

■製品群

- [Terraform CLI](https://www.terraform.io/docs/cli/index.html)
- [Terraform Cloud](https://www.terraform.io/cloud)
  - Cloud infrastructure automation as a Service（サービスとしてのクラウド自動化）
  - 複数のクラウドプロバイダー（Azure, AWS, GCP等）を一箇所からコントロール
  - チームや組織でTerraformを利用する場合におすすめ
- [Terraform Enterprise](https://www.terraform.io/docs/enterprise/index.html)
  - セルフホストのTerraform Cloud

■構成ファイルの例
```
provider azurerm {
  features {}
}

resource "azurerm_resource_group" "test" {
 name     = "terraformTestResourceGroup"
 location = "East US"
}
```

■使用手順（Azure Cloud Shell）

- 構成ファイル(～.tf)を作成
- `terraform init`
- `terraform plan`
- `terraform apply -auto-approve`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。

## Azure Cloud Shell

参考: [Azure Cloud Shellにインストール済みのツール](https://docs.microsoft.com/ja-jp/azure/cloud-shell/features)

Terraform, Ansible などのコマンドは、Azure Cloud Shellに導入済みであり、すぐに使用することができる。

## ラボ

■Ansible

(1) クイックスタート: [Azure Cloud Shell を使用した Ansible の構成](https://docs.microsoft.com/ja-jp/azure/developer/ansible/getting-started-cloud-shell)

(2) AZ-400 ラボ: [Ansible](https://microsoftlearning.github.io/AZ-400JA-Designing-and-Implementing-Microsoft-DevOps-solutions/Instructions/Labs/AZ400_M14_Ansible_with_Azure.html)

■Terraform

(1) クイックスタート: [Azure Cloud Shell を使用した Terraform の構成](https://docs.microsoft.com/ja-jp/azure/developer/terraform/get-started-cloud-shell)

(2) AZ-400 ラボ: [Terraform](https://microsoftlearning.github.io/AZ-400JA-Designing-and-Implementing-Microsoft-DevOps-solutions/Instructions/Labs/AZ400_M14_Automating_infrastructure_deployments_in_the_Cloud_with_Terraform.html)


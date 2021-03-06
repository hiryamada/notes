# AZ-400 Designing and Implementing Microsoft DevOps solutions

AZ-400T00JA-A - Microsoft DevOps ソリューションの設計と実装

コース情報
https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-400t00

- 日数: 5
- モジュール: 20

# 日程


## day 1 DevOps, ソースコードの管理

- DevOps
  - [モジュール1](mod01.md) DevOpsの概要, Azure DevOps, Azure Boards
- ソースコードの管理
  - [モジュール2](mod02.md) ソース管理, Git, Azure Repos
  - [モジュール3](mod03.md) 技術的負債, コードの品質

## day 2 継続的インテグレーション(CI)

- [モジュール4](mod04.md) エンタープライズGit
- [モジュール5](mod05.md) Azure Pipelines 基本
- [モジュール6](mod06.md) Azure Pipelines 応用
- ※モジュール7（セキュリティ）は最終日に移動

## day 3 継続的デリバリー(CD), リリース/デプロイ戦略

- CD
  - [モジュール8](mod08.md) GitHub Actions
  - [モジュール9](mod09.md) Azure Artifacts, パッケージ管理
- リリース/デプロイ戦略
  - [モジュール10](mod10.md) リリース戦略
  - [モジュール11](mod11.md) Azure Pipeline によるCD
  - [モジュール12](mod12.md) デプロイパターン

## day 4 IaC, コンテナー仮想化

- IaC
  - [モジュール13](mod13.md) IaC: ARM/CLI/PwerShell/Automation
  - [モジュール14](mod14.md) IaC: Chef/Puppet/Ansible/Terraform
- コンテナー仮想化
  - [モジュール15](mod15.md) Docker
  - [モジュール16](mod16.md) Kubernetes

## day 5 フィードバックの活用,セキュリティ

- フィードバックの活用
  - [モジュール17](mod17.md) 開発チーム向けのフィードバック、モニタリング
  - [モジュール18](mod18.md) システムのフィードバック
- セキュリティ
  - [モジュール7](mod07.md) セキュリティ設計, 設定・機密情報の管理
  - [モジュール19](mod19.md) DevSecOps, Security Center, Blueprints, ATP
  - [モジュール20](mod20.md) コードベース検証

（参考）[Edifist様 短縮3日コース](https://www.edifist.co.jp/it/course/MSCAZ400), [Trainocate 速習コース](https://www.trainocate.co.jp/reference/course_details.aspx?code=MSC0751V)


# 製品/分野とモジュールの対応

```
■ Azure DevOps
Azure DevOps Services
├wiki 3 
├Azure Boards 1
├Azure Repos 2, 4
├Azure Pipelines 5, 6, 10(リリース), 11, 12(デプロイ), 20
├Azure Test Plans
└Azure Artifacts 9
■GitHub
GitHub Codespaces 3
GitHubアクション, 8
■セキュリティ
Key Vault 7
Security Center 19
■IaC
ARMテンプレート, CLI, PowerShell, Automation, DSC 13
Chef, Puppet, Ansible, Terraform 14
■コンテナー
Docker 15
AKS 16
■監視
Azure Monitor, Application Insights 17
■フィードバック
Teams 18
```

# 認定試験

https://docs.microsoft.com/ja-jp/learn/certifications/exams/az-400

認定の前提条件
Microsoft Certified: DevOps Engineer Expert の認定を受けるには、次の少なくとも 1 つが必要です。
- Microsoft Certified: Azure Administrator Associate (AZ-104)
- Microsoft Certified: Azure Developer Associate (AZ-204)

# 主な関連サイト

[Azure DevOps](https://azure.microsoft.com/ja-jp/services/devops/)

[Azure DevOps Labs](https://azuredevopslabs.com/)

Microsoft Learn
- [DevOps プラクティスを発展させる](https://docs.microsoft.com/ja-jp/learn/paths/evolve-your-devops-practices/)

# 参考ブログ

https://qiita.com/ymasaoka/items/d3c89ff52e0ef2b568b0

https://yomon.hatenablog.com/entry/2020/02/az400_cert

https://tech-blog.cloud-config.jp/2020-09-01-a-story-that-passed-the-az-400-after-happily-raising-the-level/

https://satton-infra.com/az400-devops/

https://www.slideshare.net/KentaroHigashi/az400-205871188

https://www.simpletraveler.jp/2020/10/06/microsoftazure-certificate-report-azuredevopsengineerexpert/

https://blog.trainocate.co.jp/blog/415_018

https://onarimon.jp/entry/2020/07/20/181845

# Microsoft Learnコレクション

https://docs.microsoft.com/ja-jp/learn/certifications/exams/az-400

https://docs.microsoft.com/ja-jp/users/khigashi/collections/631ybyrz26n72

# その他

https://www.azuredevops.tips/

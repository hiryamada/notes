
# AZ-500 Microsoft Azure Security Technologies

クラウドおよびハイブリッド環境で ID、アクセス、データ、アプリケーション、ネットワークを保護する Azure セキュリティについて学ぶコースです。

日程: 4日間

<!--
教材や、認定試験の出題範囲についての詳細は、以下のページをご覧ください。

認定資格 Microsoft Certified: Azure Security Engineer Associate
https://learn.microsoft.com/ja-jp/credentials/certifications/azure-security-engineer/
-->

<!--
## 教材(Microsoft Learn)の構成

コース資料
https://learn.microsoft.com/ja-jp/training/courses/az-500t00

上記ページの下部に、教材(Microsoft Learn)へのリンクがあります。

全8モジュール。
-->

## 1日目 Entra ID

<!--
- モジュール1 Microsoft Entra ID で ID を管理する
- モジュール2 Microsoft Entra ID を使用して認証を管理する
- モジュール3 Microsoft Entra ID を使用して認可を管理する
- モジュール4 Microsoft Entra ID でアプリケーション アクセスを管理する
- ラボ4 ディレクトリ同期の導入(省略)
-->

- [講義資料](mod01/mod01.md)
- ラボ1/講師デモ ロール ベースのアクセス制御
  - 「GitHubからファイルをダウンロード」はスキップ。このラボではファイルは使用しません
  - 演習1 Azure portalによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1（ユーザー Joseph の作成）はスキップ。
    - ※このラボ環境では、ユーザーの新規作成はできません。
    - Joseph-xxxxxx@LODSPRODMCA.onmicrosoft.com といったユーザーが作成されていますのでそれを使用します。画面右上「リソース」タブで確認できます。
  - 演習2 Azure PowerShellによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1（ユーザー Isabel の作成）も同様にスキップ。
  - 演習3 Azure CLIによるユーザー作成、グループ作成、グループへのユーザー追加
    - タスク1（ユーザー Dylan の作成）も同様にスキップ。
  - 演習4 リソースグループの作成、Entra IDグループへのロールの割り当て
  - 「リソースのクリーンアップ」はスキップします。

## 2日目 ネットワークセキュリティ

<!--
- モジュール5 仮想ネットワークのセキュリティを計画して実装する
- モジュール6 Azure リソースへのプライベート アクセスのセキュリティを計画して実装する
- モジュール7 Azure リソースへのパブリック アクセスのセキュリティを計画して実装する
-->

- [講義資料](mod02/mod02.md)
- ラボ2 ネットワーク セキュリティ グループとアプリケーション セキュリティ グループ
- ラボ3 Azure Firewall

## 3日目 アプリケーションとデータのセキュリティ

<!--
- モジュール8 コンピューティングの高度なセキュリティを計画して実装する
- モジュール9 ストレージのセキュリティを計画して実装する
- モジュール10 Azure SQL Database と Azure SQL Managed Instance のセキュリティを計画して実装する
-->

- [講義資料](mod03/mod03.md)
- ラボ4 ACR と AKS の構成とセキュリティ保護
- ※ラボ5（ディレクトリ同期）は実施しません
- ラボ6 Azure SQL データベースのセキュリティ保護
- ラボ7 サービス エンドポイントとストレージの保護
- ラボ8 キー コンテナー

## 4日目 モニタリングと管理

<!--
- モジュール11 セキュリティのガバナンスを計画、実装、管理する
- モジュール12 Microsoft Defender for Cloud を使用してセキュリティ態勢を管理する
- モジュール13 Microsoft Defender for Cloud を使用して脅威に対する保護を構成して管理する
- モジュール14 セキュリティ監視とオートメーション ソリューションを構成して管理する
-->

- [講義資料](mod04/mod04.md)
- ラボ9 Azure Monitor, Microsoft Defender for Cloud, Microsoft Sentinel

## ラボの実施方法

[ラボ環境の利用方法のご案内(PDF)](../ラボ環境の利用方法.pdf)

ラボ環境はご受講後半年後までご利用いただけます。

- Microsoftアカウントを（なければ）作成 ([作成方法](https://support.microsoft.com/ja-jp/account-billing/%E6%96%B0%E3%81%97%E3%81%84-microsoft-%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88%E3%82%92%E4%BD%9C%E6%88%90%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95-a84675c3-3e9e-17cf-2911-3d56b15c0aaf))
- ラボ環境にMicrosoftアカウントでサインイン （[ラボ環境](https://esi.learnondemand.net/)）
- トレーニングキーを投入（1回だけ実施）
- ラボを起動（新しいウィンドウが開きます）
  - 各ラボには起動回数に制限があります。
- 新しいウィンドウの画面右側に表示される手順書に従ってラボを進めます。

トレーニングキーについて:
- トレーニングキーは講師よりお伝えします。
- トレーニングキーの投入は、トレーニング初日～最終日の間に実施する必要があります。

ラボ実施におけるトラブルについて:
- ラボ環境が起動できない、起動しても真っ黒な画面が表示されたままとなる、といった場合は、[こちら](https://docs.learnondemandsystems.com/tms/connectivity-requires.md)を確認してください。
- 企業内ネットワークや企業貸与PCの場合、その設定の制約によりラボ環境が利用できない場合があります。
  - その場合はご自宅のネットワーク・ご自宅のPCなどから接続をお試しください。

## まとめ

- [全体のまとめ](matome.md)
- [試験対策](exam.md)
- [クロージング(終了時のご案内)](../closing-cloudslice.md)
- 講師連絡先ご案内
- アンケート（受講者満足度調査）の実施

<!--

■コース日程

- [day 1](mod01/mod01.md)
  - Azure ADの基礎
    - MFA
      - ラボ4a(演習1,2)
  - Azure ADのセキュリティ機能
    - MFA
    - 条件付きアクセス
    - アクセスレビュー
    - Identity Protection
      - ラボ4 MFA / 条件付きアクセス / Identity Protection
    - Privileged Identiy Management (PIM)
      - ラボ5 PIM
    - ハイブリッドID (Azure AD Connect)
      - ラボ6 Azure AD Connect
  - エンタープライズ ガバナンス
    - ロール
    - ポリシー
    - ロック
      - ラボ1/2/3 Azure RBAC / ポリシー / ロック
- [day 2](mod02/mod02.md) プラットフォーム保護
  - 境界セキュリティ(VNet,DDoS, Firewall)
    - ラボ8
  - ネットワークセキュリティ(NSG, ASG, Endpoint, App GW, WAF, Front Door, UDR, ExpressRoute)
    - ラボ7
  - ホストセキュリティ
  - コンテナセキュリティ
    - ラボ9
- [day 3](mod03/mod03.md)
  - Key Vault
    - ラボ10 Key Vault
  - アプリケーションセキュリティ
    - IDプラットフォーム, アプリの登録, Microsoft Graph, Managed ID
  - ストレージセキュリティ
    - ラボ11
  - DBセキュリティ
    - ラボ12
- [day 4](mod04/mod04.md)
  - Azure Monitor
  - Microsoft Defender for Cloud
  - Azure Sentinel
    - ラボ13/14/15
-->

<!--
# ラボ

https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/
https://github.com/MicrosoftLearning/
-->

<!--

全15ラボ

https://github.com/MicrosoftLearning/AZ500-AzureSecurityTechnologies

https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies

https://github.com/MicrosoftLearning/AZ500-AzureSecurityTechnologies.ja-jp

https://github.com/MicrosoftLearning/AZ500-AzureSecurityTechnologies.ja-jp/tree/main/Instructions/Labs

注意：ラボ13, 14, 15は続きの内容になっており、かつ、途中の待ち時間がかなりかかるものとなっています。待ち時間を含めると、トータルで2時間ほど要すると思われます。少し余裕を持って取り組みましょう。

-->

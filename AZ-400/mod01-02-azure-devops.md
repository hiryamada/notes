# Azure DevOps

https://azure.microsoft.com/ja-jp/services/devops/

## Azure DevOpsの概要

- [→Azure DevOpsの概要](pdf/Azure%20DevOpsの概要.pdf)
- [→機能の連携](pdf/Azure%20DevOps機能の連携.pdf)

```
Azure DevOpsの画面 (dev.azure.com)
└Azure DevOps組織 ←ユーザー
 └プロジェクト - 概要, wiki, dashboard
  ├Azure Boards - 「エピック」,「作業項目」,「タスク」
  ├Azure Repos リポジトリ
  ├Azure Pipelines パイプライン
  └Azure Artifacts フィード
※ユーザー：Azure ADユーザー, Microsoftアカウント, GitHubアカウント
```

## Azure DevOpsの機能

- [→Azure DevOpsの機能の連携](pdf/Azure%20DevOps機能の連携.pdf)


## ユーザーの追加(招待)

Azure DevOpsでは、以下の種類のユーザーを追加(招待)することができる。

- 「Azure DevOps組織」がAzure ADに接続されている場合:
  - Azure ADユーザー(組織のユーザー)のメールアドレス
- 「Azure DevOps組織」がAzure ADに接続されていない場合:
  - 個人のMicrosoftアカウントのメールアドレス
  - GitHubユーザー名

```
Azure Active Directory (Azure AD)を使用してユーザーを認証し、組織のアクセスを制御する予定がない場合は、GitHub アカウントの個人用 Microsoft アカウントと id の電子メールアドレスを追加します。 ユーザーが Microsoft または GitHub のアカウントを持っていない場合は、 Microsoft アカウント または github アカウントにサインアップするようにユーザーに依頼します。
```

■具体的な追加の流れ
- [→メンバーの追加（招待）](pdf/メンバーの追加（招待）.pdf)
  - 組織にメンバーを追加する方法

参考
- [チームメンバーの招待](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops#invite-team-members)
- [Azure DevOpsにおけるユーザーの管理](https://docs.microsoft.com/ja-jp/azure/devops/organizations/accounts/add-organization-users?view=azure-devops&tabs=preview-page)

## Azure DevOps が利用できる地域

「組織」を作成するときに、そのデータを保存する「地域」を指定する。

Azure DevOps は次の「地域」で利用できる。


- Australia
  - Australia East
- Brazil
  - Brazil South
- Canada
  - Canada Central
- Asia Pacific
  - East Asia(香港)
  - Southeast Asia(シンガポール)
- Europe
  - West Europe
- India
  - South India
- United Kingdom
  - UK South
- United States
  - Central US

※2021/12現在、Japan（日本）は選択肢にない。データを国内に置く必要がある場合は[→Azure DevOps Server](mod01-03-devops-server.md)を使用。


■地域の指定

組織の作成時に、地域を指定する。

地域の変更は画面上からはできないが、以下の画面から問い合わせを行って変更することができる。

https://azure.microsoft.com/ja-jp/support/devops/


## ラボ（ハンズオン演習）

- [Azure DevOpsの使用を開始する](pdf/Azure%20DevOpsの使用を開始する.pdf)
  - 組織とプロジェクトを作成する


## Azure Board

- [Azure Boards.pdf](pdf/Azure%20Boards.pdf)
  - Azure Boardsの解説

### エピックとエリアの使い分けは？

エピックは、達成すべき目標。イシューをまとめたもの。エリアは、エピック、イシュー、タスクを分類するためのもの。エピックは達成したら状態をDoneにできるが、エリアには状態はない。

- エピック:「ベーシック」のプロセスにおける最上位の作業項目
  - イシューやタスクと同様、担当者、状態（To-do, Doing, Done）、スプリント、エリアを設定できる
  - かんばんボード、バックログ、タスクボードで表示・操作できる
  - 「おすすめ商品機能の実装」といった、何らかの機能の実装作業などを表現
  - 複数のエピックを作ることができる
- エリア: 作業項目を分野別に整理する機能
  - プロジェクト単位で定義する
  - エリアパスで表現される
  - 階層構造で定義できる
  - 「UI」「DB」などのように、作業項目を分野で分類するために使う
  - 「チーム」と関連付けることができる。特定のチームが、特定のエリアの作業項目だけを表示して作業することができる。

- 階層構造:
  - 作業項目の階層構造はプロセスによって決まる。「ベーシック」プロセスの場合は「エピック」「イシュー」「タスク」の3種類であり、それ以外には作れない。
  - エリアは、プロセスによらず、プロジェクトで好きな観点・好きな深さで定義できる。

- エリアによる作業項目の分類:
  - エピックにエリアを設定できる。
  - エピックが複数のイシューをもつ場合、それぞれのイシューに異なるエリアを設定できる。
  - 同様に、イシューが複数のタスクを保つ場合、それぞれのタスクに異なるエリアを設定できる。

エピックもエリアもオプションである（必ずしも使わなくてもよい）。

## ラボ（ハンズオン）

- 基本編: Microsoft Learn: [ソフトウェア開発にアジャイル アプローチを選ぶ](https://docs.microsoft.com/ja-jp/learn/modules/choose-an-agile-approach/) のユニット3～4に沿って、Azure Boardを使ってみましょう。
  - Azure Board
    - プロジェクトの作成
    - チームの作成
    - チームメンバーの追加
    - 作業項目の追加
    - スプリントの定義
    - 作業項目の所有者（Owner）の設定
  - ユニット4が終わったら、プロジェクトや、組織に追加したユーザーは削除します。

- 応用編(英語のみ、オプション): Azure DevOps Labs: [Agile Planning and Portfolio Management with Azure Boards](https://azuredevopslabs.com//labs/azuredevops/agile/)
  - Edgeブラウザの翻訳機能でページの翻訳ができます。
  - または、[Google翻訳](https://translate.google.co.jp/?hl=ja&sl=auto&tl=en&op=translate)や[Bing翻訳](https://www.bing.com/translator?to=ja&setlang=ja)の左側のテキストボックスにアクセス先のサイトのURLを貼り付けると、翻訳されたページが表示されます。
  - Azure Board
    - エリア
    - ダッシュボード
    - Epicの作成
    - キャパシティ
    - Boardのカスタマイズ
    - ダッシュボードの作成
    - プロセスのカスタマイズ

# AI-3018 コパイロットの基礎

https://learn.microsoft.com/ja-jp/training/paths/copilot-foundations/

1日コース

生成 AI の基礎、Microsoft Copilot、Microsoft Copilot Studio、Azure AI Foundryについて学習します。


## 講義

- 講師自己紹介
- [開始時のご案内](../opening.md)
- [講義資料](AI-3018.pdf)
  - モジュール1 生成 AI の基礎
  - モジュール2 Microsoft Copilot Foundry の概要
  - モジュール3 Azure AI Foundry の概要
  - モジュール4 Azure AI Foundry で独自のデータを使用して RAG ベースのエージェントを構築する
- [認定試験について](exam.md)
- [終了時のご案内](../closing-cloudslice.md)
- （オプション）ラボ

## ラボ

- ラボはご受講後半年後まで利用できます。
- 「トレーニングキー」は講師よりチャットでご案内いたします。期限期限が本日中（講義の日）となっているため、お早めにご入力ください。
- [ラボの利用方法のご案内](../ラボ環境の利用方法.pdf)
- ラボ1 Microsoft Copilot を使ってみる
  - 文章の要約や生成などを試します
  - 生成したテキストをWord、Outlookなどに貼り付けて利用できます
  - Web版の無料のMicrosoft Copilot （https://copilot.microsoft.com/ ）を使用します
  - Microsoftアカウントが必要です
- ラボ2 Microsoft Copilot Studio でエージェントを作成
  - Microsoft Copilot Studioでエージェントを作成します
  - 経費精算に関する質問に回答できるようにトピックを作成します
  - 宿泊に関する社内規定に回答できるようにファイルを追加します
  - 2025/3/23 現在、トピックの追加画面が表示されない現象が確認されています。
- ラボ3 Azure AI FoundryでRAGを実装する
  - Azure AI Foundryで「Azure OpenAI on your data」を設定します
  - 複数のPDFファイルをアップロードし、ベクトルインデックスを作成します
  - チャットプレイグラウンドで「Azure OpenAI on your data」の動作を確認します


## ラボ3のハブ・スポークの作成

```
「リソース」タブのユーザー名を確認
例: User1-50354971@LODSPRODMCA.onmicrosoft.com

「User1-」から「@」までの間の数値を使用（起動するたびに変わる）

ハブ名: Hub50354971 ←Hub + 数値 とする

プロジェクト名: Project50354971 ←Project + 数値 とする

リソースグループ: ResourceGroup1 （作成済み）を選択

場所: canadaeast

AI Search の作成: aisearch9287501945 など（aisearch に 適当な数字を付加）
```


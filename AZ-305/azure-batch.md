# Azure Batch

バッチ処理（大規模な並列処理、ハイパフォーマンス・コンピューティング）を実装するためのサービス。

> 簡単に言えば任意の.exeアプリを複数台のVMにバラまいて並列実行できる仕組み

https://twitter.com/nakama00/status/1170892918099329024

公式サイト
https://azure.microsoft.com/ja-jp/services/batch/

価格
https://azure.microsoft.com/ja-jp/pricing/details/batch/cloud-services/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/batch/batch-technical-overview

解説動画 - Azure Batch による分散計算処理サンプルアプリケーション
https://www.youtube.com/watch?v=Z8d4zq8Skh4

## Azure Batchとは？

- 数十、数百、数千個のコンピューティング ノード (仮想マシン) からなるプールを作成・管理
- 大規模な並列処理を実行
  - 1台のコンピュータだけで実行したら数十時間～数十日かかるといった大量の処理を、Azure Batchを使用して、数十分～数時間で終わらせることができる
- [1台の「ノード」は1時間あたり 1.2円 ～ 数百円 で使用できる](https://azure.microsoft.com/ja-jp/pricing/details/batch/)
- 多数の画像の処理、レンダリング
    - Autodesk Maya、3ds Max、Arnold、V-Ray などのレンダリング ツールでの大規模なレンダリング ワークロードをサポート
    - [Blender](https://blender.jp/)
      - [参考ブログ記事1](https://itosue.github.io/azure-blender/)
      - [参考ブログ記事2](https://www.maemaewater.net/)
- メディアの変換、エンコーディング
- シミュレーション
- 遺伝子解析
- ソフトウェアのテスト
- [モンテカルロ シミュレーション](https://www.ibm.com/jp-ja/cloud/learn/monte-carlo-simulation)
- ノード（VM）として、Windowsノード / Linux ノードを使用できる
- タスクは最大で180日間継続できる（[タスクの最長有効期限=180日](https://docs.microsoft.com/ja-jp/azure/batch/batch-quota-limit)）
  - 参考: Azure Functionsの「従量課金プラン」でのタイムアウトは、[デフォルト5分、最大10分。](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-scale#timeout)

## 歴史

- 2014/10/28 パブリックプレビュー https://azure.microsoft.com/en-us/updates/public-preview-azure-batch/
- 2015/7/9 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-batch-generally-available/
- 2017/8/1 Azure Batch Rendering パブリックプレビュー https://azure.microsoft.com/ja-jp/blog/announcing-public-preview-of-azure-batch-rendering/
- 2017/10/12 Azure Batch AI パブリックプレビュー https://azure.microsoft.com/ja-jp/updates/public-preview-azure-batch-ai/
- 2021/8/30 Azure Batchの「新しい機能」 https://azure.microsoft.com/ja-jp/updates/azure-batch-updates-august2021/
  - プール マネージドID
  - プール仮想マシン拡張機能
  - プール可用性ゾーン
  - など

## 基本的な使い方

https://docs.microsoft.com/ja-jp/azure/batch/quick-create-cli

Batchアカウント: プール、ジョブを作成するために必要。

リンクされているストレージアカウント: 入力データ・出力データを格納。

```
Batchアカウント ... az batch account create --name --storage-account
└リンクされているストレージ アカウント
```

Batchアカウントを作成したら、`az batch account login` で、Batchアカウントにログインする。

続いて、Batchアカウントに `az batch pool create` でプールを作成する。

プール内には複数のノードが作られる。ノードのサイズと台数を指定できる。

```
Batchアカウント
└プール ... az batch pool create --vm-size --target-dedicated-nodes
  └ノード: VM
```

プールの準備が整ったらジョブを作成する。ジョブは、`--pool-id` で指定したプールで実行される。

ジョブは複数のタスクから構成される。`--command-line` オプションで、アプリやスクリプトを指定する。

```
ジョブ ... az batch job create --id --pool-id
└タスク ... az batch task create --job-id --task-id --command-line
```

タスクは、Azure Batchにより、プール内のノードに配布される。

```
ジョブ（タスク1,2,3）
↓
Batchアカウント
│└リンクされているストレージ アカウント
│   └Blobコンテナー / Blob
└プール                 ↑
  ├ノード1 - ジョブ1/タスク1
  ├ノード2 - ジョブ1/タスク2
  └ノード3 - ジョブ1/タスク3
```

各タスクの実行結果は、リンクされているストレージアカウントのBlobとして出力される。

`az batch task file download` を使用して、各タスクの実行結果をダウンロードすることができる。

## Batch Explorer

https://azure.github.io/BatchExplorer/

バッチアプリケーションをデバッグ・監視することができるGUIアプリケーション。Windows / Mac / Linux をサポート。

## 参考: Azure Batchではない、いわゆる「バッチ処理」の実装は？

[バッチ処理](https://www.otsuka-shokai.co.jp/words/batch-processing.html)

> あらかじめ登録した一連の処理を自動的に実行する処理方式

月末などに一括でデータを処理する「バッチ処理」をAzureで実装したい場合:

- キュー(ストレージアカウントのQueue Storage等)にメッセージ（処理の指示）をためておき、月末などにVMを起動して、キューにたまったメッセージを一括処理する
- [Azure Automationのスケジュール](https://docs.microsoft.com/ja-jp/azure/automation/shared-resources/schedules)を使用する
- [Azure Logic Appsのスケジュールトリガー](https://docs.microsoft.com/ja-jp/azure/logic-apps/concepts-schedule-automated-recurring-tasks-workflows)を使用する
- [Azure Functionのタイマートリガー](https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-bindings-timer?tabs=csharp)を使用する

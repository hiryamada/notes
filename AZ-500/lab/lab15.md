# ラボ9 後半（Microsoft Sentinel）

想定時間: 30min

Microsoft Sentinel （SIEM/SOARソリューション）について学びます。

- SIEM (Security Information and Event Management, [シーム](https://searchsecurity.techtarget.com/answer/SOAR-vs-SIEM-Whats-the-difference)):セキュリティ情報・イベントの管理
- SOAR (Security Orchestration, Automation, and Response, [ソーア](https://www.siemplify.co/resources/what-is-soar-security-orchestration-automation/)):セキュリティ情報の自動収集、自動対応

（まだ準備していない場合）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies/archive/master.zip)をダウンロードして展開しておきましょう。


## ラボの重要ポイント

- タスク1
  - Log AnalyticsワークスペースにAzure Sentinelを「追加」します。
- タスク2
  - 「Azure アクティビティ データ コネクタ」を使用するように設定します。
- タスク3
  - Azure アクティビティ データ コネクタを使用するルールを作成します
- タスク4
  - プレイブックを作成します。

<!--

## 補足事項

タスク1-3 「Azure Sentinel」 ブレードで、「ワークスペースの接続」 をクリックします。→ 画面上部の「＋追加」または画面中部の「Azure Sentinelの作成」をクリックします。

タスク2-2 はじめに「名前またはプロバイダーで検索」テキストボックスに「azure」と入力すると、検索結果の最終行に「Azure アクティビティ」が見つかります。

タスク2-4 「接続」してから、実際に「Azure アクティビティ」データコネクタが「接続済み」になる（「接続済み」が0から1になる）まで、15分程度かかる場合があります。ここは、特に待つ必要はありません。

タスク3-2 「ルールテンプレート」→「規則のテンプレート」


タスク3-3 「suspicious number」で検索し、「Suspicious number of resource creation or deployment activities」をクリックし、「ルールの作成」をクリックします。

タスク3-4 ～ タスク3-8 「全般」「ルールのロジックを設定」「Incident settings(プレビュー)」「自動応答」「確認と作成」まで、全てデフォルトの設定で「次へ」を押していき、最後に「作成」を押します。

タスク4-1 画面上部の検索ボックスで「カスタム テンプレートのデプロイ」を検索します。

タスク4-2 「エディターで独自のテンプレートを作成する」をクリックします。

タスク4-5 場所→リージョンで「米国東部」が選択されています。変更する必要はありません。

タスク4-6 「確認と作成」をクリックし、「作成」をクリックします。

タスク4-7 「インシデントの重大度の変更」 ブレード→「Change-Incident-Severity」ブレード

タスク4-13 サインインが完了すると、ロジックアプリのステップ内に「live.com#abc@outlook.jp に接続しました。」といった文字列が表示され、黄色い三角形の警告アイコンが消えます。

タスク4-14 のこりの3つの「接続」ステップでは、最初の「接続」ステップでサインインしたアカウントをクリックするだけでOKです。

タスク5-4 戦術 初回アクセス → 方針で「Initial Access」を選択

タスク5-7 「クエリを実行する間隔」→「クエリの実行間隔」

タスク5-8 「インシデントの設定」→ 「次: Incident settings(プレビュー)」

タスク5-10 「インシデントの重要度の変更」 チェックボックスを選択し、「次へ」 をクリックします。レビュー >。
→ 「アラートの自動化」で、「0項目が選択されました」をクリックして、プルダウンメニューから「Change-Incident-Severity」にチェックを入れます。「次: レビュー >」をクリックします。

タスク6-1
画面上部の検索テキストボックスで「セキュリティ センター」と入力して「セキュリティ センター」に移動します。

タスク6-2 「「Security Center」| 「Just In Time VM アクセス」 ブレードで 、」 → Azure Defenderをクリックし、「Just-In-Time VMアクセス」をクリックします。

「省略」 ボタンをクリック → 行の右側の「...」をクリックします。

タスク6-5 「Delete JIT Network Access Policies」というアクティビティ ログが記録されます。表示されない場合は、1分ほど待って「最新の情報に更新」ボタンをクリックすることを繰り返します。

また「メモします」とありますが、特にメモする必要はありません。

タスク6-7
「Azure Sentinel | 概要」ページで、「インシデント」が0から1になっていることを確認します。
表示されない場合は、5分ほど待って「最新の情報に更新」ボタンをクリックすることを繰り返します。
-->

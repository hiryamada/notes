# モジュール17 開発チーム向けのフィードバックの実装

開発チームがフィードバックを受信して活用する方法。

- 内部ループとは。
- Log Analytics
- Application Insights
- App Center
  - App Center Diagnostics
- Azure Monitor
  - ビュー デザイナー
  - ブック

## システムの使用状況、機能の使用状況、およびフローを追跡するツールを実装する

### 内部ループ

- 内部ループとは、コード・ビルド・テストの繰り返しである。
- コードを書く部分は顧客に対する価値を生み出す部分。その他の部分は価値を生み出すものではないため、できる限り無駄を省くべきである。
- 無駄を省くには、差分ビルド（変更された部分だけをビルドする）、ビルド結果をキャッシュして再利用する、などの技術を用いることができる。

※このページでは「フィードバックはビルドとテストで収集する」とあるが、実際には運用環境からのフィードバックも活用できる。

### 継続的監視の紹介

さまざまなモニタリング方法の紹介。量が多いので、本文をご確認ください。

※Status Monitorはすでにサポート廃止。

### Azure Log Analytics / Kusto クエリ言語 (KQL) のチュートリアル

[PDF: Log Analyticsまとめ](../AZ-104/pdf/mod11/Log%20Analytics.pdf)


[KQL クイック リファレンス](https://docs.microsoft.com/ja-jp/azure/data-explorer/kql-quick-reference)

[SQL から Kusto のチート シート](https://docs.microsoft.com/ja-jp/azure/data-explorer/kusto/query/sqlcheatsheet)

### Application Insights

[PDF: Application Insightsまとめ](../az-204/pdf/mod12/Application%20Insightsの主な機能.pdf)

### Application Insights の使用方法

デモンストレーション: Application Insights を ASP.NET Core アプリケーションに追加する

## モバイル アプリケーション クラッシュ レポート データのルーティングを実装する

### App Center Diagnostics

■App Center

App Centerは、Android/iOS/macOS/React Native/Windows(UWP)/Xamarinなどのプラットフォームにおけるビルド、テスト、配布、分析、**クラッシュデータ診断**、プッシュ通知を行うサービス。

https://docs.microsoft.com/ja-jp/appcenter/

- パッケージのビルド
- 実機でのテスト
- 配布（ストアへの登録）
- 利用状況の分析
- **診断（クラッシュデータの収集）**
- プッシュ（ユーザーへのプッシュ通知の送信）

■App Center Diagnostics

アプリのクラッシュとエラーに関する情報を収集する機能。

https://docs.microsoft.com/ja-jp/appcenter/diagnostics/


### アラートの構成

（略）

### バグ トラッカーの作成

アプリがクラッシュした際に、その情報をGitHub Issueなどを自動的に登録できる。

以下の「バグトラッカー」と連携。

- App Center
- Jira Cloud
- Azure DevOps (以前の VSTS)
- GitHub 
- Visual Studio Team Services

https://www.slideshare.net/shinyanakajima37/visual-studio-app-centergithubissue

## モニタリングとステータス ダッシュボードの開発

### Azure ダッシュボード

ダッシュボードのデモを実施。Azure Monitorメトリックのグラフをダッシュボードに追加することができる。

### Azure Monitor のビュー デザイナー

[Azure Monitor のビュー デザイナーを使用してカスタム ビューを作成する](https://docs.microsoft.com/ja-jp/azure/azure-monitor/visualize/view-designer)

Azure Monitor のビュー デザイナーを使用すると、Log Analytics ワークスペースでデータを視覚化するのに役立つさまざまなカスタム ビューを Azure portal で作成できます。

### Azure Monitor ブック

ビュー デザイナーは Azure Monitor の機能で、Log Analytics ワークスペース内のデータを、グラフ、リスト、タイムラインを使用して視覚化するのに役立つカスタム ビューを作成できます。 **これらはブックに移行されており**、Azure portal 内でデータを分析し、高度な視覚的レポートを作成するための柔軟なキャンバスを提供します。 この記事は、ビュー デザイナーからブックへの移行を行う際に役立ちます。

[ブックを使用することの、ビュー デザイナーに勝る利点](https://docs.microsoft.com/ja-jp/azure/azure-monitor/visualize/view-designer-conversion-overview#advantages-of-using-workbooks-over-view-designer)

- ログとメトリックの両方がサポートされます。
- 個別のアクセス制御ビューと共有ブック ビューの両方の個人用ビューを使用できます。
- タブ、サイズ変更、およびスケール コントロールを持つカスタム レイアウト オプション。
- 複数の Log Analytics ワークスペース、Application Insights アプリケーション、サブスクリプションに対する横断的なクエリ実行のサポート。
- 関連付けられたグラフや視覚化を動的に更新するカスタム パラメーターが有効になります。
- パブリック GitHub のテンプレート ギャラリーのサポート。

### Power BI

（本文参照）

### Grafana

グラファナ: オープンソースのダッシュボード開発ソフトウェア。

[Grafana Azure Monitorプラグイン](https://grafana.com/grafana/plugins/grafana-azure-monitor-datasource/)を使用して、GrafanaにAzure Monitorのデータを取り込み、可視化することができる。

### 独自のカスタム アプリケーションをビルド

Azure Monitor のログとメトリックはAPIを使用して取得できるので、それらを取得して活用する独自のアプリケーションを開発することができる。

## 発券システムの統合と構成

[IT Service Management Connector](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/itsmc-overview)

Azure を、サポートされている IT Service Management (ITSM) 製品またはサービスに接続できます。


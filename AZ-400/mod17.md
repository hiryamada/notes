# 開発チーム向けのフィードバックの実装

情報を集めて活用する方法。

- Log Analytics
- Application Insights
- App Center
  - App Center Diagnostics
- Azure Monitor
  - ビュー デザイナー
  - ブック

## システムの使用状況、機能の使用状況、およびフローを追跡するツールを実装する

### Azure Log Analytics

[PDF: Log Analyticsまとめ](../AZ-104/pdf/mod11/Log%20Analytics.pdf)

[KQL クイック リファレンス](https://docs.microsoft.com/ja-jp/azure/data-explorer/kql-quick-reference)

[SQL から Kusto のチート シート](https://docs.microsoft.com/ja-jp/azure/data-explorer/kusto/query/sqlcheatsheet)

### Application Insights

[PDF: Application Insightsまとめ](../AZ-204/pdf/mod12/Application%20Insightsの主な機能.pdf)


## モバイル アプリケーション クラッシュ レポート データのルーティングを実装する

### App Center Diagnostics

■App Center

App Centerは、Android/iOS/macOS/React Native/Windows(UWP)/Xamarinなどのプラットフォームにおけるビルド、テスト、配布、分析、**クラッシュデータ診断**、プッシュ通知を行うサービス。

https://docs.microsoft.com/ja-jp/appcenter/

- パッケージのビルド
- 400を超える実機デバイスでのテスト
- 配布（App Center / Google Play等のストアへの登録）
- 利用状況の分析
- **診断（クラッシュデータの収集）**
- プッシュ（ユーザーへのプッシュ通知の送信）

■App Center Diagnostics

アプリのクラッシュとエラーに関する情報を収集する機能。

https://docs.microsoft.com/ja-jp/appcenter/diagnostics/

### バグ トラッカーの作成

App Centerでは、アプリがクラッシュした際に、その情報をGitHub Issueなどの「バグトラッカー」に自動的に登録できる。

以下の「バグトラッカー」と連携。

- Jira Cloud
- Azure DevOps
- GitHub

https://www.slideshare.net/shinyanakajima37/visual-studio-app-centergithubissue

## モニタリングとステータス ダッシュボードの開発

### Azure ダッシュボード

Azure Monitorメトリックのグラフをダッシュボードに追加することができる。

### Azure Monitor のビュー デザイナー

[Azure Monitor のビュー デザイナーを使用してカスタム ビューを作成する](https://docs.microsoft.com/ja-jp/azure/azure-monitor/visualize/view-designer)

Azure Monitor のビュー デザイナーを使用すると、Log Analytics ワークスペースでデータを視覚化するのに役立つさまざまなカスタム ビューを Azure portal で作成できる。

### Azure Monitor ブック

ビュー デザイナーは Azure Monitor の機能で、Log Analytics ワークスペース内のデータを、グラフ、リスト、タイムラインを使用して視覚化するのに役立つカスタム ビューを作成できる。

**これらはブックに移行されており**、Azure portal 内でデータを分析し、高度な視覚的レポートを作成するための柔軟なキャンバスを提供します。 この記事は、ビュー デザイナーからブックへの移行を行う際に役立つ。

[ブックを使用することの、ビュー デザイナーに勝る利点](https://docs.microsoft.com/ja-jp/azure/azure-monitor/visualize/view-designer-conversion-overview#advantages-of-using-workbooks-over-view-designer)

- ログとメトリックの両方がサポートされます。
- 個別のアクセス制御ビューと共有ブック ビューの両方の個人用ビューを使用できます。
- タブ、サイズ変更、およびスケール コントロールを持つカスタム レイアウト オプション。
- 複数の Log Analytics ワークスペース、Application Insights アプリケーション、サブスクリプションに対する横断的なクエリ実行のサポート。
- 関連付けられたグラフや視覚化を動的に更新するカスタム パラメーターが有効になります。
- パブリック GitHub のテンプレート ギャラリーのサポート。

### Grafana

グラファナ: オープンソースのダッシュボード開発ソフトウェア。

[Grafana Azure Monitorプラグイン](https://grafana.com/grafana/plugins/grafana-azure-monitor-datasource/)を使用して、GrafanaにAzure Monitorのデータを取り込み、可視化することができる。

### 独自のカスタム アプリケーションをビルド

Azure Monitor のログとメトリックはAPIを使用して取得できるので、それらを取得して活用する独自のアプリケーションを開発することができる。

## 発券システムの統合と構成

[IT Service Management Connector](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/itsmc-overview)

Azure を、サポートされている IT Service Management (ITSM) 製品またはサービスに接続できる。

- [ServiceNow](https://www.servicenow.co.jp/)
- [System Center Service Manager](https://news.mynavi.jp/techplus/article/systemcenter-11/)
- [Provance](https://www.provance.com/) ※2020 年 10 月 1 日以降はサポートされない
- [Cherwell](https://www.cherwell.com/) ※2020 年 10 月 1 日以降はサポートされない
  - 読み方: [チャーウェル](https://www.ivanti.co.jp/company/history/cherwell)
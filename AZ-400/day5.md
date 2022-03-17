# ラーニングパスとモジュールの概要

- 5日目
  - ラーニングパス9: フィードバック、分析
  - ラーニングパス10: ライセンス、セキュリティ

# 講義とハンズオン

- 午前: 講義
  - 3日目補足: [サードパーティIaCツールの解説](mod14.md)
  - [継続的フィードバック](mod17.md)
  - [サイト信頼性エンジニアリング(SRE)](mod18-01-sre.md)
  - [非難のない文化](mod18-02-blameless-retrospective.md)
  - [DevOps プロジェクトでのセキュリティの実装](mod19.md)
  - [ライセンス](mod20-01-license.md)
  - [コードスキャン](mod20-02-security-scan.md)
- 午後: ハンズオン
  - ハンズオン: [SonarCloudによるコード解析](mod20-handson-sonarcloud.md)
  - ハンズオン: [WhiteSource Bolt による脆弱性レポート](mod19-handson-whitesource.md)


# [ラーニング パス9: 継続的フィードバックを実装する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-implement-continuous-feedback/)


## [モジュール1: 使用状況とフローを追跡するためのツールを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-tools-track-usage-flow/)

- Azure Monitor
  - メトリック: 数値データ
  - ログ: JSONのデータ（数値・日付・時刻・テキスト等を含む）
- Log Analytics
  - [Kusto Query Language（KQL）](https://docs.microsoft.com/ja-jp/azure/data-explorer/kusto/query/tutorial?pivots=azuredataexplorer)
  - KQLを使用して、ログの検索・分析を行う
- Application Insights
  - [インストルメンテーションキー](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/create-new-resource#copy-the-instrumentation-key)
    - Application Insightsのリソースごとに発行されるキー
    - アプリケーション側にこのキーを設定する必要がある
    - ※知識チェックでは「AppInsights キー」が正解となっているが
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-tools-track-usage-flow/9-knowledge-check)

## [モジュール2: モバイル アプリケーションのクラッシュ レポート データのルートを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-route-mobile-application-crash-report-data/)

- [App Center](https://appcenter.ms/)
  - [App Centerでサポートされているバグトラッカー](https://docs.microsoft.com/ja-jp/appcenter/dashboard/bugtracker/)
    - Azure DevOps、Jira、GitHub など
    - BitBucketはサポートされていない
  - [App Center診断(diagnostics)](https://docs.microsoft.com/ja-jp/appcenter/diagnostics/)
    - [クラッシュ](https://docs.microsoft.com/ja-jp/appcenter/diagnostics/#crashes)
    - [エラー](https://docs.microsoft.com/ja-jp/appcenter/diagnostics/#errors)
    - [デフォルトで「1 日あたりのアプリのクラッシュとエラー」が表示される](https://docs.microsoft.com/ja-jp/appcenter/diagnostics/features)
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-route-mobile-application-crash-report-data/5-knowledge-check)

## [モジュール3: 監視ダッシュボードと状態ダッシュボードを開発する](https://docs.microsoft.com/ja-jp/learn/modules/develop-monitor-status-dashboards/)

- 「[ダッシュボード](https://docs.microsoft.com/ja-jp/azure/azure-portal/azure-portal-dashboards)」による視覚化
  - 全画面表示モードがある
  - [タイムスタンプとカスタム パラメーターでパラメーター化されたメトリック ダッシュボード](https://docs.microsoft.com/ja-jp/azure/azure-portal/azure-portal-dashboards#modify-tile-settings)
  - [ビューデザイナー](https://docs.microsoft.com/ja-jp/learn/modules/develop-monitor-status-dashboards/3-examine-view-designer-azure-monitor)
    - ログ データを使用して「カスタム視覚化」（グラフ化など）できる
  - ダッシュボードの制限
    - ログのグラフは、共有ダッシュボードにのみピン留めできる。
- その他のログの視覚化方法
  - [Grafana](https://docs.microsoft.com/ja-jp/azure/azure-monitor/visualize/grafana-plugin)
  - 「を公開します」→[Power BI](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/export-power-bi)
  - ※Excelによる可視化はサポートされていない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/develop-monitor-status-dashboards/8-knowledge-check)

## [モジュール4: チーム内でナレッジを共有する](https://docs.microsoft.com/ja-jp/learn/modules/share-knowledge-within-teams/)

- [Wikiページ](https://docs.microsoft.com/ja-jp/azure/devops/project/wiki/wiki-create-repo?view=azure-devops&tabs=browser)
  - [Wiki ページを追加または編集するためのアクセス権](https://docs.microsoft.com/ja-jp/azure/devops/project/wiki/wiki-create-repo?view=azure-devops&tabs=browser#prerequisites)
    - 共同作成者: ページの追加・編集
    - 利害関係者（ステークホルダー）: 表示
- [作業項目の統合](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/work-item-integration)
  - Application Insightsの機能
  - 関連する Application Insights データが埋め込まれている作業項目を GitHub または Azure DevOps で簡単に作成
- [IT Service Management Connector (ITSMC)](https://docs.microsoft.com/ja-jp/azure/azure-monitor/alerts/itsmc-overview)
  - Azure Monitorの機能
  - Azure を、サポートされている IT Service Management (ITSM) 製品またはサービスに接続できる
    - ServiceNow
    - System Center Service Manager
    - Provance ※2020 年 10 月 1 日以降はサポートされない
    - Cherwell ※2020 年 10 月 1 日以降はサポートされない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/share-knowledge-within-teams/6-knowledge-check)

## [モジュール5: SRE について調べて、エンド ユーザーの満足度を測定するための活動を設計する](https://docs.microsoft.com/ja-jp/learn/modules/explore-sre-design-practices-measure-end-user-satisfaction/)

- サイト信頼性エンジニア
  - 「新しい機能の開発と運用システムのスムーズな実行」を担当
  - 一般的な役割
    - 予防的にアプリケーションのパフォーマンスの監視と確認を行う。
    - ソフトウェアのログ記録と診断が適切であることを確認する。
    - ※知識チェックの2問目では「次の選択肢のうち、サイト信頼性エンジニアの一般的な役割はどれですか?」となっているが、「次の選択肢のうち、サイト信頼性エンジニアの一般的な役割 **でないもの** はどれですか?」と読み替える。
- 製品に対するエンド ユーザーの満足度を追跡するメトリック
  - CSAT
  - NPS
  - ※STARは満足度メトリックではない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-sre-design-practices-measure-end-user-satisfaction/6-knowledge-check)

## [モジュール6: ユーザー フィードバックを収集して分析するプロセスを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-capture-analyze-user-feedback/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-capture-analyze-user-feedback/4-knowledge-check)

## [モジュール7: アプリケーション分析を自動化するプロセスを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-automate-application-analytics/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-automate-application-analytics/5-knowledge-check)

## [モジュール8: アラート、ブレイムレス レトロスペクティブ (誰も責めることのないふりかえり)、およびジャ スト カルチャを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-alerts-blameless-retrospectives-just-culture/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-alerts-blameless-retrospectives-just-culture/10-knowledge-check)


# [ラーニング パス10: コンプライアンスのためにセキュリティを実装し、コード ベースを検証する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-implement-security-validate-code-bases-compliance/)

## [モジュール1: パイプラインのセキュリティについて](https://docs.microsoft.com/ja-jp/learn/modules/understand-security-pipeline/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/understand-security-pipeline/12-knowledge-check)

## [モジュール2: Azure Security Center 入門](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-security-center/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-security-center/10-knowledge-check)

## [モジュール3: オープンソース ソフトウェアを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-open-source-software/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-open-source-software/8-knowledge-check)

## [モジュール4: マルウェア対策とスパム対策のポリシーを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-anti-malware-spam-policies/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-anti-malware-spam-policies/4-knowledge-check)

## [モジュール5: ライセンス スキャンと脆弱性スキャンの統合](https://docs.microsoft.com/ja-jp/learn/modules/integrate-license-vulnerability-scans/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/integrate-license-vulnerability-scans/10-knowledge-check)

## [モジュール6: 技術的負債を特定する](https://docs.microsoft.com/ja-jp/learn/modules/identify-technical-debt/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/identify-technical-debt/8-knowledge-check)


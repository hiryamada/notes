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
  - ※「STAR」は満足度メトリックではない。
  - ※「STAR」とは・・・ 不明
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-sre-design-practices-measure-end-user-satisfaction/6-knowledge-check)

## [モジュール6: ユーザー フィードバックを収集して分析するプロセスを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-capture-analyze-user-feedback/)

- お客様に対する顧客の考えが理解しやすい
- リリースゲートの種類
  - Invoke Azure function(Azure 関数を呼び出す)
  - Query Azure monitor alerts(Azure Monitor アラートのクエリ)
  - Invoke REST API(REST API を呼び出す)
  - Query Work items(作業項目のクエリ)
  - コンプライアンスの評価。
  - Twitter sentiment release gate
    - Azure DevOps、Azure Functions、Microsoft AI（Cognitive Servicesのテキスト分析）を組み合わせて実装できる
  - ※「PowerShellの呼び出し」はない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-capture-analyze-user-feedback/4-knowledge-check)

## [モジュール7: アプリケーション分析を自動化するプロセスを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-automate-application-analytics/)

- 「拡張検索」の分析アルゴリズム
  - エラー、リスク要因、および問題インジケーターが自動的に特定される
  - ・・・とあるが、元ネタがおそらく [こちらの記事](https://www.devopsdigest.com/automated-log-analytics-for-devops-troubleshooting-at-the-speed-of-agile-development) で、Azure あるいは DevOpsにはあまり関係がなく、一般的なIT知識でもないように思わえる
  - 暗記する必要はないように思われる
- テレメトリ
  - フィードバックを自動化するうえでの重要な要素となる
  - 「ログ」との違い:
    - 「ログ」: エラーやコード フローを診断するために使用
    - 「テレメトリ」: ユーザーがアプリをどのように利用しているかという情報を収集
      - ユーザーがテレメトリ収集をOFFにする場合がある
- 監視ツールの選択
  - 統合監視、アラート管理、デプロイの自動化、分析などの機能があることが重要
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-processes-automate-application-analytics/5-knowledge-check)

## [モジュール8: アラート、ブレイムレス レトロスペクティブ (誰も責めることのないふりかえり)、およびジャ スト カルチャを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-alerts-blameless-retrospectives-just-culture/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-alerts-blameless-retrospectives-just-culture/10-knowledge-check)


# [ラーニング パス10: コンプライアンスのためにセキュリティを実装し、コード ベースを検証する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-implement-security-validate-code-bases-compliance/)

## [モジュール1: パイプラインのセキュリティについて](https://docs.microsoft.com/ja-jp/learn/modules/understand-security-pipeline/)

- Rugged DevOps
  - DevOpsとセキュリティを結合した考え方（DevSecOpsと同じ）
  - 特に、（ビルド・リリース等の）パイプラインをセキュリティで保護することを指す
- ソフトウェア コンポジション分析
  - オープンソース ソフトウェア (OSS) を分析して潜在的なセキュリティの脆弱性を特定し、ソフトウェアがパイプラインで使用するために定義された基準を満たしていることを検証すること
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/understand-security-pipeline/12-knowledge-check)

## [モジュール2: Azure Security Center 入門](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-security-center/)

※Azure Security Centerは、現在「Microsoft Defender for Cloud」と呼ばれている

- Azure Security Center（Microsoft Defender for Cloud）
  - Azure とオンプレミスのすべてのサービスに対して脅威からの保護を提供する監視サービス
- Azure Policy
  - ポリシーの作成と割り当てができる
  - ポリシーに違反するリソースを検出できる
    - 組織内の暗号化されていないすべての SQL データベースを検出するなど。
- （リソースの）ロック
  - リソースを「読み取り専用（削除・変更が不可能）」や「削除禁止（削除は不可能だが変更は可能）」に設定できる機能
  - うっかり削除してはまずいような重要なリソースにロックを設定する
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-azure-security-center/10-knowledge-check)

## [モジュール3: オープンソース ソフトウェアを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-open-source-software/)

- オープンソース ソフトウェアとは
  - コード ユーザーがソフトウェアをレビュー、変更、配布できるソフトウェア
- オープンソース ライブラリの問題点
  - バグ
  - セキュリティ脆弱性
  - ライセンスの問題
- コピーレフト ライセンス
  - コピーレフト ライセンスのソースコードを使用したソフトウェアはコピーレフト ライセンスにしなければならないため「バイラル（拡散する、感染する）」であるとみなされる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-open-source-software/8-knowledge-check)

## [モジュール4: マルウェア対策とスパム対策のポリシーを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-anti-malware-spam-policies/)

- OWASP（Open Web Application Security Project）
  - セキュリティ向上を目的とするアメリカの非営利団体
  - セキュアコーディングのガイドラインを提供
    - コードスメル（コードの臭い）についてはこのガイドラインには含まれない
  - OWASP ZAP
    - OWASPが提供するセキュリティテストツール
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-anti-malware-spam-policies/4-knowledge-check)

## [モジュール5: ライセンス スキャンと脆弱性スキャンの統合](https://docs.microsoft.com/ja-jp/learn/modules/integrate-license-vulnerability-scans/)

- [CodeQL](https://codeql.github.com/)
  - 脆弱性の検出ツール
  - コードに対して（データのように）[クエリ](https://docs.microsoft.com/ja-jp/windows-hardware/drivers/devtest/static-tools-and-codeql#queries)を実行できる
  - [Microsoftドキュメントの解説](https://docs.microsoft.com/ja-jp/windows-hardware/drivers/devtest/static-tools-and-codeql)
- GitHub Dependabot
  - リポジトリ内の依存関係を検査し、問題があれば警告。
  - [GitHub Advisory Database](https://github.com/advisories) に新たな脆弱性が追加された場合に、関連するアラートを送信する
    - ※[GitHubのドキュメントの解説](https://docs.github.com/ja/code-security/dependabot/dependabot-alerts/browsing-security-vulnerabilities-in-the-github-advisory-database#)
- [WhiteSource Bolt](https://www.whitesourcesoftware.com/free-developer-tools/bolt/)
  - オープンソースの脆弱性の検索と修正
  - オープンソースのセキュリティとライセンスのコンプライアンスを評価
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/integrate-license-vulnerability-scans/10-knowledge-check)

## [モジュール6: 技術的負債を特定する](https://docs.microsoft.com/ja-jp/learn/modules/identify-technical-debt/)

- コードスメル（コードの臭い）
  - 問題になる可能性があるコード
- 静的ソースコード解析ツール
  - [SonarCloud](https://sonarcloud.io/)
    - コード品質のチェック
    - コードスメル（コードの臭い）を発見できる
  - [WhiteSource Bolt](https://www.whitesourcesoftware.com/free-developer-tools/bolt/)
    - オープンソースの脆弱性の検索と修正
    - オープンソースのセキュリティとライセンスのコンプライアンスを評価
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/identify-technical-debt/8-knowledge-check)


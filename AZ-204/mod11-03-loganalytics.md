# Log Analytics

特設サイト
https://dev.loganalytics.io/

■ログまわりの用語の整理

[Azure Monitor ログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/data-platform-logs):
- 監視対象のリソースからログとパフォーマンス データを収集して整理する Azure Monitor の **機能**
```
Azure Monitor （サービス）
├ Azure Monitor メトリック（機能）: メトリック エクスプローラで分析
└ Azure Monitor ログ（機能）: Log Analyticsで分析
```

[Log Analytics](https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/log-analytics-overview):
- Azure Monitor ログによって収集されたデータからログ クエリを編集して実行し、その結果を対話形式で分析する Azure portal の **ツール**
- [Log Analyticsのデモ環境](https://portal.azure.com/#blade/Microsoft_Azure_Monitoring_Logs/DemoLogsBlade) が提供されている

```
Azure portal
└モニター
  └ログ (Log Analytics): クエリを編集・実行

Azure portal
└Log Analyticsワークスペース
  └ログ (Log Analytics): クエリを編集・実行

Azure portal
└リソース（ストレージアカウント等）
  └ログ (Log Analytics): クエリを編集・実行

Azure portal
└Log Analyticsのデモ環境: クエリを編集・実行
```


[Log Analytics ワークスペース](https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/quick-create-workspace):

- Azureの **リソース** の一種
- Azure Monitor ログ データ用の一意の **環境**
- 無料で利用できる範囲を超えて利用すると料金が発生
- [ログは、Log Analytics ワークスペースに格納される。](https://docs.microsoft.com/ja-jp/azure/azure-monitor/data-platform#logs)

```
監視対象のリソース（VM等）
↓ ログ
Log Analyticsワークスペース（リソース/環境）
```

■ログの種類

[プラットフォーム ログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/platform-logs-overview): 
- Azure リソースと Azure プラットフォームの詳細な診断情報と監査情報を提供するしくみ。
```
プラットフォーム ログ
├ リソース ログ
├ アクティビティ ログ
└ Azure Active Directoryログ
```

[リソース ログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/resource-logs):
- サポートされている Azure リソースによって自動的に生成されるログ
  - 例: [Key Vaultのログ](https://docs.microsoft.com/ja-jp/azure/key-vault/general/logging)
  - 例: [Logic Appのログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/tutorial-resource-logs#create-a-diagnostic-setting)
  - [リソースに「診断設定」メニューがあれば、そこからリソース ログを取得できる](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/diagnostic-settings?tabs=CMD#create-in-azure-portal)
- 「診断設定」を行い、ログをLog Analyticsなどに送信しなければ、確認できない
- 以前は「診断ログ」と呼ばれていた

[アクティビティ ログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/essentials/activity-log):
  - Service Healthイベントの更新と、サブスクリプションの各Azureリソースに対する操作の分析情報を提供するログ
  - リソースに対して行われるすべての書き込み操作を確認できる
  - Azure サブスクリプションごとに1つのアクティビティ ログがある。
- ログデータは発生してから90日間、保持される。
- 「診断設定」を行い、ログをLog Analyticsなどに送信することができる。

[Azure Active Directoryログ](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-audit-logs):
- [サインイン ログ](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-sign-ins): サインイン アクティビティ履歴
- [監査ログ](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-audit-logs): Azure Active Directoryで行われた変更の監査証跡
- [プロビジョニング ログ](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-provisioning-logs): 「プロビジョニング サービス」によって実行されるアクティビティ
- [保持期限はログの種類と、テナントのエディションによって異なるが、7日～90日](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/reference-reports-data-retention#how-long-does-azure-ad-store-the-data)。
- 「診断設定」を行い、ログをLog Analyticsなどに送信することができる。



```
プラットフォーム ログ（リソース ログ、アクティビティ ログ、Azure ADログ）
↓ 診断設定
Log Analyticsワークスペース/ストレージアカウント/Event Grid
```

[カスタムログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/agents/data-sources-custom-logs): 
- Log Analytics エージェントを使用して、Windows/Linux上の任意のテキストファイル（ログファイル）を読み取り、カスタムログとして、Log Analyticsワークスペースに送信することができる。
    ```
    カスタム ログ（Windows, Linux上の任意のテキストファイル）
    ↓ Log Analyticsエージェント
    Log Analyticsワークスペース
    ```
- SDK ([Microsoft.Azure.OperationalInsights](https://www.nuget.org/packages/Microsoft.Azure.OperationalInsights)) を使用して、プログラムから任意の形式のカスタムログを送信することもできる
    ```
    カスタム ログ（任意のプログラム）
    ↓ SDK
    Log Analyticsワークスペース
    ```

■Log Analytics ワークスペースの構造

```
Log Analyticsワークスペース
└テーブル (AzureActivity 等) 
  └行(rows) / レコード
    └ 列 / プロパティ / フィールド
```

■Azure CLIからの操作

https://docs.microsoft.com/ja-jp/cli/azure/monitor/log-analytics?view=azure-cli-latest

```
# ワークスペースの作成
az monitor log-analytics workspace create -g larg -l eastus -n test298347

# ワークスペースの一覧表示
az monitor log-analytics workspace list -g larg --query '[].name'

# 共有キー(primarySharedKey, secondarySharedKey)の取得
az monitor log-analytics workspace get-shared-keys -g larg -n test298347

# テーブルの一覧表示
# 注意: 初回実行時、拡張機能のインストールが求められる。エンターでインストール。
# 注意: --workspace-name を使う。短縮形はない。
az monitor log-analytics workspace table list -g larg --workspace-name test298347 --query '[].name' --output tsv |column

# クエリ
# 注意: --workspace-name の短縮形 -w を使用できる
az monitor log-analytics query -w test298347 --analytics-query 'AzureActivity'
```

■支払い方法

Log Analyticsワークスペース作成時、「支払い方法」は「従量課金制」に設定される。

作成後、画面左メニューの「使用量と推定コスト」から、支払い方法を「コミットメントレベル」へ切り替えることができる。

- 従量課金制 （例: 257円/GB。100GBの場合, 25700円）
- 100 GB/日のコミットメント レベル （例: 21,952円/日）
- 200 GB/日のコミットメント レベル
- 300 GB/日のコミットメント レベル
- 400 GB/日のコミットメント レベル
- 500 GB/日のコミットメント レベル
- 1000 GB/日のコミットメント レベル
- 2000 GB/日のコミットメント レベル
- 5000 GB/日のコミットメント レベル

■価格

https://azure.microsoft.com/ja-jp/pricing/details/monitor/

Log Analyticsの料金は以下の3つの観点から計算される。

- インジェスト(データの取り込み)
  - 支払い方法「従量課金制」: インジェストされたデータのGBあたりで料金が発生. 例: 257円/GB
  - 支払い方法「コミットメントレベル」: 固定料金 例: 21,952円/日
- 保持(保存されたデータ容量 ✕ 期間) 例: 11円/GB/月
- エクスポート(データのストリーミング出力) 例: 11円/GB

■参考: OMS

Log Analyticsワークスペースをデプロイすると、デプロイ名として「Microsoft.LogAnalyticsOMS」と表示される。

OMS: Microsoft Operations Management Suite

2018/4に廃止されている。
https://docs.microsoft.com/ja-jp/azure/azure-monitor/terminology#april-2018---retirement-of-operations-management-suite-brand

https://atmarkit.itmedia.co.jp/ait/articles/1809/03/news019.html
> 「Microsoft Operations Management Suite（OMS）」は2015年5月に登場し、OMSのブランドで有料サービスとして提供されてきた（無料のFreeプランあり）、クラウドベースのIT管理ソリューションです。

> Operations Management Suite（OMS）サービスのAzureポータルへの移行完了を受け、OMSポータルの提供が2019年1月15日に終了することが発表されました。


https://atmarkit.itmedia.co.jp/ait/articles/1601/12/news030.html

> Microsoft OMSの実態はMicrosoft Azureのクラウドサービスで、「Operational Insights」「Azure Automation」「Azure backup」「Azure Site Recovery」の4つのサービスで構成されています。

■カスタムログ

https://docs.microsoft.com/ja-jp/azure/azure-monitor/agents/data-sources-custom-logs

「C# SDK」や、「LogAnalytics Client for .NET Core」を使用すると、プログラムから、任意の形式のカスタムログをLog Analyticsワークスペースに書き込むことができる。

```
Log Analyticsワークスペース
 └ テーブル（～_CL）
     ↑ カスタムログの書き込み
.NETアプリケーション＋LogAnalytics Client for .NET Core

```

■C# SDK

Log Analyticsと通信するためのライブラリ。Microsoft公式。

https://www.nuget.org/packages/Microsoft.Azure.OperationalInsights/

https://dev.loganalytics.io/documentation/Tools/CSharp-Sdk

■LogAnalytics Client for .NET Core

Log Analyticsにカスタムログを送信するためのライブラリ。オープンソース。内部でC# SDKを使用している。

https://www.nuget.org/packages/LogAnalytics.Client/

https://github.com/Zimmergren/LogAnalytics.Client

```
# .NET 3.1
dotnet add package LogAnalytics.Client -v 1.3.2
# .NET 5以降
dotnet add package LogAnalytics.Client
```

コード例

```
using System;
using LogAnalytics.Client;
using System.Threading.Tasks;

namespace LogSender
{
    public class TestEntity
    {
        public string Category { get; set; }
        public string TestString { get; set; }
        public bool TestBoolean { get; set; }
        public DateTime TestDateTime { get; set; }
        public double TestDouble { get; set; }
        public Guid TestGuid { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            LogAnalyticsClient logger = new LogAnalyticsClient( 
                workspaceId: "...",
                sharedKey: "...");

            await logger.SendLogEntry(new TestEntity
                {
                    Category = "TestCategory",
                    TestString = $"String Test",
                    TestBoolean = true,
                    TestDateTime = DateTime.UtcNow,
                    TestDouble = 3.14,
                    TestGuid = Guid.NewGuid()
                }, "demolog").ConfigureAwait(false);

        }
    }
}
```

注: プログラムからログを送信してから、Azure portalのLog Analyticsワークスペースの「ログ」で検索ができるようになるまで数分程度かかる。

注: カスタムログのテーブル名には「_CL」が付与される。上記の場合、テーブル名は「demolog_CL」となる。

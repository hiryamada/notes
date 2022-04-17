[知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/design-solution-to-log-monitor-azure-resources/7-knowledge-check)


# 1. Log Analytics ワークスペース（1箇所にすべてのログを集めたい場合の運用モデル）

「一元化モデル」: すべてのログを、1つのLog Analyticsワークスペースに格納する。

```
Log Analyticsワークスペース（全ログを集約）
↑        ↑        ↑
アプリ1  アプリ2  アプリ3  ...
```

https://docs.microsoft.com/ja-jp/azure/azure-monitor/logs/design-logs-deployment#important-considerations-for-an-access-control-strategy

# 2. Azure ADのユーザーのサインイン アクティビティをログに記録する

「Azure Active Directory 監査ログ」

https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-audit-logs

Azure Active Directory の監査ログには、サインイン アクティビティの履歴が含まれる。

# 3. アプリケーションに対するユーザーの行動を分析する

「Azure Application Insights」

Application Insights を使用すると、アプリケーション上でのユーザーの動作を分析できる。

```
ユーザー
↓ アプリを利用
モバイルアプリ等
└Applicaiton Insights SDK
         ↓テレメトリを送信
Application Insights
↑アプリの利用状況を分析
開発者
```
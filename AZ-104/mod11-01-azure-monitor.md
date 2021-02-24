# Azure Monitor

Azure とオンプレミスのサービスを監視します。 メトリック、ログ、およびトレースを集計して分析します。 アラートを発生させ、通知を送信するか、自動ソリューションを呼び出します。

[製品ページ](https://azure.microsoft.com/ja-jp/services/monitor/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-monitor/overview)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/monitor/)

Azure Monitor Logで実現するモダンな管理手法:
[動画](https://www.youtube.com/watch?v=YwYVd38xFMU)
,[スライド](https://www.slideshare.net/ssuser411bae/azure-monitor-log)

# 歴史

2016/9/16 Azure Monitor Public Preview

https://azure.microsoft.com/ja-jp/blog/announcing-the-public-preview-of-azure-monitor/


2017/3/31 Azure Monitor GA

https://azure.microsoft.com/ja-jp/blog/announcing-the-general-availability-of-azure-monitor/


# Azure Monitor のブランド変更 / 用語の変更

https://docs.microsoft.com/ja-jp/azure/azure-monitor/terminology

- 監視サービスを Azure Monitor に統合
- 管理ソリューションの名称は、その機能をよりわかりやすく示すために 監視ソリューション に変更されました。
- Log AnalyticsとApplication Insightsは、Azure Monitorに統合された
- Azure Monitor 内のログ データを保持するワークスペースは引き続き Log Analytics ワークスペースと呼ばれます。
- Log Analytics という用語は多くの場所で **Azure Monitor ログ** に変更されています。Log Analytics のログデータ エンジンとクエリ言語は、**Azure Monitor ログ**と呼ばれるようになっています。
- "**診断ログ**" が "**リソース ログ**" に変更されました。 "診断設定" という用語は変わりありません。



パートナー統合
https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/partners#datadog

# [Azure Monitor for VMs](https://docs.microsoft.com/ja-jp/azure/azure-monitor/insights/vminsights-overview)

Azure Monitor for VMs では、実行中のプロセスや他のリソースへの依存関係など、仮想マシンと仮想マシン スケール セットのパフォーマンスと正常性が監視されます。 それは、パフォーマンスのボトルネックとネットワークの問題を識別することによって、重要なアプリケーションのパフォーマンスと可用性を予測するのに役立ち、問題が他の依存関係に関連しているかどうかを把握することにも役立つ可能性があります。

# [アクションルール](https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/alerts-action-rules?tabs=portal)

アラートによって生成される通知を抑制すると便利なシナリオは多数あります。 これらのシナリオは、**計画メンテナンス期間中の抑制**から、**業務時間外の抑制**まで多岐にわたります。 

アクション ルールを使用すると、Azure Resource Manager の任意のスコープ (Azure サブスクリプション、リソース グループ、ターゲット リソース) で、アクションを定義または抑制できます。


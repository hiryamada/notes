# Azure Site Recovery

物理マシンとAzure VMで実行中のワークロードを、プライマリ サイトからセカンダリ ロケーションに継続的にレプリケーション。

災害発生時にフェイルオーバー（切り替え）。

https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-overview

Azure Hyper-V Recovery Manager (Azure Site Recoveryの前身)
- 2013/4 限定プレビュー 
- 2013/10 パブリックプレビュー 
- 2014/1 正式サービス開始 
- https://atmarkit.itmedia.co.jp/ait/articles/1406/30/news020.html

2014/6/20 Azure Site Recovery プレビュー https://atmarkit.itmedia.co.jp/ait/articles/1406/30/news020.html

2015/7/16 Azure Site Recovery 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-site-recovery-ga-move-vmware-aws-hyper-v-and-physical-servers-to-azure/


■Recovery Servicesコンテナー

Azure Site Recoveryでは、（Azure Backupでも使用される）「Recovery Servicesコンテナー」を使用して、VM等のデータをレプリケーションする。

■継続的なレプリケーション

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-enable-replication

物理マシンと仮想マシン (VM) で実行中のワークロードを、プライマリ サイトからセカンダリ ロケーションにレプリケートする。

■リカバリー訓練（Recovery drill）

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-dr-drill

フェールオーバーの訓練（テスト）を行うことができる。

- 復旧ポイントを選択
- テスト フェールオーバーを実行
- テストが完了したら、「テストフェールオーバーのクリーンアップ」を使用して、作成されたテスト用VMを削除。

■フェイルオーバー

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-failover-failback

プライマリ サイトで障害が発生した場合は、セカンダリ ロケーションにフェールオーバーする。

■フェールバック

https://docs.microsoft.com/ja-jp/azure/site-recovery/azure-to-azure-tutorial-failback

プライマリ サイトが再度利用可能になったら、そこにフェールバックを行う。


■対応できるレプリケーション

- Azure リージョン間で Azure VM をレプリケート
- オンプレミス VM、Azure Stack VM、物理サーバー
  - レプリケーション先
    - Azure
    - オンプレミスのセカンダリ データセンター

■参考: Azure Site Recovery Deployment Planner

https://docs.microsoft.com/ja-jp/azure/site-recovery/site-recovery-deployment-planner

Hyper-V から Azure へのディザスター リカバリー シナリオと VMware から Azure へのディザスター リカバリー シナリオの両方で使用できるコマンドライン ツール。

■ラボ12

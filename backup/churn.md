# チャーン (churn)

https://learn.microsoft.com/ja-jp/azure/backup/azure-backup-pricing

チャーンとは、データ変更の量を指します。 たとえば、バックアップするデータが 200 GB の VM があり、そのうち 10 GB が毎日変更される場合、日次チャーンは 5% です。

チャーンが高くなると、より多くのデータをバックアップすることになります

https://learn.microsoft.com/ja-jp/azure/site-recovery/concepts-azure-to-azure-high-churn-support

Azure Site Recovery では、VM あたり最大 100 MB/秒のチャーン (データ変更率) がサポートされています。


https://learn.microsoft.com/ja-jp/azure/site-recovery/monitoring-high-churn

適切なツールを使用することで、どのアプリケーションが高いチャーンの原因であるかを正確に検出し、そのアプリケーションに対して実行できるアクションを簡単に確認できます。

https://learn.microsoft.com/ja-jp/azure/site-recovery/vmware-azure-troubleshoot-replication#source-machines-with-high-churn-error-78188

ソース マシンのチャーン レートが高い [エラー 78188]
考えられる原因:

仮想マシンの一覧上のディスクでのデータ変化率 (書き込みバイト/秒) が、レプリケーション ターゲットのストレージ アカウントの種類に対して Azure Site Recovery がサポートしている上限を超えている。
チャーン レートが突然急増した結果、大量のデータのアップロードが保留になっている。
この問題を解決するには:

ターゲットのストレージ アカウントの種類 (Standard または Premium) が、ソースのチャーン レート要件に従ってプロビジョニングされていることを確認します。
Premium マネージド ディスク (asrseeddisk タイプ) に既にレプリケートしている場合、Site Recovery 制限に従って、ディスクのサイズが、測定されたチャーン レートをサポートしていることを確認します。 必要に応じて、asrseeddisk のサイズを増やすことができます。 次の手順に従ってください。

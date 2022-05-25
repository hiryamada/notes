
# ラーニングパス 4: [AZ-104:Azure のコンピューティング リソースのデプロイと管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-compute-resources/)
## モジュール 1: [仮想マシンの構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machines/)
- ユニット 10: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machines/10-knowledge-check)
  - 問題1 ネットワークアプライアンス（ファイアウォールやロードバランサー等）をVMとしてデプロイする場合は、[「コンピューティング最適化」](https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-compute)が適している。
  - 問題2 Azure Bastionを使用すると、Webブラウザーを使用してVMに接続ができる。SSHやRDPを使用せずにVMの操作を実行できる。「カスタムスクリプト拡張機能」でスクリプトを流し込むという設定方法もあるが、この問題では「仮想マシンに **接続して** ソフトウェアをインストールする」とあるので、Bastionが正解となる。
  - 問題3 VM作成時に、ネットワークセキュリティグループが作られる。ネットワークセキュリティグループの初期設定では、受信は全て拒否、送信は許可がデフォルトとなっている。（VM作成時に、SSHやRDPによる接続を許可するように指定した場合は、そのような受信が追加で許可される。）
## モジュール 2: [仮想マシンの可用性を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-availability/)
- ユニット 11: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-availability/11-knowledge-check)
  - 問題1 「自動スケーリング」を使用すると、仮想マシンのCPU利用率が指定以上となった場合に、VMを追加するように設定することができる。
  - 問題2 「自動スケーリング」の「スケジュールベースのルール」を使用すると、指定したスケジュールに応じて、VMを増減させることができる。
  - 問題3 仮想マシンスケールセットは、基本的に、同じ構成のVM（インスタンス）をセット内で増減させる仕組みである。
## モジュール 3: [仮想マシン拡張機能を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-extensions/)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-virtual-machine-extensions/5-knowledge-check)
  - 問題1 「仮想マシン拡張機能」は、仮想マシンの構成やタスク実行を行う仕組み。「Desired State Configuration（DSC）拡張機能」や「カスタムスクリプト拡張機能」などの「仮想マシン拡張機能」があり、VMのデプロイ時などに必要なものを選択する形で使用する。選択肢の「Desired State Configuration（DSC）」でも仮想マシンの構成やタスク実行を行うことができるので、これも正解のひとつとなりうる。
  - 問題2 カスタムスクリプト拡張機能を使用した場合、スクリプトは90分でタイムアウトとなる。超えると、拡張機能のプロビジョニングに失敗したとみなされる。
  - 問題3 「Desired State Configuration（DSC）」を使用して、IIS（Webサーバー）をセットアップできる。
## モジュール 4: [App Service プランを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-app-service-plans/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-app-service-plans/6-knowledge-check)
  - 問題1 この問題の要件「5 つのインスタンスと 100 GB のディスク ストレージ」は、StandardとPremiumで満たすことができるが、Standardのほうがより安価であるため適切。
  - 問題2 スケールアップにより、インスタンス（VM）を増やさずに、プランの性能を上げることができる。
  - 問題3 指定の日時にスケーリングを行うには「自動スケーリング」の「[時間ベース（スケジュールベース）のルール](https://docs.microsoft.com/ja-jp/azure/azure-monitor/autoscale/autoscale-overview#rules)」を使用する。また、スケーリング後に通知を行うには、[Webhook](https://docs.microsoft.com/ja-jp/azure/azure-monitor/autoscale/autoscale-webhook-email#webhooks)を使用することができる。
## モジュール 5: [Azure App Service を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-app-services/)
- ユニット 11: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-app-services/11-knowledge-check)
  - 問題1 デプロイスロットのスワップについて、「接続文字列」の設定は、スワップ全体の内容に従う（スワップされる）。[参考](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-staging-slots#which-settings-are-swapped)
  - 問題2 Application Insightsを使用すると、Webアプリのアクセスを分析することができる。
  - 問題3 GitHubからApp Serviceへと自動でデプロイすることができる。
## モジュール 6: [Azure Container Instances を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-container-instances/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-container-instances/6-knowledge-check)
  - 問題1 仮想マシンは、他の仮想マシンとは論理的に分離されている（仮想マシンから他の仮想マシンへ許可なくアクセスすることはできない）。※この問題はACIではなくコンテナー一般についての設問。
  - 問題2 ACIの課金は、コンテナー（正確にはコンテナーグループ）が実行されている間、発生する。
## モジュール 7: [Azure Kubernetes Service の構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-kubernetes-service/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-kubernetes-service/8-knowledge-check)
  - 問題1 kubelet は、Azure マネージド ノード（クラスターマスター）からのリクエストを処理する。
  - 問題2 ClusterIP は、AKS クラスター内で使用する内部 IP アドレスを作成する。クラスター内部で、他のクラスターにサービスを提供する場合に使用する。
  - 問題3 AKSの料金はノードのVMに対して発生する。
## モジュール 8: [Azure CLI を使用して仮想マシンを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-virtual-machines-with-azure-cli/)
- ユニット 9: [概要とクリーンアップ](https://docs.microsoft.com/ja-jp/learn/modules/manage-virtual-machines-with-azure-cli/9-cleanup)
  - ※ページ下部に知識チェックあり
  - 問題1 タブレットからAzure portalにアクセスし、その中でAzure Cloud Shellを起動することで、CLIによるAzure操作が可能である。
  - 問題2 Azure CLIの `--no-wait` オプションを使用すると、時間のかかる処理の完了を待たないため、次のコマンドを実行できる。
  - 問題3 `--query` では、コマンドの実行結果のJSONから必要な部分だけを取り出すことができる。[JMESPpath](https://jmespath.org/) という構文が使用される。
## モジュール 9: [Azure で Windows 仮想マシンを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-windows-virtual-machine-in-azure/)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/create-windows-virtual-machine-in-azure/8-summary)
  - ※ページ下部に知識チェックあり
  - 問題1 仮想マシンにリモートデスクトップで接続する場合、TCPポート3389番が使用される。
  - 問題2 データは、OSディスクや一時ディスクではなくデータディスクに配置することが推奨される。
  - 問題3 （ネットワークセキュリティグループの受信規則について）組み込まれた規則の最後の規則では「すべてのトラフィックを拒否」が適用される。
## モジュール 10: [Azure App Service で Web アプリケーションをホストする](https://docs.microsoft.com/ja-jp/learn/modules/host-a-web-app-with-azure-app-service/)
- ユニット 8: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/host-a-web-app-with-azure-app-service/8-summary)
  - ※ページ下部に知識チェックあり
  - 問題1 Azure App Service は、トラフィックの需要に合わせて Web アプリケーションを自動的にスケーリングできる（自動スケーリング）
  - 問題2 GitHubからApp Serviceへと自動でデプロイすることができる。
## モジュール 11: [Azure Automation State Configuration を使用して仮想マシンの設定を保護する](https://docs.microsoft.com/ja-jp/learn/modules/protect-vm-settings-with-dsc/)
- ユニット 2: [Azure Automation State Configuration とは何ですか?](https://docs.microsoft.com/ja-jp/learn/modules/protect-vm-settings-with-dsc/2-what-is-azure-automation-state-configuration)
  - ※ページ下部に知識チェックあり
  - 問題1 
  - 問題2 

# Azure Container Instance (ACI)

Azure で最も高速かつ簡単にコンテナーを実行する方法を提供。

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview

2018/4/25 一般提供開始 
- https://azure.microsoft.com/ja-jp/updates/aci-ga/
- https://azure.microsoft.com/ja-jp/blog/azure-container-instances-now-generally-available/

■特徴

- Docker Hub, Azure Container Registry(ACR), Microsoft Container Registry(MCR) からイメージを読み込むことができる。
  - [Docker Hub](https://hub.docker.com/)
  - [Azure Container Registry(ACR)](https://docs.microsoft.com/ja-jp/azure/container-registry/)
    - プライベートなレジストリを運用するためのサービス。
  - [Microsoft Container Registry(MCR)](https://github.com/microsoft/containerregistry)
    - マイクロソフトが提供する公式イメージのプライマリレジストリ。
    - MCRで提供されるイメージは[Docker Hub](https://hub.docker.com/publishers/microsoftowner)で確認できる。
- [GPUリソースも利用できる](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-gpu)
- Linuxコンテナーに加え[Windowsコンテナー](https://docs.microsoft.com/ja-jp/dotnet/architecture/modernize-with-azure-containers/modernize-existing-apps-to-cloud-optimized/when-to-deploy-windows-containers-to-azure-container-instances-aci)にも対応。

■コンテナーグループ

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups

Azure Container Instances の最上位のリソース。

同じホスト コンピューター上にスケジュール設定される (get scheduled) コンテナーの集まり。 

※スケジュール: コンテナーの用語としては、コンテナーを、適切なコンピューターに配置すること（Podを、クラスター内の適切なノードに配置すること）を指す。

コンテナー グループ内のコンテナーでは、ライフサイクル、リソース、ローカル ネットワーク、ストレージ ボリュームを共有する。

Kubernetes におけるポッドの概念に似ている。

■コンテナーグループに割り当て可能なCPUとメモリ

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#resource-allocation

ACIでは、グループにインスタンスのリソース要求を追加することで、CPUやメモリを、コンテナー グループに割り当てる。

最小値: 1 CPU、1 GB メモリ。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#minimum-and-maximum-allocation

最大値: 4コア、16 GB メモリ。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#can-i-deploy-with-more-than-4-cores-and-16-gb-of-ram

※注意: 実際に利用可能な最大値は[リージョンによって異なる](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-region-availability)。

■az container createコマンド

指定したイメージをACIで実行する。多彩なオプションを利用できる。

（コマンド名からは「コンテナー」を作るように感じられるが）まず「コンテナーグループ」が作られ、その中で「コンテナー」を動かす。

https://docs.microsoft.com/en-us/cli/azure/container?view=azure-cli-latest#az_container_create

■az container deleteコマンド

コンテナーグループを削除する。

■az container stopコマンド

https://docs.microsoft.com/ja-jp/cli/azure/container?view=azure-cli-latest#az_container_stop

コンテナー グループ内のすべてのコンテナーを停止。課金も停止する。

■az container startコマンド

https://docs.microsoft.com/ja-jp/cli/azure/container?view=azure-cli-latest#az_container_start

コンテナー グループ内のすべてのコンテナーを開始。

■料金

https://azure.microsoft.com/ja-jp/pricing/details/container-instances/

コンテナーグループ単位、秒単位で課金される。

コンテナー グループに割り当てた vCPU の数とメモリの量 (GB) に応じて価格が決まる。

■ネットワーク

コンテナーグループにパブリックIPアドレスとDNS名（FQDN）を割り当て可能。

「ラベル」（FQDNの先頭の部分）を指定できる。

例: ラベルに「example」を指定し、米国東部（eastus）で起動。
→ example.eastus.azurecontainer.io というFQDNでアクセスできる。

■ストレージ

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-volume-azure-files

Azure Files（ファイル共有）を直接マウントすることができる。

Linuxコンテナーのみ。

■参考: ACIで使用されるVMシリーズ

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#aci----------------------------

> Azure Container Instances は、サーバーレスのコンテナー オンデマンド サービスであることを目的としているため、コンテナーの開発に集中してください。インフラストラクチャについて心配する必要はありません。 パフォーマンスの比較に関心がある場合、または比較する場合、 **ACI は主に F シリーズと D シリーズのさまざまな SKU の Azure VM セット上で動作します** 。 サービスの開発と最適化に伴い、 **今後これは変わると予想されます** 。

■参考: ACIを定期的に実行するには？

- 方法(1): Azure Automationから起動
  - [Azure Container Instances + Azure Automationで超格安バッチ実行基盤を構築](https://tech-lab.sios.jp/archives/19859)
- 方法(2): Logic Appsから起動
  - [Azure Container InstanceをLogic Appsでスケジューリングする](https://yolo-kiyoshi.com/2021/02/04/post-2586/)

■参考: Microsoft Learn

Azure Container Instances で Docker コンテナーを実行する
https://docs.microsoft.com/ja-jp/learn/modules/run-docker-with-azure-container-instances/

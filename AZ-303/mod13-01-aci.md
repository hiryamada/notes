# Azure Container Instance (ACI)

Azure で最も高速かつ簡単にコンテナーを実行する方法を提供。

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview

2018/4/25 一般提供開始 
- https://azure.microsoft.com/ja-jp/updates/aci-ga/
- https://azure.microsoft.com/ja-jp/blog/azure-container-instances-now-generally-available/

■参考: Microsoft Learn:
Azure Container Instances で Docker コンテナーを実行する
https://docs.microsoft.com/ja-jp/learn/modules/run-docker-with-azure-container-instances/


■ACIで使用されるVMの性能

Fシリーズ または Dシリーズになるが、特にどのサイズが使われるかは決まっていない。

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#what-underlying-infrastructure-does-aci-run-on

> Azure Container Instances は、サーバーレスのコンテナー オンデマンド サービスであることを目的としているため、コンテナーの開発に集中してください。インフラストラクチャについて心配する必要はありません。 パフォーマンスの比較に関心がある場合、または比較する場合、ACI は主に F シリーズと D シリーズのさまざまな SKU の Azure VM セット上で動作します。 サービスの開発と最適化に伴い、今後これは変わると予想されます。


■コンテナーグループ

ACIを使用する際には「コンテナーグループ」（同じホスト コンピューター上にスケジュール設定されるコンテナーのコレクション）を作り、そこにコンテナーをデプロイする。

■コンテナーグループに割り当てるCPUとメモリ

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#resource-allocation

ACIでは、グループにインスタンスのリソース要求を追加することで、CPU、メモリ、必要に応じて GPUなどのリソースをマルチコンテナー グループに割り当てる。

最小値: 1 CPU、1 GB メモリ。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#minimum-and-maximum-allocation

最大値: 4コア、16 GB メモリ。

https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#can-i-deploy-with-more-than-4-cores-and-16-gb-of-ram。

[リージョンによって異なる](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-region-availability)。

■ [コンテナーグループ](https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups)

Azure Container Instances の最上位のリソースは、コンテナー グループです。

コンテナー グループは、同じホスト コンピューター上にスケジュール設定される (get scheduled) コンテナーのコレクション。 

※[スケジュール：コンテナ（Pod）をコンピューター（ノード、クラスター）に配置すること。](https://access.redhat.com/documentation/ja-jp/openshift_container_platform/3.11/html/cluster_administration/scheduling)

コンテナー グループ内のコンテナーでは、ライフサイクル、リソース、ローカル ネットワーク、ストレージ ボリュームを共有する。（これは、Kubernetes におけるポッドの概念に似ている。）

■az container createコマンド

[コンテナーグループを作る](https://docs.microsoft.com/en-us/cli/azure/container?view=azure-cli-latest#az_container_create)。


[半日でわかる コンテナー技術 (入門編)](https://www.slideshare.net/ToruMakabe/ss-120427179)


■コンテナで、VMのようなサイズを選べますか？

FまたはDになりますが、特にどのサイズが使われるかは決まっていません。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#what-underlying-infrastructure-does-aci-run-on
「ACI はどのような基盤インフラストラクチャ上で動作しますか。
Azure Container Instances は、サーバーレスのコンテナー オンデマンド サービスであることを目的としているため、コンテナーの開発に集中してください。インフラストラクチャについて心配する必要はありません。 パフォーマンスの比較に関心がある場合、または比較する場合、ACI は主に F シリーズと D シリーズのさまざまな SKU の Azure VM セット上で動作します。 サービスの開発と最適化に伴い、今後これは変わると予想されます。」

ACIを使用する際に「コンテナーグループ」（同じホスト コンピューター上にスケジュール設定されるコンテナーのコレクション）を作り、そこにコンテナーをデプロイするのですが、その際に、以下の設定が可能です。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#resource-allocation
「Azure Container Instances では、グループにインスタンスのリソース要求を追加することで、CPU、メモリ、必要に応じて GPU (プレビュー) などのリソースをマルチコンテナー グループに割り当てます。 」

コンテナー グループに割り当ての最小値は、 1 CPU と 1 GB メモリとなります。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups#minimum-and-maximum-allocation

最大値は、4コア、16GBメモリとなります。
https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-faq#can-i-deploy-with-more-than-4-cores-and-16-gb-of-ram

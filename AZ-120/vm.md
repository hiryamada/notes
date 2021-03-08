# SAP向けのVMシリーズ

[SAP HANA on Azure (L インスタンス)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/workloads/sap/hana-overview-architecture)

- お客様に割り当てられた非共有ホスト/サーバーのベア メタル ハードウェア上に構築されます。
- 36 個の Intel CPU コアと 768 GB のメモリを搭載できます。
- 最大 480 個の Intel CPU コアと最大 24 TB 
- **SAP HANA の実行のみがサポートされます**。

https://ascii.jp/elem/000/001/493/1493326/

- Gシリーズは（SAP HANAワークロードの）開発/テストやPoC用途に最適. [2021/3現在東日本リージョンでのみ利用可能。](https://azure.microsoft.com/ja-jp/global-infrastructure/services/?products=virtual-machines&regions=japan-west,japan-east)
- Mシリーズは本番環境に最適なインスタンス. [東日本、西日本リージョンで利用可能](https://azure.microsoft.com/ja-jp/global-infrastructure/services/?products=virtual-machines&regions=japan-west,japan-east)
- Large Instanceはハードウェアを専有する利用形態のため年間料金での契約になるが、その分高い可用性を提供し、SLA99.99％を保証している. [東日本、西日本リージョンで利用可能](https://azure.microsoft.com/ja-jp/global-infrastructure/services/?products=virtual-machines&regions=japan-west,japan-east)

https://docs.microsoft.com/ja-jp/archive/blogs/mssvrpmj/microsoft-azure-japan-dc-update

- 大規模仮想マシン 「M シリーズ」 と SAP HANA 用専用ハードウェア サービス 「SAP HANA on Azure (Large Instances)」 を東日本リージョンおよび西日本リージョンより提供することを発表
- 現在急増 している SAP HANA ワークロードのクラウド上での稼働ニーズに対して、日本国内のデータセンターからご利 用いただくことが可能


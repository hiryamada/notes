# App Serviceでは可用性セットや可用性ゾーンが使用できるのか？

App Serviceでは暗黙の可用性セット（正確には「配置グループ」）が適用される（後述）

リージョンが可用性ゾーンに対応している場合は、可用性ゾーンの利用も可能である。
App Serviceでは2021/9/3より可用性ゾーンが利用できるようになった。
https://azure.microsoft.com/ja-jp/updates/azure-app-service-support-for-availability-zones-reaches-general-availability/

■App ServiceのSLAは99.95%である（可用性セットを条件に従って使用した場合のSLAと同じ）

マイクロソフトは、Azure App Service が 99.95% の確率で利用できることを保証する。
https://learn.microsoft.com/ja-jp/azure/well-architected/services/compute/azure-app-service/reliability#design-considerations

SLA は、1 つのインスタンスまたは複数のインスタンスで実行する場合にサポートされる。

※Free / Shared サービスレベルを使用している場合、SLA は提供されない。

■App Serviceの高可用性のための推奨構成

Basicまたはそれ以上のプランを使用し、2つ以上のインスタンス（worker instances）を使うことが推奨される。
https://learn.microsoft.com/ja-jp/azure/well-architected/services/compute/azure-app-service/reliability

■App Serviceの内部ではVMSSが使用されている

App Serviceは以前「Cloud Services」で構築されていたが、現在はVMSSベースとなっている。
https://blog.shibayan.jp/entry/20230128/1674889021

■参考: 「Cloud Services」

PDC 2008 で Azure が発表された時から存在していたもの。
Web RoleやWorker Roleがある。
2024/8/31 リタイア予定。
https://blog.shibayan.jp/entry/20220405/1649089080

Cloud Servicesの公式サイト:
https://azure.microsoft.com/ja-jp/products/cloud-services

Cloud Servicesのドキュメント:
https://learn.microsoft.com/ja-JP/azure/cloud-services/cloud-services-choose-me


参考: VMSSは2016/3/31から提供が開始されている。
https://azure.microsoft.com/en-us/updates/general-availability-virtual-machine-scale-sets/

■VMSS（と、それを使用するApp Service）では暗黙的な可用性セットが使用される

VMSSは「配置グループ」を使用する。これは、5 つの障害ドメインと 5 つの更新ドメインを使用する暗黙的な可用性セットとして機能する。
https://learn.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-faq#scale-sets---azure----------------

App Serviceの内部ではVMSSが使用されているため、App Serviceも可用性セットが使用される。


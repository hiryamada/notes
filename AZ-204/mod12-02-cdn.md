# Azure CDN

[PDFまとめ資料](https://github.com/hiryamada/notes/blob/main/AZ-204/pdf/mod13/Azure%20CDN%E3%81%BE%E3%81%A8%E3%82%81.pdf)

Azure Content Delivery Network (CDN) を使用すれば、読み込み時間の短縮、帯域幅の節約、応答性の向上が可能です。

CDN は、Web Apps、Media Services、Storage、Cloud Services など、各種 Azure サービスとシームレスに連携可能です。

[製品ページ](https://azure.microsoft.com/ja-jp/services/cdn/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/cdn/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-overview)

Microsoft Learn

- [Azure CDN と Blob Service を使用して、Web サイト用のコンテンツ配信ネットワークを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-cdn-static-resources-blob-storage/)

# [4つの製品](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-features)

- Azure CDN Standard from Microsoft
- Azure CDN Standard from Akamai
- Azure CDN Standard from Verizon
- Azure CDN Premium from Verizon

# 概要

コンテンツ配信ネットワーク (CDN) は、ユーザーに Web コンテンツを効率的に配信できるサーバーの分散ネットワークです。 

CDN では、待ち時間を最小限に抑えるために、エンド ユーザーに近いポイントオブプレゼンス (POP) の場所のエッジ サーバーに、キャッシュされたコンテンツを格納します。

Azure Content Delivery Network (CDN) では、世界中に戦略的に配置された物理ノードにコンテンツをキャッシュすることによって、高帯域幅コンテンツをユーザーに高速配信するためのグローバル ソリューションを開発者に提供します。 

さらに、Azure CDN では、CDN POP を使って各種のネットワーク最適化を利用して、キャッシュできない動的なコンテンツも高速化できます。 たとえば、Border Gateway Protocol (BGP) をバイパスするルート最適化などがあります。

特殊なドメイン名 ( `<endpoint name>.azureedge.net` など) の URL を使用して、ファイル (資産[asset]とも呼ばれます) を要求します。 

# CDNプロファイル

少なくとも 1 つの CDN プロファイルを作成する必要があります。これは、CDN エンドポイントをまとめたものです。 

各 CDN エンドポイントは、コンテンツ配信動作およびアクセスの特定の構成を表します。 

インターネット ドメイン、Web アプリケーション、またはその他の一部の基準別に CDN エンドポイントを整理する場合、複数のプロファイルを使用できます。

Azure CDN の価格は CDN プロファイル レベルで適用されるので、価格レベルを組み合わせたい場合は、複数の CDN プロファイルを作成する必要があります。 

# 動的サイトの高速化

Azure CDN の DSA (動的サイトの高速化) 最適化を使用すると、動的コンテンツを含む Web ページのパフォーマンスが向上します。

Azure CDN from Akamai と Azure CDN from Verizon では、エンドポイントの作成中に、 [最適化の対象] メニューを使用して DSA 最適化を提供します。

Microsoft の動的サイト アクセラレーションは、Azure Front Door Service により提供されます。

# Cache Busting

[Cache Busting（キャッシュ破壊）](https://www.google.com/search?q=cache+busting)。クエリパラメータを付与したりファイル名にバージョン番号を入れたりする。

Azure CDN エッジ ノードは、アセットの Time-to-Live (TTL) が期限切れになるまで、そのアセットをキャッシュします。 

アセットの TTL の期限が切れた後に、クライアントがエッジ ノードからアセットを要求すると、エッジ ノードはアセットの最新コピーを取得し、クライアント要求に対応して、更新されたキャッシュを格納します。

ユーザーが常にアセットの最新コピーを取得するのを確実にするベスト プラクティスは、更新ごとにアセットにバージョンを付け、新しい URL として発行することです。 


CDN では、次のクライアント要求のための新しいアセットを直ちに取得します。 


# [パージ（purge, 消去）](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-purge-endpoint)



**必要に応じて、すべてのエッジ ノードのキャッシュされたコンテンツを消去し、すべてのエッジ ノードが新しい更新されたアセットを取得するように強制することもできます。** 

たとえば、Web アプリケーションの更新に対応する場合や、正しくない情報を含むアセットをすばやく更新する場合などです。

- すべて
- 単一URL
- ワイルドカードによる消去
- ルートドメインの消去

消去要求の処理にかかる時間は、Microsoft の Azure CDN で約 10 分、Verizon の Azure CDN (Standard と Premium) で約 2 分、Akamai の Azure CDN で約 10 秒です。 Azure CDN には、どの時点においても、プロファイル レベルでの同時消去要求が 100 件という上限があります。

# [Webコンテンツ有効期限](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-manage-expiration-of-cloud-service-content#testing-the-cache-control-header)

以下の3つの方法でCache-Controlヘッダーを設定する。

- [CDN キャッシュ規則](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-manage-expiration-of-cloud-service-content#setting-cache-control-headers-by-using-cdn-caching-rules)
- [構成ファイル](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-manage-expiration-of-cloud-service-content#setting-cache-control-headers-by-using-configuration-files)
- [プログラム](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-manage-expiration-of-cloud-service-content#setting-cache-control-headers-programmatically)

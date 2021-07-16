# Azure Cache for Redis

■参考資料

[まとめ資料](pdf/mod13/Azure%20Cacheまとめ.pdf)

# Azure CDN


■CDNとは？

コンテンツデリバリーネットワーク。

オリジンサーバーのコンテンツ（HTML、CSS、JavaScript、動画、画像など）をキャッシュするしくみ。

■オリジンサーバーとは？

コンテンツを保持しているサーバー。

Azure VMや、Blobストレージなど。

■オリジンサーバーへの直接のアクセスを避けるには？

オリジンサーバーが、Azure CDNからのトラフィックからのみ受け付けるように、IPアドレスによるACL（アクセスコントロールリスト）を設定する。

Azure CDNが使用するIPアドレスのリストは、REST APIを使用して受信することができる。

オリジンサーバー側で、CDNのIPアドレス（のリスト）からのアクセスを許可し、その他のIPアドレスからのアクセスを拒否するように設定する。

https://docs.microsoft.com/ja-jp/azure/cdn/cdn-pop-list-api

■POPとは？

- ポイントオブプレゼンス
- 「エッジサーバー」が配置されている場所
- 世界中に存在する

CDN では、エンド ユーザーに近いPOPのエッジ サーバーに、キャッシュされたコンテンツを格納する。

ユーザーのリクエストは、地理的に最も近いPOPへとルーティングされる。

■POPはどこにあるのか？

[Azure CDNのPOPの場所](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-pop-locations)

■CDNのリソース
```
CDNプロファイル
└CDNエンドポイント
```

■参考資料

[まとめ資料](pdf/mod13/Azure%20CDNまとめ.pdf)

# ラボ12 Azure CDN

- ソースコードをまだダウンロードしていない場合は[こちらからダウンロード](https://github.com/MicrosoftLearning/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/archive/refs/heads/master.zip)します。
- [手順書](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_12_lab_ak.html)を見ながら演習を行います。

# 地域

[Azure 地域](https://azure.microsoft.com/ja-jp/global-infrastructure/geographies/) には 1 つ以上のリージョンが含まれています。

例：「日本」地域には、「東日本リージョン」と「西日本リージョン」の2つのリージョンがあります。

Azure地域は、**データ所在地**と**コンプライアンスの特定の要件**を満たしています。

例：「日本」地域の**データ所在地**は日本です（データは日本国内に保存されます）。

例：「日本」地域では、**グローバルのコンプライアンス認証**（ISO、SOCなど）と、「[CSゴールドマーク](https://docs.microsoft.com/ja-jp/compliance/regulatory/offering-cs-mark-gold-japan)」「[マイナンバー法](https://docs.microsoft.com/ja-jp/compliance/regulatory/offering-my-number-act-japan)」などの**日本固有のコンプライアンス認証**、「[FISC](https://docs.microsoft.com/ja-jp/compliance/regulatory/offering-fisc-japan)」などの**日本業界固有のコンプライアンス認証**をご利用いただけます。[詳細](https://azure.microsoft.com/ja-jp/overview/trusted-cloud/compliance/)

※例：[マイナンバー法](https://docs.microsoft.com/ja-jp/compliance/regulatory/offering-my-number-act-japan#microsoft-and-the-my-number-act)：日本の顧客が個人データのプライバシーを保護できるように、Microsoft は、Microsoft オンライン サービス条件を通じて、**当社の範囲内のビジネス クラウド サービスが、顧客がマイ ナンバー法を順守するのに役立つ技術的および組織的なセキュリティ セーフガードを実装していることを契約で確約します。** これは、日本のお客様が日本の法的要件を満たせるという自信を持って Microsoft のビジネス クラウド サービスを展開できることを意味します。

# リージョン

# 可用性ゾーン

2014/2/25, [日本データセンター(東日本と西日本)を開設](https://news.microsoft.com/ja-jp/2014/02/25/2014-20/)

2019/4/19, [可用性ゾーンが東日本で一般提供(GA)](https://azure.microsoft.com/ja-jp/updates/general-availability-azure-availability-zones-in-japan-east/)

可用性ゾーン間のレイテンシは 2ms 未満:
[Azure 高可用性設計](https://www.slideshare.net/ssuser2602c6/azure-computing-3-1-sla-azure/32)
/ [de:code 2019資料](https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_CD14.pdf)
/ [横山さんの調査](https://yp.g20k.jp/2019/06/azureawsaz.html)

# データセンター内のメンテナンス

インフラのメンテナンス: 
[In-placeメンテナンスは通常10秒、最大30秒。Live Migrationメンテナンスは5秒。](https://eventmarketing.blob.core.windows.net/decode2019-after/decode19_PDF_CD14.pdf) (スライド24)

[インプレースマイグレーション時の一時停止の平均は13秒](https://eventmarketing.blob.core.windows.net/mstechsummit2018-after/CI31_PDF_TS18.pdf)
 (スライド12)

[メモリ保持メンテナンス時は仮想マシンの時計が自動的に同期される](https://eventmarketing.blob.core.windows.net/mstechsummit2018-after/CI31_PDF_TS18.pdf) (スライド19)


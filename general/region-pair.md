# ビジネス継続性とディザスター リカバリー (BCDR):Azure のペアになっているリージョン

■リージョンペア

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions

基本的に、1つの「地域（Geography）」で2個のリージョンがセットになっている。これを「リージョンペア」という。

```
地域
├リージョン
└リージョン
```

※「地域（Geography）」: 「日本」「英国」「北米（North America）」などの1つの国であるものがほとんどだが、「ブラジル」（ブラジル南部と米国中南部）、「アジア太平洋」（香港とシンガポール）、「ヨーロッパ」（アイルランドとオランダ）など、2つの国にまたがる地域（リージョンペア）もいくつか存在する。

リージョンペアの例

```
日本
┌東日本
└西日本

北米（North America）
┌米国東部リージョン
└米国西部リージョン

英国
┌英国西部リージョン
└英国南部リージョン

アジア太平洋
┌香港
└シンガポール
```

※北米の「米国東部」は、「米国西部3」のペアであり、「米国西部」のペアでもある。
```
米国西部3
 |ペア
米国東部
 |ペア
米国西部
```

※インドの「インド南部」は、「インド中部」のペアであり、「インド西部」のペアでもある。
```
インド中部
 |ペア
インド南部
 |ペア
インド西部
```

■リージョンペアの「更新」

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions#what-are-paired-regions
> Azure では、リージョン ペアに対してプラットフォームの更新 (計画メンテナンス) をシリアル化し、一度に更新されるリージョンが各ペアのうち 1 つのみになるようにしています。

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions#benefits-of-paired-regions
> 計画的な Azure システム更新プログラムは、ダウンタイム、バグの影響、および更新プログラムの不具合 (まれではありますが) による論理的な障害を最小限に抑えるために、ペア リージョンに (同時にではなく) 順番に展開されます。

```
日本
├東日本リージョン ※更新を実行
└西日本リージョン

   ↓

日本
├東日本リージョン ※更新完了
└西日本リージョン ※更新を実行
```

■リージョンペアの「復旧」

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions#what-are-paired-regions
> 停止（outage）によって複数のリージョンに影響がある場合、各ペアの少なくとも 1 つのリージョンが優先的に復旧されます。

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions#benefits-of-paired-regions
> 広範囲にわたって障害が発生した場合は、すべてのペアで一方のリージョンの復旧が優先されます。 ペア リージョンにまたがってデプロイされているアプリケーションについては、そのアプリケーションのリージョンのどちらかが必ず優先的に復旧します。

```
日本
├東日本リージョン ※災害などによる停止
└西日本リージョン ※災害などによる停止

   ↓東日本を優先して復旧した場合

日本
├東日本リージョン ※復旧
└西日本リージョン ※災害などによる停止
```

■リージョンペアのメリット

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions#must-i-use-azure-regional-pairs
> 複数のアクティブなリージョンをサポートするアプリケーションでは、可能な場合はリージョン ペアの両方のリージョンを使用することをお勧めします。 これにより、アプリケーションの最適な可用性が保証され、災害発生時の復旧時間が最小になります。

■リージョンの選択例

例: あるアプリケーションが2つのリージョンをアクティブ-アクティブで使用する。少なくとも1つのリージョンが稼働していればアプリケーションが稼働できる。AzureリージョンA, B, C, Dがあり、AとBがペア、CとDがペアのリージョンとなっている。2つのリージョンを選択する場合、どのリージョンを選択すればよいか。

→ ペアのリージョンである{A, B} または {C, D} を選ぶのがよい。

ペアではないリージョン、たとえば{A, C}を使用した場合:
- 可用性: 両方で同時にプラットフォームの更新が実行され、その影響を受ける可能性がある。
- 災害からの復旧: A, B, C, D全体が災害の影響を受けた場合、BとDが優先的に復旧され、AとCが後回しになる可能性がある。

■Azureのサービスでのペアの利用

ストレージアカウント
https://docs.microsoft.com/ja-jp/azure/storage/common/storage-redundancy#redundancy-in-a-secondary-region

GRS, RA-GRS, GZRS, RA-GZRSでは、データは、ペアのリージョンにレプリケートされる。

Azure Key Vault
https://docs.microsoft.com/ja-jp/azure/key-vault/general/disaster-recovery-guidance

キー コンテナーのコンテンツは、ペアのリージョンにレプリケートされる。

# Azure Load Balancer

https://docs.microsoft.com/ja-jp/azure/load-balancer/

- [OSI レイヤー 4](https://ja.wikipedia.org/wiki/OSI%E5%8F%82%E7%85%A7%E3%83%A2%E3%83%87%E3%83%AB)で動作するロードバランサー。
- TCPとUDPの負荷分散を行うことができる。
  - TCP
    - HTTP, FTP, SSH等
    - データベース接続等
  - UDP
    - SNMP, SIP, DHCP等
    - 音声・映像のストリーミング、ゲーム、IoT等

■歴史

2013/4 Windows Azure Infrastructure Services 登場、AzureでVM、仮想ネットワーク、**ロードバランサー** などが利用可能に
https://www.publickey1.jp/blog/13/windows_azureiaaswindows_azure_infrastructure_servicesamazon.html

2014/5/20 内部ロードバランサー が導入された
https://azure.microsoft.com/en-us/blog/internal-load-balancing/

2014/10/30 従来の「5タプルハッシュ」に加え、新しい分散モード「ソースIPアフィニティ」（セッションアフィニティ、クライアントIPアフィニティとも）が利用可能に
https://azure.microsoft.com/en-us/blog/azure-load-balancer-new-distribution-mode/

2018/3/22 Standardのロードバランサー 一般提供開始
https://azure.microsoft.com/en-au/updates/standardlbga/

2020/9/22 グローバル（リージョン間）ロードバランサー プレビュー
https://azure.microsoft.com/ja-jp/updates/preview-azure-load-balancer-now-supports-crossregion-load-balancing/

■ロードバランサー(Azure Load Balancer)

リソースの作成時に以下を構成する。

- 名前
- 地域（リージョン）
- 種類: 「パブリック」と「内部」
- SKU: 「Basic」と「Standard」
- レベル: 「地域」と「グローバル（リージョン間）」
- フロントエンドIP構成: パブリックIPアドレスを新規作成または選択
- バックエンドプール: 仮想マシンやVMSSを選択
- 負荷分散規則: 
  - 名前
  - フロントエンドIP・ポート
  - バックエンドプール・バックエンドポート
  - 正常性プローブ
  - セッション永続化

```
クライアント
↓要求
(LB)フロントエンドIP
↓
(LB)負荷分散規則（TCP 80番の着信をバックエンドプール1へ 等）
↓
(LB)バックエンドプール1
↓     ↓   ... クライアントからの要求を「セッション永続化」設定に従いルーティング
VM    VM  ... 各VMの正常性を「正常性プローブ」で監視
```

■ロードバランサーの種類

https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview

「パブリック」と「内部」の2種類がある。

パブリック ロード バランサー: インターネット トラフィックを VM に負荷分散
```
インターネット
↓
パブリックロードバランサー
↓
複数のVM
```

内部 ロード バランサー:仮想ネットワーク内でトラフィックを負荷分散

```
複数のVM
↓
内部ロードバランサー
↓
複数のVM
```

内部 ロード バランサーは、オンプレミスからの接続などでも利用できる。

```
オンプレミスのクライアント
↓VPN
VNet
└内部ロードバランサー
 ↓
 複数のVM
```

■ロードバランサーのSKU

https://docs.microsoft.com/ja-jp/azure/load-balancer/skus

2種類のSKUがある。スケール、機能、および料金の違いがある。

Basic Load Balancer で可能なシナリオはすべて、Standard Load Balancer で対応できる。

Microsoftは、Standard を推奨している。

- Basic
  - バックエンドプール最大数: 300
  - 可用性ゾーン非対応
  - SLA なし
  - グローバルVNetピアリング: サポートされない
  - 価格: 無料
- Standard
  - バックエンドプール最大数: 1000
  - 可用性ゾーンに対応
  - SLA 99.99%
  - グローバルVNetピアリング: サポート
  - 価格: 
    - 「ルール(負荷分散規則)」と「データ処理料」に応じた料金
    - 例: 5ルール、1TB、米国東部: 23.25ドル/月

※料金は [Azure料金計算ツール](https://azure.microsoft.com/ja-jp/pricing/calculator/) または [価格のページ](https://azure.microsoft.com/ja-jp/pricing/details/load-balancer/) を参照

Basicのロードバランサーは、パブリックロードバランサーへとアップグレードすることができる。
- パブリック
  - https://docs.microsoft.com/ja-jp/azure/load-balancer/upgrade-basic-standard
- 内部
  - https://docs.microsoft.com/ja-jp/azure/load-balancer/upgrade-basicinternal-standard
  - https://docs.microsoft.com/ja-jp/azure/load-balancer/upgrade-internalbasic-to-publicstandard

■ロードバランサーのレベル

「地域」と「グローバル（リージョン間）」の2種類がある。

「地域」ロードバランサー: 

- いわゆる普通のロードバランサー
- リージョン内で負荷分散

```
地域ロードバランサー
↓      ↓
VM1    VM2
```

「グローバル（リージョン間）」ロードバランサー: 

- [2022/9/22～ プレビュー](https://azure.microsoft.com/ja-jp/updates/preview-azure-load-balancer-now-supports-crossregion-load-balancing/)
- 複数リージョン間での負荷分散
- グローバルでトラフィックを受信し、複数のリージョンの「地域」ロードバランサーへ負荷分散
- TCPのみ
- バックエンドはパブリックロードバランサーのみ

```
グローバル（リージョン間）ロードバランサー
↓                        ↓
地域ロードバランサー      地域ロードバランサー
↓      ↓                 ↓      ↓
VM    VM                 VM     VM
```

クライアントからのトラフィックは、クライアントにもっとも近い、正常なリージョンへとルーティングされる。（「geo 近接負荷分散アルゴリズム」、「リージョン間ロード バランサーの正常性プローブ」）


■パブリックIPアドレス

パブリックIPアドレスにも2種類のSKUがある。BasicとStandard

パブリックのロードバランサーに組み合わせるパブリックIPアドレスのSKUは一致していなければならない。

```
パブリックIPアドレス SKU: Basic
＋
パブリックロードバランサー SKU: Basic
```
または
```
パブリックIPアドレス SKU: Standard
＋
パブリックロードバランサー SKU: Standard
```



■Azure Load Balancerの負荷分散のしくみ

https://docs.microsoft.com/ja-jp/azure/load-balancer/concepts

5種類の情報を使用する。

- 発信元（ソース）IP 
- 発信元（ソース）ポート
- 宛先IP
- 宛先ポート
- プロトコルの種類(TCP/UDP)

```
クライアント（送信元IP/送信元ポート）
↓
Azure Load Balancer（宛先IP/宛先ポート/プロトコル）
↓               ↓
バックエンドVM1  バックエンドVM2
```

5種類の情報から、ハッシュ値を計算し、バックエンドを選択する。

■分散モードと構成

https://docs.microsoft.com/ja-jp/azure/load-balancer/distribution-mode-concepts

ロードバランサーがルーティングを行う方法として、2つの「分散モード」がサポートされている。各「分散モード」はさらに「構成」がある。

全部で3つの「構成」がある。

- 分散モード: ハッシュベース (5タプル ハッシュ)
  - (1)構成: None (hash-based) 
- 分散モード: ソースIPアフィニティ
  - (2)構成: Client IP (source IP affinity 2 tuple)
  - (3)構成: Client IP and protocol (source IP affinity 3 tuple)

(1)分散モード「ハッシュベース」/構成「None」

- **5タプル** が使用される
  - 発信元（ソース）IP 
  - 発信元（ソース）ポート
  - 宛先IP
  - 宛先ポート
  - プロトコルの種類(TCP/UDP)
- **同じクライアント** からの連続した要求が、**任意の仮想マシン** によって処理される。


あるクライアントからの要求が、バックエンドの複数の仮想マシンで処理されてもかまわない場合は、これを利用する。

```
クライアント1
↓要求1(TCP) ↓要求2(TCP)
Azure Load Balancer
↓要求1(TCP)       ↓要求2(TCP)
バックエンドVM1    バックエンドVM2
```

(2)分散モード「ソースIPアフィニティ」 / 構成「Client IP」
- **2タプル** が使用される
  - 発信元（ソース）IP 
  - 宛先IP
- **同じクライアントIPアドレス** からの連続した要求が、**同じ仮想マシン** によって処理される。

あるクライアントからの要求が、バックエンドの同じ仮想マシンで処理されなければならない場合は、これを利用する。

```
クライアント1
↓要求1(TCP) ↓要求2(TCP)
Azure Load Balancer
↓要求1(TCP) ↓要求2(TCP)
バックエンドVM1           バックエンドVM2
```

ただし、同じクライアントからのTCPによる通信とUDPによる通信は、バックエンドの別の仮想マシンで処理される場合がある。

```
クライアント1
↓要求1(TCP) ↓要求2(UDP)
Azure Load Balancer
↓要求1(TCP)        ↓要求2(UDP)
バックエンドVM1     バックエンドVM2
```

(3)分散モード「ソースIPアフィニティ」 / 構成「Client IP and protocol」
- **3タプル** が使用される
  - 発信元（ソース）IP 
  - 宛先IP
  - プロトコルの種類(TCP/UDP)
- **同じクライアントIPアドレスとプロトコルの組み合わせ** からの連続した要求が、**同じ仮想マシン** によって処理される。


同じクライアントからの要求が、バックエンドの同じ仮想マシンで処理されなければならない場合は、これを利用する。

同じクライアントから、TCPによる通信とUDPによる通信が行われた場合でも、それらはバックエンドの同じ仮想マシンで処理される。

```
クライアント1
↓要求1(TCP) ↓要求2(UDP)
Azure Load Balancer
↓要求1(TCP) ↓要求2(UDP)
バックエンドVM1           バックエンドVM2
```

■Azure Load Balancerの内部コンポーネント

[まとめPDF](../AZ-104/pdf/mod06/ロードバランサー.pdf)

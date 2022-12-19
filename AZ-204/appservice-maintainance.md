# App Serviceの運用

■App ServiceにおけるOSの更新

https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime


Azure では、2 つのレベルで OS が管理される。

- 物理サーバー
  - [Windows Hyper-Vを基盤としている](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/hypervisor)
- App Service を実行するゲスト仮想マシン(VM)
  - ユーザーが選択したOS(Windows/Linux)

```
App Serviceアプリ
-----------------
 ゲスト仮想マシン ← OS
-----------------
   物理サーバー ← OS
```


- [セキュリティ更新プログラムは通常、米国日付の毎月第 2 火曜日に公開される。](https://msrc-blog.microsoft.com/2020/11/10/securityupdatereleaseschedule2021/)
- App Serviceも、このスケジュールに従って更新が適用される
- ゼロデイ脆弱性など、深刻な脆弱性に対して迅速にパッチを適用する必要がある場合、ケースバイケースで優先度の高い更新プログラムが適用される

このとき、[App Serviceの可用性が低下しない方法で、OS更新が実施される](https://satonaoki.wordpress.com/2018/01/25/demystifying-the-magic-behind-app-service-os-updates/)。

```
   App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v1) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v1)
```

アプリが動作していない利用可能なインスタンスをアップデート

```
   App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v2)
```

アップデート済みのインスタンスにアプリを移動（アプリはコールドスタートする）

```
                           App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v1)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v1)        物理サーバー2(v2)
```

アプリがなくなったインスタンスをアップデート

```
                           App Serviceアプリ
---------------------   ---------------------
 ゲスト仮想マシン1(v2)    ゲスト仮想マシン2(v2) 
---------------------   ---------------------
   物理サーバー1(v2)        物理サーバー2(v2)
```

■App Serviceの言語ランタイムの更新・追加・非推奨化・廃止

https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#when-are-supported-language-runtimes-updated-added-or-deprecated

[まとめ資料](pdf/mod01/App%20Serviceの「更新」.pdf)

サポートされる言語ランタイムの新しい安定バージョン (メジャー、マイナー、またはパッチ) は、App Service に定期的に追加される。

ランタイムの追加と廃止は以下で発表される。

- https://azure.microsoft.com/ja-jp/updates/?product=app-service
- https://github.com/Azure/app-service-announcements/issues

[Java](https://docs.microsoft.com/ja-jp/azure/app-service/configure-language-java?pivots=platform-linux#deprecation-and-retirement)については、影響を受けるランタイムを使用している Azure の開発者には、ランタイム終了の少なくとも 6 か月前までに廃止の通知が送信される。

アプリ側では、使用する言語ランタイムのバージョンを以下のようにして指定する。

```
az webapp config set --net-framework-version v4.7 
az webapp config set --linux-fx-version "DOTNETCORE|3.1"
az webapp config set --php-version 7.0 
az webapp config appsettings set --settings WEBSITE_NODE_DEFAULT_VERSION=8.9.3 
az webapp config set --python-version 3.8 
az webapp config set --java-version 1.8 --java-container Tomcat --java-container-version 9.0 
```

参考: 
- [ランタイムバージョンの指定](https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime#new-major-and-minor-versions)
- [.NET Coreバージョンの設定](https://docs.microsoft.com/ja-jp/azure/app-service/configure-language-dotnetcore?pivots=platform-linux#set-net-core-version)

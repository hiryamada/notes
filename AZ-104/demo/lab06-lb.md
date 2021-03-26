# ロードバランサーの動作検証例

WebとAP（アプリケーション・サーバー）の2層構成のWebアプリにおけるLBの動作検証。

# 全体の構成

VMのOSはUbuntuを選択。下記のIPアドレスは例。

```
インターネット(Webブラウザ) `http://20.194.181.232/` or `http://20.194.181.232/ap/` にアクセス
 ↓
パブリックLB(pub_lb) 20.194.181.232
 ↓
Webサーバー(web1) 10.0.0.5 
    ... '/' アクセス時、「web1」を表示。
    ... '/ap/' アクセス時、内部LBへ転送
 ↓
内部LB(internal_lb) 10.0.0.4
 ↓
APサーバー(ap1) 10.0.0.6 ... 「ap1」 を表示
APサーバー(ap2) 10.0.0.7 ... 「ap2」 を表示
```

# webサーバー(web1)の設定

```
apt-get update
apt-get install nginx
```

`/etc/nginx/sites-enabled/default` ... 編集

```
upstream backend {                       ... 追加
	server 10.0.0.4;                     ... 追加(内部LBのIPアドレス)
}                                        ... 追加

server {
	location /ap/ {                      ... 追加
		proxy_pass http://backend/;      ... 追加
	}                                    ... 追加
}
```

`/var/www/html/index.html`  ... 新規作成

```
web1
```

# apサーバー1(ap1)の設定

```
apt-get update
apt-get install nginx
```

`/var/www/html/index.html`  ... 新規作成

```
ap1
```

# apサーバー2(ap2)の設定

```
apt-get update
apt-get install nginx
```

`/var/www/html/index.html`  ... 新規作成
```
ap2
```

# 検証

`http://20.194.181.232/` にアクセスすると、「web1」が表示される。

`http://20.194.181.232/ap/` にアクセスすると、「ap1」または「ap2」が表示される。

※以下、ap1が表示されたとして説明。

ap1のnginxを停止。`service stop nginx`

`http://20.194.181.232/ap/` にアクセスすると、直後はnginxのエラーが表示されるが、10秒ほどするとap2に誘導されるようになる。

ap1の停止したnginxを再開。`service start nginx`

`http://20.194.181.232/ap/` にアクセスすると、ap2に誘導されつづける。

web1, ap1, ap2 のアクセスログを確認。`tail -f /var/log/nginx/access_log`

# 検証の結果わかること

web1のアクセス元は(パブリックLBではなく)Webブラウザである。

ap1/ap2のアクセス元は(内部LBではなく)web1である。

プローブ（デフォルトで5秒間隔、2回エラーで判定）が効いて、トラフィックが別VMに誘導されるまで少し時間がかかる。

LBのこの設定(5タプルハッシュ)では、ap1のnginxを再開しても、フェイルバックする動作は、行われない。

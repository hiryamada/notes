# Envoy

エンヴォイ（オンヴォイに聞こえる）

https://www.envoyproxy.io/

HTTP/2 と gRPC をサポートする、クラウドネイティブアプリ向けのサービスプロキシ。

# 概要

(1)サービスディスカバリー

```
コンテナー1＋サイドカー（Envoy)
                 |
コンテナー2＋サイドカー（Envoy)
```

コンテナーは、Envoyを経由して、別のコンテナー（サービス）に接続する。これにより、各コンテナーはEnvoyと通信すればよくなり、ネットワークの設定変更などに対応しやすくなる。

(2)エッジプロキシ

```
   外部ネットワーク
        ↓
       Envoy
   ↓       ↓
コンテナー   コンテナー
v1            v2
```

Nginxのような使い方ができる。Blue-Greenデプロイやカナリアリリースに対応できる。

# 参考

Lyft's Envoy: Embracing a Service Mesh（英語動画）
https://www.youtube.com/watch?v=55yi4MMVBi4

Lyft's Envoy: From Monolith to Service Mesh - Matt Klein, Lyft（英語動画）
https://www.youtube.com/watch?v=RVZX4CwKhGE

Envoy Proxyを始めてみよう
https://qiita.com/zakiyamac09/items/75d62e8b82456f180216

Envoy Proxyに入門した
https://i-beam.org/2019/01/22/hello-envoy/

新しいOSSプロキシ Envoy ことはじめ
https://dev.classmethod.jp/articles/envoy-proxy-getting-started/

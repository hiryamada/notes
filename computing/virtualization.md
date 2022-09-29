# 仮想化

■サーバー型仮想化

- 物理サーバー（ホストOS）の上で、複数の仮想サーバー（ゲストOS）を動かす
- ホスト型とハイパーバイザー型がある
  - ホスト型: OS上に土台となるソフトウェアをインストールし、そのソフトウェア上で仮想マシンを稼働させる方式
    - VMware Player、VMware Fusion、Windows 7 でのXPモードなど
  - ハイパーバイザー型: サーバーへ直接インストールし仮想マシンを稼働させる方式
    - ESXi、Hyper-V、Xen など

参考: https://thinkit.co.jp/story/2012/10/17/3722

■コンテナー型仮想化

- アプリケーションと、それが動くのに必要なランタイム・設定ファイル等を含む「コンテナー」を使用した仮想化
- ポータビリティが高い
  - サポートされた環境では、どの環境でも同じように動く
  - 環境の差異の影響を受けにくい
- コンテナーはOSを含まないため「軽量」
  - 省ディスク
  - 省メモリ
  - すばやく起動
- 1つのサーバー上で多数のコンテナーを実行できる
- 具体例
  - FreeBSD の Jail
  - Linux の LXC (Linux Containers)
  - Docker

参考: https://qiita.com/kentarosasaki/items/b44b5ffb57a69085027e

■Docker ドッカー

- コンテナー型仮想化を使用
- アプリケーションを開発・配置・実行するためのオープンプラットフォーム
- Docker社が開発
- 開発でよく使用されるOS、言語、ミドルウェア（DB等）をすぐに使用できる
  - Docker Hub: Docker社が運用するコンテナーレジストリ https://hub.docker.com/
- 開発環境には Docker Desktopをインストール
  - Docker Desktop: https://www.docker.com/products/docker-desktop/

```
Dockerfile ... イメージを作成するための定義ファイル
↓ 作成
イメージ ... ローカルのファイルシステムや「コンテナーレジストリ」に保存される
↓ 実行
コンテナー ... OSのプロセス
```

参考: Docker概要(Docker-docs-ja)
https://docs.docker.jp/get-started/overview.html

■Kubernetes クバネティス

- オープンソースのコンテナオーケストレーションシステム
- コンテナー化したアプリケーションのデプロイ、スケーリング、および管理を行う
- 元 Googleが開発
- 現在はCloud Native Computing Foundation (CNCF) がメンテナンス

参考: Kubernetesドキュメント
https://kubernetes.io/ja/docs/home/


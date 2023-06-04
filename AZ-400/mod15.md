# モジュール15 Docker

■参考ドキュメント

- [Docker ドキュメント日本語化プロジェクト](https://docs.docker.jp/)
- [Microsoft プラットフォームとツールでコンテナー化された Docker アプリケーションのライフサイクル](https://docs.microsoft.com/ja-jp/dotnet/architecture/containerized-lifecycle/)

## なぜコンテナーなのか。

図: [仮想マシンとコンテナーの比較](https://docs.docker.jp/v17.06/get-started/index.html#id6)

- 仮想マシン
  - ハイパーバイザー(Hyper-V, VMware, Xen, KVMなど)上で動作
  - 仮想マシンは、ゲストOS、アプリ、その動作に必要なバイナリ、ライブラリを含む
  - 物理マシンと同様、仮想マシンの運用・メンテが必要
    - OSの設定、パッケージのインストール、セキュリティパッチの適用など
  - サイズが大きい
- コンテナー
  - アプリと、その動作に必要なバイナリ、ライブラリを含む
  - 各コンテナーはホストOS上のプロセスのように動作
  - サイズが小さい
    - ネットワーク転送が高速
    - 省メモリで動作

■コンテナーのメリット

- 移植可能
  - どこでも動く
- 一貫性がある
  - 環境による違いが起きにくい
- 軽量
  - 1台のホストコンピュータ上で多数のコンテナーを運用できる
- 効率的
  - 起動が高速

## コンテナーの構造

■コンテナーとDockerの違い

- コンテナー：コンテナー型の仮想化技術
- Docker：コンテナーのランタイム

Dockerを使って、以下の作業を行う。
- コンテナー（のイメージ）を作成する。
- イメージからコンテナーを起動し、実行する。
- イメージをリポジトリにプッシュ・プルする。

■コンテナーの必要性

異なる環境で、同じコンテナーを確実に動かすことができる。

開発者の環境でコンテナーを開発
- → クラウドでコンテナーを実行
- → 別の開発者の環境でコンテナーを実行

環境による差異を受けにくい。たとえば環境によってPythonのバージョンが違う、といった問題を避けられる。

■コンテナーに含まれるもの

コンテナーには、アプリケーションの実行に必要なすべてのものが含まれている。

- アプリケーション
- 依存関係
- ライブラリ
- 他のバイナリ
- ランタイム

## Dockerコンテナーと開発

■Dockerとは

- [Dockerの公式サイト](https://www.docker.com/)
- [Docker今昔](https://speakerdeck.com/inductor/docker-kubernetes-through-the-ages)
- [Docker Desktop for Windows](https://hub.docker.com/editions/community/docker-ce-desktop-windows/)

■Docker Hubとは

- Docker 社が管理する公開（パブリックな）レジストリ
- コンテナーの構築に使えるイメージが置かれている
- さまざまな追加機能も提供
  - 自動化
  - ワークグループ
  - ウェブフック（webhooks）
  - 構築トリガ（build triggers）
  - プライベート・レポジトリ

- [Docker Hub](https://hub.docker.com/)
- Docker-docs-ja [Docker Hubにイメージを保管する](https://docs.docker.jp/engine/userguide/dockerrepos.html)

■レジストリとは

- レジストリの例
  - Docker Hub
  - Azure Container Registory

https://docs.docker.jp/engine/reference/glossary.html#registry

■リポジトリとは

- Dockerイメージの集まり
- レジストリでホスティングされる
- リポジトリの中のイメージはタグで区別される
- 例: [Nginxのリポジトリ](https://hub.docker.com/_/nginx)

https://docs.docker.jp/engine/reference/glossary.html#repository


## Dockerコンテナーの操作

[Dockerを使い始める](http://docs.docker.jp/v17.06/get-started/get-started.html)


## マイクロサービスとコンテナー

マイクロサービスを、コンテナーで実装することができる。

コンテナーを増やすことで容易にスケールアウトすることができる。

## Azure のコンテナー関連サービス

- [Azure Container Instances (ACI)](https://azure.microsoft.com/ja-jp/services/container-instances/)
- [Azure Kubernetes Service (AKS)](https://azure.microsoft.com/ja-jp/services/kubernetes-service/)
- [Azure Container Registory (ACR)](https://azure.microsoft.com/ja-jp/services/container-registry/)
- [Azure App Service](https://azure.microsoft.com/ja-jp/services/app-service/)
  - [コンテナーをデプロイすることができる](https://azure.microsoft.com/ja-jp/services/app-service/containers/)
- [Azure Service Fabric](https://azure.microsoft.com/ja-jp/services/service-fabric/)

## Docker コンテナーレジストリ

Azure Container Registory (ACR)

## マルチステージビルド

■概要

- イメージの作成作業を、複数のステージに分割
- 中間ステージから関連するディレクトリのみを取得する最終イメージを組み立てることができる。
- 最終イメージのサイズが小さくなる
  - 例 [Docker multi stage buildで変わるDockerfileの常識](https://qiita.com/minamijoyo/items/711704e85b45ff5d6405)
    - 257 MB -> 2.66 MB

[base, build, publish, final のような順で書かれる。](https://docs.microsoft.com/ja-jp/visualstudio/containers/container-tools?view=vs-2019#dockerfile-overview)
```
FROM ... AS base

FROM ... AS build
RUN dotnet build

FROM build AS publish
RUN dotnet publish

FROM base AS final
ENTRYPOINT ...
```

■ドキュメント
- [Dockerfile のマルチステージ ビルド](https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/docker-application-development-process/docker-app-development-workflow#multi-stage-builds-in-dockerfile)
- Docker-docs-ja [マルチステージビルドの活用](https://docs.docker.jp/engine/userguide/eng-image/multistage-build.html#:~:text=%E3%83%9E%E3%83%AB%E3%83%81%E3%82%B9%E3%83%86%E3%83%BC%E3%82%B8%E3%83%93%E3%83%AB%E3%83%89%E3%81%AF%E3%80%81Docker,%E9%9D%9E%E5%B8%B8%E3%81%AB%E3%81%82%E3%82%8A%E3%81%8C%E3%81%9F%E3%81%84%E3%82%82%E3%81%AE%E3%81%A7%E3%81%99%E3%80%82)


## Dockerfile のコア概念

[リファレンス](http://docs.docker.jp/v17.06/engine/reference/builder.html)

# 基本的な用語・概念

[コンテナー（コンテナー型仮想化）](https://www.google.com/search?q=%E3%82%B3%E3%83%B3%E3%83%86%E3%83%8A%E3%83%BC%E5%9E%8B%E4%BB%AE%E6%83%B3%E5%8C%96)

[Dockerについて](https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/container-docker-introduction/docker-defined)

[イメージ](https://www.slideshare.net/zembutsu/docker-images-containers-and-lifecycle/14)

[コンテナーレジストリ](https://www.google.com/search?q=%E3%82%B3%E3%83%B3%E3%83%86%E3%83%8A%E3%83%BC%E3%83%AC%E3%82%B8%E3%82%B9%E3%83%88%E3%83%AA)

[コンテナーオーケストレーション](https://www.redhat.com/ja/topics/containers/what-is-container-orchestration)

# Docker

[Docker ドキュメント日本語化プロジェクト](https://docs.docker.jp/)

[Docker概要](https://docs.docker.jp/get-started/overview.html)

[Dockerfileリファレンス](http://docs.docker.jp/v17.06/engine/reference/builder.html)

[Dockerfile 記述のベスト・プラクティス](http://docs.docker.jp/v17.06/engine/userguide/eng-image/dockerfile_best-practices.html)

[Docker Compose概要](https://docs.docker.jp/compose/overview.html)



# kubernetes

[Kubernetesドキュメント](https://kubernetes.io/ja/docs/home/)

[Kubernetesとは](https://kubernetes.io/ja/docs/concepts/overview/what-is-kubernetes/)

[Podの概観](https://kubernetes.io/ja/docs/concepts/workloads/pods/pod-overview/)

[etcd](https://etcd.io/)


[Helm](https://helm.sh/)


[Virtual Kubelet](https://github.com/virtual-kubelet/virtual-kubelet)


[KEDA: Kubernetes Event-driven Autoscaling](https://keda.sh/)


[containerd](https://containerd.io/)


# [Dockerfile のマルチステージ ビルド](https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/docker-application-development-process/docker-app-development-workflow#multi-stage-builds-in-dockerfile)

マルチステージ ビルドでは、作成作業を異なる "フェーズ" に分割し、中間ステージから関連するディレクトリのみを取得する最終イメージを組み立てることができます。 

https://docs.docker.jp/develop/develop-images/multistage-build.html

ざっくりと, [base, build, publish, final のような順で書かれる。](https://docs.microsoft.com/ja-jp/visualstudio/containers/container-tools?view=vs-2019#dockerfile-overview)
```
FROM ... AS base

FROM ... AS build
RUN dotnet build

FROM build AS publish
RUN dotnet publish

FROM base AS final
ENTRYPOINT ...
```

# Azure App Service


[解説PDF](../AZ-104-2023/pdf/Azure%20App%20Service.pdf)

公式サイト https://azure.microsoft.com/ja-jp/services/app-service/

ドキュメント https://docs.microsoft.com/ja-jp/azure/app-service/overview

料金 https://azure.microsoft.com/ja-jp/pricing/details/app-service/windows/

■概要

- Webアプリ、Web APIのホスティングのためのサービス
  - HTTP(S)ベースのアプリケーション（WebアプリやWeb API）を稼働させることができる。
- PaaS
  - VM（仮想マシン）の管理、OSの管理（アップデート）不要
  - 組み込みの言語ランタイムを利用可能、メンテナンス不要
- 実行環境は Windows / Linux から選べる
- Webアプリの開発とデプロイ
  - 開発者は、Visual Studio、Visual Studio Code、Eclipse、PyCharmなどを使用して、ローカルの開発環境でWebアプリ等を開発
  - 開発したアプリをApp Serviceに簡単にデプロイ
  - CI/CDにも対応 - Azure DevOps, GitHub Actions
- Dockerコンテナーのデプロイにも対応
- 組み込みのスケーリング機能
  - スケールアップ・スケールダウン
    - 性能と機能を選択
    - あとから変更もできる
  - スケールアウト・イン
    - VMスケールセットのような、負荷状況に合わせてインスタンス（VM）を増減させることができる機能も利用できる。
    - ロードバランサーの機能が組み込まれている。

■デプロイスロット

一つのアプリで複数の「デプロイスロット」を使用することができる。

初期状態:

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net)
```

「ステージング」(staging)という名前の「デプロイスロット」を追加した状態:

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net)
└ステージングスロット(example-staging.azurewebsites.net)
```

デプロイスロットは、それぞれ「～.azurewebsites.net」というFQDNを持つ。これらのFQDNを使用して、それぞれのデプロイスロットのアプリにアクセスできる。

デプロイスロットはそれぞれ独立して動作し、他のデプロイスロットの動作に影響を与えない。

たとえば、あるアプリで、「運用スロット」に、バージョン1(v1)のコードがデプロイされているとする。エンドユーザー（一般の利用者）は、「運用スロット」にアクセスして、このアプリを利用する。

```
App Service アプリ(example)
└運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
```

開発者は、「ステージングスロット」を追加し、そこにバージョン2(v2)のコードをデプロイし、動作を確認することができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v1 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v2 ← 開発者
```

動作確認が終わったら、開発者は「スワップ」（入れ替え）操作を実行して、v1とv2を入れ替えることができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v1 ← 開発者
```

エンドユーザーは、今までと同じFQDN（example.azurewebsites.net）を使用してアプリにアクセスすることができる。

開発者は、ステージングスロットを使用して、引き続き次のバージョン（v3）のデプロイと動作確認を行うことができる。

```
App Service アプリ(example)
├運用スロット(example.azurewebsites.net): v2 ← エンドユーザー
└ステージングスロット(example-staging.azurewebsites.net): v3 ← 開発者
```

※実際には、「スワップ」は、2つのスロットのルーティング規則を入れ替えることで行われる。（ドキュメントの[手順5番](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-staging-slots#swap-operation-steps)を参照）


# ラボ 7 - Azure Storageを管理する

ストレージアカウントを作成し、BlobとFilesを管理します。

## 動画

ラボの実施手順を記録した動画です。音声はありません。

AZ-104 ラボ07 Azure Storage を管理する(CloudSlice)
https://youtu.be/nGVGJ7JVemE

## 起動するラボの番号

ラボ11番を起動します。**7番ではありませんのでお気をつけください。**


## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_07-Manage_Azure_Storage.html

英語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator/Instructions/Labs/LAB_07-Manage_Azure_Storage.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - Cloud Shellを起動（PowerShellを選択）
    - **ここでは作成されているリソースグループを使用してストレージアカウントを作成します**
  - ARMテンプレートをアップロード
  - ARMテンプレートを使用してVM（仮想マシン）をデプロイ
- タスク2
  - ストレージアカウントを作成(冗長性: GRS)
  - 冗長性をLRSに変更
  - Blobのデフォルトのアクセス層をクールに変更
- タスク3
  - Blobコンテナーを作成
  - Blobをアップロード
- タスク4
  - BlobのURLでは、アクセス（ダウンロード）ができないことを確認
  - BlobのSAS URLを生成し、SAS URLではアクセス（ダウンロード）できることを確認
  - サインインしているユーザーに「ストレージBlobデータ共同作成者」ロールを割り当て
  - 認証方法を「Azure AD ユーザー アカウント」に切り替えて、アクセスができるようになることを確認
- タスク5
  - Azure Files ファイル共有を作成
  - ファイル共有に接続するためのスクリプトをVMで実行
  - VMで、ファイル共有内にフォルダーとファイルを作成し、ファイル共有で作成を確認
- タスク6
  - ストレージアカウントのファイアウォールを構成（自分のIPアドレスからしか接続できないようにする）
  - 自分のIPアドレスから、SAS URLで、Blobにアクセス（ダウンロード）できることを確認
  - Cloud Shell環境から、SAS URLではアクセス（ダウンロード）できないことを確認
- クリーンナップ（省略）

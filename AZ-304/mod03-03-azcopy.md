# AzCopy

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-v10

- Windows, macOS, Linuxに対応したコマンドラインツール
- Blob/Filesのデータ操作に特化
  - コンテナーの作成
  - ローカルからのファイルのアップロード
  - ストレージアカウント間でのコピー
  - 同期
  - [Amazon S3](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-s3), [Google Cloud Storage](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-azcopy-google-cloud)とのデータ転送
  - Azure Cloud Shellの中でも利用できる。


利用例:

```
# リソースグループを作成
$ az group create -n rg1 -l eastus
```

※ここで、新しいAzure ADユーザーを作成し、rg1のスコープで「ストレージ BLOB データ共同作成者」ロールを割り当てておく。

```sh
# ストレージアカウントを2つ作成
$ az storage account create -n st8888888 -g rg1 -l eastus
$ az storage account create -n st9999999 -g rg1 -l eastus

# ローカルにファイルを作成
$ echo hello > test.txt

# azcopyコマンドでログインする。デバイスコード認証が求められる。事前に作成したAzure ADユーザーでサインイン。
# 注: 
$ azcopy login
INFO: azcopy: A newer version 10.13.0 is available to download

To sign in, use a web browser to open the page https://microsoft.com/devicelogin and enter the code SSWCDGMT5 to authenticate.

# Blobコンテナーを作成
$ azcopy make https://st8888888.blob.core.windows.net/testcontainer
Successfully created the resource.

# ローカルのファイルをBlobコンテナーへコピー
$ azcopy copy test.txt https://st8888888.blob.core.windows.net/testcontainer/test.txt
INFO: Scanning...
INFO: Authenticating to destination using Azure AD

INFO: Any empty folders will not be processed, because source and/or destination doesn't have full folder support

Job 968a3b9d-248d-cd40-75e6-6370880438d1 has started
Log file is located at: /home/test/.azcopy/968a3b9d-248d-cd40-75e6-6370880438d1.log

0.0 %, 0 Done, 0 Failed, 1 Pending, 0 Skipped, 1 Total,

Job 968a3b9d-248d-cd40-75e6-6370880438d1 summary
Elapsed Time (Minutes): 0.0334
Number of File Transfers: 1
Number of Folder Property Transfers: 0
Total Number of Transfers: 1
Number of Transfers Completed: 1
Number of Transfers Failed: 0
Number of Transfers Skipped: 0
TotalBytesTransferred: 6
Final Job Status: Completed

# Blobコンテナーの内容を読み取り。
$ azcopy list https://st8888888.blob.core.windows.net/testcontainer
INFO: Authenticating to destination using Azure AD

INFO: test.txt; Content Length: 6.00 B

```

※sync（同期）を行うためにはSASトークンを使う必要がある

```
# SASトークンを取得するために、azコマンドでログインを行う。事前に作成したAzure ADユーザーでサインイン。
az login --use-device-code

# Blobコンテナーの読み取りを行うためのSASトークンを生成
$ sas=$(az storage container generate-sas --account-name st8888888 --name testcontainer --permissions lr  --expiry 2021-10-29 --auth-mode login --as-user --output tsv)

# sync（同期）を使用して、Blobコンテナーから別のBlobコンテナーへと内容を（再帰的に）同期。

$ azcopy sync https://st8888888.blob.core.windows.net/testcontainer/?$sas https://st9999999.blob.core.windows.net/testcontainer
INFO: Authenticating to destination using Azure AD
INFO: Any empty folders will not be processed, because source and/or destination doesn't have full folder support

Job 23911198-19ca-bf43-6109-74dd84cedfd1 has started
Log file is located at: /home/test/.azcopy/23911198-19ca-bf43-6109-74dd84cedfd1.log

INFO: azcopy: A newer version 10.13.0 is available to download

100.0 %, 0 Done, 0 Failed, 1 Pending, 1 Total, 2-sec Throughput (Mb/s): 0

Job 23911198-19ca-bf43-6109-74dd84cedfd1 Summary
Files Scanned at Source: 1
Files Scanned at Destination: 0
Elapsed Time (Minutes): 0.1
Number of Copy Transfers for Files: 1
Number of Copy Transfers for Folder Properties: 0
Total Number Of Copy Transfers: 1
Number of Copy Transfers Completed: 1
Number of Copy Transfers Failed: 0
Number of Deletions at Destination: 0
Total Number of Bytes Transferred: 6
Total Number of Bytes Enumerated: 6
Final Job Status: Completed

```

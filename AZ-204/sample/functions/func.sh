#!/bin/bash


# 以下、ローカルのbashから操作する例です。

# azコマンドでサインイン
az login

# 最新のfuncをインストール
npm install -g azure-functions-core-tools@3 --unsafe-perm true

# funcのバージョンを確認。
# 3.0.3568 となっていればOK
func --version

# コマンドで使われる変数を設定
RESOURCE_GROUP_NAME="rg134645635" # 変更してください
STORAGE_ACCOUNT_NAME="storage07684756" # 変更してください
APP_NAME="app985745763" # 変更してください
REGION="eastus"
FUNC_NAME="FileParser"

mkdir $FUNC_NAME
cd $FUNC_NAME

# 関数のプロジェクトを初期化する。
func init --worker-runtime dotnet

# 作成されたプロジェクトのフレームワークを確認。
# <TargetFramework>netcoreapp3.1</TargetFramework> となっていればOk
grep TargetFramework FileParser.csproj

# Blobアクセス用のパッケージを追加
dotnet add package Azure.Storage.Blobs

# 関数のコード FileParser.cs を作成する。
# 通常は、以下のコマンドで作成する
# func new --template "HttpTrigger" --name $FUNC_NAME --authlevel "anonymous"
# 今回は直接、FileParser.csを作成する。
cat <<EOF >$FUNC_NAME.cs
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public static class FileParser
{
	[FunctionName("FileParser")]
	public static async Task<IActionResult> Run(
		[HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request)
	{
		string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");
		BlobClient blob = new BlobClient(connectionString, "drop", "records.json");
		var response = await blob.DownloadAsync();
		return new FileStreamResult(response?.Value?.Content, response?.Value?.ContentType);
	}
}
EOF

# リソースグループを作る
az group create --name $RESOURCE_GROUP_NAME --location $REGION

# 関数アプリ用のストレージアカウントを作る。ファイルアップロード用のストレージアカウントも兼ねる。
az storage account create --name $STORAGE_ACCOUNT_NAME --location $REGION --resource-group $RESOURCE_GROUP_NAME --sku Standard_LRS

# 関数アプリを作る
az functionapp create --resource-group $RESOURCE_GROUP_NAME --consumption-plan-location $REGION --runtime dotnet --functions-version 3 --name $APP_NAME --storage-account $STORAGE_ACCOUNT_NAME

# 関数アプリが認識できるようになるまで少し待つ
sleep 30

# 関数アプリとしてパブリッシュする。
# （このコマンドでビルドも行われる. FileParser.dllが作られる）
func azure functionapp publish $APP_NAME

# ストレージアカウントのアクセスキーを取得
ACCESS_KEY=`az storage account keys list --resource-group $RESOURCE_GROUP_NAME --account-name $STORAGE_ACCOUNT_NAME --query '[].value|[0]' --output tsv`

# 接続文字列
CONNECTION_STRING="DefaultEndpointsProtocol=https;AccountName=$STORAGE_ACCOUNT_NAME;AccountKey=$ACCESS_KEY;EndpointSuffix=core.windows.net"

# 関数アプリのアプリケーション設定に、接続文字列を設定
az functionapp config appsettings set --name $APP_NAME --resource-group $RESOURCE_GROUP_NAME --settings "StorageConnectionString=$CONNECTION_STRING"

# records.jsonを作成
cat <<EOF >records.json
{"test":"hello,world"}
EOF

# Blobコンテナーを作成
az storage container create --account-name $STORAGE_ACCOUNT_NAME --name drop

# records.jsonをアップロード
az storage blob upload --account-name $STORAGE_ACCOUNT_NAME --container-name drop --name records.json --file records.json

# 起動用のURLを確認
# "invokeUrlTemplate": "https://app99982374502834.azurewebsites.net/api/fileparser"
# などが検索される。そのURLにアクセスすると、records.json が表示される。
az functionapp function show --name $APP_NAME --function-name $FUNC_NAME --resource-group $RESOURCE_GROUP_NAME |grep api

# 環境セットアップ

## Azure VMを起動

- リソースグループ: 新規作成、`labvm_group`
- 名前 `labvm`
- 場所（リージョン） `(Asia Pacific)Japan East`
- 可用性オプション: インフラストラクチャ冗長は必要ありません
- サイズ `Standard D4s v5`
- イメージ Windows Server 2022 Datacenter: Azure Edition - x64 Gen2
- ユーザー名: (任意)
- パスワード: (任意)

作成後、リソースに移動

接続＞RDPで、RDPファイルをダウンロードし、リモートデスクトップで接続します。

リモートデスクトップで接続ができない場合はAzure Bastionを使用して接続してください。

## タイムゾーンを日本標準時に設定

Windows PowerShellで、以下を実行。

```
tzutil /s "Tokyo Standard Time"
```

※コマンドは上記からコピーし、Windows PowerShellに貼り付けて、 **エンターキーを押してコマンドを実行してください。** 以下同様。

## Chocolateyのインストール

Windows PowerShellで、以下を実行。

```
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

## .NET 7.0 SDKのインストール

```
choco install -y dotnet-7.0-sdk
```

## Visual Studio Codeのインストール

```
choco install -y vscode
```

## Azure CLIのインストール

```
choco install -y azure-cli
```

## 環境変数PATHのリフレッシュ

```
Import-Module "$env:ChocolateyInstall\helpers\chocolateyProfile.psm1"
refreshenv
```

## Visual Studio CodeにC#拡張機能をインストール

```
code --install-extension ms-dotnettools.csharp
```

## Azure CLIを使用してAzureにサインイン（ログイン）

```
az config set core.allow_broker=true
az account clear
az login
```

コマンドを実行するとサインインが求められます。
トレーニング用に作成したMicrosoftアカウントでサインインします。

- Microsoft account をクリック、Continue
- トレーニング用に作成したMicrosoftアカウントのメールアドレスを入力、Next
- パスワードを入力、Sign in
- Stay signed in to all your apps → OK
- You're all set! → Done

## Webブラウザー(Edge)で、Azureにサインイン

- VM内でEdgeブラウザーを起動し
- https://portal.azure.com に接続
- サインインなしでAzure portalにサインインできるようになっているはずです。（Azure CLIのサインイン情報が使われる）
  - それでもサインインが求められた場合はトレーニング用に作成したMicrosoftアカウントでサインインしてください。
- 画面上部の歯車アイコンをクリック
- Language + region で、LanguageをEnglishから「日本語」に変更し、Apply、OK
- Azure portal表示が日本語化されます。


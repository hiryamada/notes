# デモ: コンソールアプリのDockerコンテナー化、ACRビルド、ACIでの実行

■準備

※本手順を実施するには以下のものが必要です。

- Visual Studio Code
- Visual Studio CodeのDocker拡張機能
- .NET SDK
- Azure CLI (az login でログインしておく）
- Git for Windows (同時にBashがインストールされます）

適当なフォルダを準備し、Visual Studio Codeでそのフォルダを開きます。

Visual Studio CodeのターミナルでBashを起動し、そこでコードを実行します。

■プロジェクトの作成

コンソールアプリのプロジェクトを作成します。

```sh
dotnet new console
```

続いて、`Program.cs`を以下のように変更します。

```cs
Console.WriteLine("version 1.0.0");
var now = DateTime.UtcNow.AddHours(9);
Console.WriteLine(now);
```

`dotnet run`で、実行してみます。バージョン番号`version 1.0.0`と、コンテナー実行時の日時が表示されます。

なお、日時は`DateTime.UtcNow` で取得されるUTC(協定世界時)に9時間を足して、JST(日本標準時)としています。これは、実行場所のタイムゾーン設定によらず、JSTの日時を取得するための、簡易的な措置です。

■Dockerfileの追加

Visual Studio Codeのコマンドパレットから `Docker: Add Docker Files to Workspace...` を選択します。（この機能はVisual Studio Codeの「Docker」拡張機能により提供されます）。

続いてDockerfileを作成するための質問に以下のように答えます。

|質問|入力する値|
|-|-|
|Select Application Platform|.NET: Core Console|
|Select Operating System|Linux|
|Include optional Docker Compose files?|No|

以上で.NETコンソールアプリ用の`Dockerfile`が自動生成されます。


■コンテナーレジストリを作成する

以下のコマンドでACRのコンテナーレジストリを作成します。

※下記の「app123456」の数字の部分は、適当な乱数で置き換えてください。

```sh
name=app123456
az group create -n $name
az acr create -n $name -g $name --sku Basic
```

■ユーザー割り当てマネージドIDの作成

ACIがACRからイメージをプル（取得）するために、ユーザー割り当てマネージドIDを使用します。

- ユーザー割り当てマネージドIDを作成する
- ユーザー割り当てマネージドIDのオブジェクトIDを取得する
- ACRのリソースIDを取得する
- ACRのスコープで、ユーザー割り当てマネージドIDに、`acrpull`ロールを割り当てる

以下のコマンドを実行します。

```sh
# ユーザー割り当てマネージドIDを作成
az identity create -n $name -g $name

# ユーザー割り当てマネージドIDのオブジェクトID
UMI_OBJECT_ID=$(az identity show \
-g $name -n $name --query principalId -o tsv)

# ACRのリソースID
SCOPE=$(az acr show -n $name -g $name --query id -o tsv)

# ユーザー割り当てマネージドIDにロールを割り当てる
az role assignment create \
--scope $SCOPE \
--role 'acrpull' \
--assignee-object-id $UMI_OBJECT_ID \
--assignee-principal-type ServicePrincipal
```

また、ユーザー割り当てマネージドIDのリソースIDを取得して、変数に入れておきます。この値は、あとでACIコンテナーグループを作成する際に使用します。

```sh
# ユーザー割り当てマネージドIDのリソースID
UMI_ID=$(az identity show -g $name -n $name --query id -o tsv)
```

■コンテナーレジストリでイメージをビルドする

現在のプロジェクトのソースコード一式とDockerファイルをコンテナーレジストリに送信してビルドします。ビルドされたイメージはコンテナーレジストリに格納されます。このイメージに`date:1.0.0`というタグを付けます。

```sh
az acr build -r $name -t date:1.0.0 .
```

■イメージをACIで実行する

ACIを使用して、コンテナーを実行します。

先ほどビルドしたイメージを`--image`オプションで指定します。

`--restart-policy`は、「再起動ポリシー」の指定であり、`Never`の場合は再起動を行いません（コンテナーの中のプログラムが停止したらコンテナーも停止します）。

`--assign-identity`は、このコンテナーグループに割り当てるマネージドIDを指定します。`--acr-identity`は、ACRのコンテナーレジストリからイメージをプルするのに使用するIDを指定します。これらのオプションの値として、前の手順で作成したユーザー割り当てマネージドIDを指定します。

■イメージをACIで実行する(バージョン1.0.0)

```sh
az container create -n $name -g $name \
--restart-policy Never \
--image $name.azurecr.io/date:1.0.0 \
--acr-identity $UMI_ID --assign-identity $UMI_ID
```

このコマンドの実行によりコンテナーグループが作成され、その中では1つのコンテナーが実行されます。

■コンテナーのログの表示

このコンテナー内で実行されたコマンドの出力を確認するには、`az container logs`を実行します。

```sh
az container logs -n $name -g $name
```

上記のコマンドを実行すると、バージョン`1.0.0`と、`01/08/2023 18:04:34`といった、コンテナーグループのログが表示されます。これは、コンテナー内で実行されたコンソールアプリから出力されたものです。

■コンテナーグループを再実行する

一度実行が完了したコンテナーグループを再実行するには以下のコマンドを実行します。

```sh
az container start -n $name -g $name
```

実行後、ログを確認すると、出力される日時が変化しており、再実行されたことが確認できます。

■イメージを更新して再実行する

現在のコードでは、ログに出力される日時が「月/日/年 時:分:秒」という形式になっています。これを「年/月/日 時:分:秒」と、年の位置を変えて出力するようにしましょう。

まずコードを以下のように書き直します。この修正は、バグの修正と位置づけることとし、パッチバージョンを上げて、`1.0.1`とします。


```cs
Console.WriteLine("version 1.0.1");
var now = DateTime.UtcNow.AddHours(9)
  .ToString("yyyy/MM/dd HH:mm:ss");
Console.WriteLine(now);
```

上記の「コンテナーレジストリでイメージをビルドする」のコマンドを再度実行し、ACR上に新しいイメージを作ります。タグは新しく `date:1.0.1` としています。


```sh
az acr build -r $name -t date:1.0.1 .
```
続いて、「イメージをACIで実行する」のコマンドを実行します。前回と違うのは`--image`で指定するイメージのバージョン番号だけです。

```
az container create -n $name -g $name \
--restart-policy Never \
--image $name.azurecr.io/date:1.0.1 \
--acr-identity $UMI_ID --assign-identity $UMI_ID
```

これで、新しいイメージがコンテナーグループに読み込まれて実行されます。

```
az container logs -n $name -g $name
```

上記のコマンドを実行すると、バージョン番号`version 1.0.1`と、`2023/01/08 19:05:16`といった日時が表示され、新しいバージョンが動作したことが確認できます。

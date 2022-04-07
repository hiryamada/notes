# VMにマネージドIDを割り当てる

![](images/ss-2022-04-07-12-43-08.png)

- Enter a name for the new virtual machine
  - testvm1
- Select an OS
  - Linux
- Select an image
  - Ubuntu Server 20.04 LTS
- Enter a username
  - azureuser
- Enter a passphrase for connecting to this virtual machine
  - 何も入れずにエンターキーを押す
- Select a location for new resources
  - Japan East

作成が終わるまでしばらく待つ。

作成されたVMを右クリックして「Connect to Host via Remote SSH」

![](images/ss-2022-04-07-12-48-29.png)

![](images/ss-2022-04-07-12-49-05.png)

![](images/ss-2022-04-07-12-49-45.png)

ターミナルを開く。

![](images/ss-2022-04-07-12-50-29.png)

以下のコマンドを投入。[参考](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http)

```
curl -H Metadata:true --noproxy "*" "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/" > noid.json
```

続いて、noid.json を開く。

```
code noid.json
```

![](images/ss-2022-04-07-13-02-46.png)

結果は

`{"error":"invalid_request","error_description":"Identity not found"}` 

となっている。つまり、マネージドIDが割り当てられていないので、トークンが取得できない。

![](images/ss-2022-04-07-13-00-13.png)

いったん、SSH接続されたVisual Studio Codeのウィンドウを閉じる。

![](images/ss-2022-04-07-13-04-57.png)

マネージドIDを割り当てるため、testvm1をAzure portalで開く。

![](images/ss-2022-04-07-13-05-53.png)

設定＞ID に移動。「システム割り当て済み」の「状態」で「オン」をクリックし、保存する。

![](images/ss-2022-04-07-13-07-50.png)

「はい」

![](images/ss-2022-04-07-13-08-43.png)

![](images/ss-2022-04-07-13-09-09.png)

![](images/ss-2022-04-07-13-09-26.png)


Visual Studio Codeに戻り、再度、「testvm1」に「Connect to Host via Remote SSH」で接続する。

![](images/ss-2022-04-07-12-48-29.png)

ターミナルを開く。

![](images/ss-2022-04-07-12-50-29.png)

再度、同様のコマンドを投入。[参考](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http)

```
curl -H Metadata:true --noproxy "*" "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/" > managedid.json
```

続いて、managedid.json を開く。

```
code managedid.json
```

今度は、以下のような結果となり、トークンが取得できていることが確認できる。

![](images/ss-2022-04-07-13-12-46.png)

`"access_token":"eyJ..."` の `eyJ` で始まる文字列をコピー。

https://jwt.ms/ に文字列を貼り付けると、この文字列をデコードし、トークンに含まれているクレームを確認することができる。

![](images/ss-2022-04-07-13-15-25.png)

トークンはAzure ADから発行されている。

![](images/ss-2022-04-07-13-21-28.png)

結論: VMに「マネージドID」を割り当てると、VM内から `http://169.254.169.254/metadata/identity/oauth2/token` にアクセスして、トークンを取得することができるようになる。
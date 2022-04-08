
# Azurite

Azure ストレージアカウントのエミュレータ。ローカルでの開発に便利。


mkcert-v1.4.3-windows-amd64.exe をダウンロード
https://github.com/FiloSottile/mkcert/releases

mkcert.exe にリネーム

c:/certディレクトリを作成してmkcert.exeを配置

.\mkcert.exe -install

127.0.0.1.pem と、 127.0.0.1-key.pem ができる。

VS Codeに、azurite拡張機能を入れる

Ctrl-, で、設定を出し、azurite で検索。

Azurite: Cert
```
c:/cert/127.0.0.1.pem
```


Azurite: Key
```
c:/cert/127.0.0.1-key.pem
```

あとは、画面下部の「[Azurite Blob Service]」をクリックしてAzuriteを起動。

以下のようなプログラムでAzurite に接続できる。

```c#
using Azure.Identity;
using Azure.Storage.Blobs;

var cred = new AzureDefaultCredential();
var uri = new Uri("https://127.0.0.1:10000/devstoreaccount1");
var client = new BlobServiceClient(uri, cred);

var containername = "container" + DateTime.Now.ToString("yyyyMMddHHmmss");
System.Console.WriteLine("creating container:" + containername);
client.CreateBlobContainer(containername);

System.Console.WriteLine("listing container");

foreach (var blobcontainer in client.GetBlobContainers()) {
    System.Console.WriteLine(blobcontainer.Name);
}
```
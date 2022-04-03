# ハンズオン: ストレージアカウントを作成する

Azure拡張機能をクリックする。STORAGE内のAzureサブスクリプションを右クリックし、「Create Storage Account...(Advanced)」をクリックする。

![](images/ss-2022-04-03-17-57-21.png)

「Enter a globally unique name ...」: ストレージアカウントの適当な名前を入力。`st`＋ランダムな数 など。

![](images/ss-2022-04-03-17-59-56.png)

「Select a resource group...」: 「＋Create new resource group」

![](images/ss-2022-04-03-18-00-47.png)

ストレージアカウント名と同じリソースグループ名がデフォルトで入力される。エンターキーを押す。

![](images/ss-2022-04-03-18-01-12.png)

No

![](images/ss-2022-04-03-18-01-54.png)

「Select a location ...」→「East US」

![](images/ss-2022-04-03-18-03-29.png)

画面右下に「Creating...」と出る。しばらく待つ。

![](images/ss-2022-04-03-18-02-38.png)

STORAGE内のAzureサブスクリプションを展開すると、作成したストレージアカウントが追加されている。

※「cs～～」というストレージアカウントは、Azure portalでCloud Shellを使用した際に作成されるもの。

![](images/ss-2022-04-03-18-04-22.png)

ストレージアカウントの中の「Blob Containers」を右クリックし、Create Blob Container...をクリック。

![](images/ss-2022-04-03-18-06-59.png)

「images」と入力。

![](images/ss-2022-04-03-18-08-03.png)

imagesコンテナーが作成された。

![](images/ss-2022-04-03-18-08-43.png)


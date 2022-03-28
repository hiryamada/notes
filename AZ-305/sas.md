# 共有アクセス署名 (Shared Access Signature, SAS)

■アクセスキーとは？

```
ストレージアカウント
└Blobコンテナー
  └Blob（画像ファイル）
    ↑Blobにアクセス
クライアント（ストレージアカウントの「アクセスキー」）
```

ストレージアカウントから振り出される「アクセスキー」を持つクライアントは、そのストレージアカウントのBlob、ファイル共有、テーブル、キューに対するフルアクセスが可能。

■SASとは？

```
ストレージアカウント
└Blobコンテナー
  └Blob（画像ファイル）
     ↑SASを使用してBlobにアクセス（Blobのダウンロード・アップロード等）
     モバイルアプリ
     ↑「SAS」を発行
SASを発行するサーバー（ストレージアカウントの「アクセスキー」）
```

上の図で、「モバイルアプリ」は「アクセスキー」を持たないが、「SASを発行するサーバー」は「アクセスキー」を持つ。

「SASを発行するサーバー」は、「アクセスキー」を使って、「SAS」を発行することができる。

「SAS」の発行時に、有効期限、許可される操作（読み取り・書き込み等）などを指定する。

「モバイルアプリ」は、受け取った「SAS」を使用することで、Blobに一時的・限定的にアクセスすることができる。

基本的に、「SAS」発行時は、充分に短い有効期限を指定し、不要な許可は与えない。

基本的に、いったん発行された「SAS」はあとから変更することはできない。※「アクセスポリシー」を使用すると、発行した「SAS」を取り消したり、有効期限を変更したりすることができる。

■たとえ: ホテルのカードキー

```
ホテルの部屋
↑カードキーを使って部屋に入室
宿泊客
↑カードキーを発行
フロント
```

カードキーを使って、許可された部屋にのみ入室できる。カードキーには有効期限がある。

SASはカードキーに例えることができる。

■委任 (delegate)

SASは「委任」を行うための仕組み。

> 委任: 仕事などを、他人にまかせること。(デジタル大辞泉)

https://kotobank.jp/word/%E5%A7%94%E4%BB%BB-762

> A shared access signature (SAS) provides secure delegated access to resources in your storage account. (共有アクセス署名（SAS）は、ストレージアカウントのリソースへの安全な委任アクセスを提供します。)

https://docs.microsoft.com/en-us/azure/storage/common/storage-sas-overview

```
Blob
↑SASを使って、限定的なアクセスを行う
モバイルアプリ
↑SAS: ダウンロードなどの一部の操作を「委任」（許可）する
SASを発行するサーバー
```

■SASの生成方法(Azure portal)

![](images/ss-2022-03-28-19-48-42.png)

Blobの「SASの生成」タブを選択。アクセス許可、有効期限などを指定し、「SASトークンおよびURLを生成」をクリックする。

■「SASトークン」と「SAS URL」

「SASトークン」の例: アクセス許可や有効期限などの情報を含む。電子署名されているため改ざんはできない。
```
sp=r&st=2022-03-28T10:47:45Z&se=2022-03-28T18:47:45Z&spr=https&sv=2020-08-04&sr=b&sig=ydbm15fenTfXnd7qbQl0zwA1VRfns27tqzlcjwZmFdk%3D
```

「SAS URLの例」: 通常のBlobのURLの後ろに「?」と「SASトークン」が付いたもの。
```
https://storage12345.blob.core.windows.net/images/cat.jpg?sp=r&st=2022-03-28T10:47:45Z&se=2022-03-28T18:47:45Z&spr=https&sv=2020-08-04&sr=b&sig=ydbm15fenTfXnd7qbQl0zwA1VRfns27tqzlcjwZmFdk%3D
```

■参考: SASの種類

```
SAS
├アカウントSAS
├サービスSAS
└ユーザー委任SAS
```

- [アカウントSAS](https://docs.microsoft.com/ja-JP/rest/api/storageservices/create-account-sas)
  - 生成方法: アクセスキーを使って生成する。
  - 委任の範囲: ストレージアカウント内の複数のサービスへのアクセスを委任する。
  - 「保存されているアクセスポリシー」: 使用不可
- [サービスSAS](https://docs.microsoft.com/ja-jp/rest/api/storageservices/create-service-sas)
  - 生成方法: アクセスキーを使って生成する。
  - 委任の範囲: Blob、Queue、Table、または File サービスのいずれか1つのストレージサービスのリソースへのアクセスを委任する。
  - 「保存されているアクセスポリシー」: **使用可能**
- [ユーザー委任SAS](https://docs.microsoft.com/ja-jp/rest/api/storageservices/create-user-delegation-sas)
  - 生成方法: 各ユーザーが取得できる「ユーザー委任キー」を使って生成する。
  - 委任の範囲: Azure Blob Storage （または Azure Data Lake Storage Gen2）へのアクセスを委任する。
  - 「保存されているアクセスポリシー」: 使用不可

■参考: Azure Data Lake Storage Gen2

https://docs.microsoft.com/ja-jp/azure/storage/blobs/data-lake-storage-introduction

Azure Blob Storage をベースに構築された、ビッグ データ分析専用の一連の機能。

ふつうのストレージアカウントを作成する途中で [「階層型名前空間を有効にする」にチェックを入れる](https://docs.microsoft.com/ja-jp/azure/storage/blobs/create-data-lake-storage-account#enable-the-hierarchical-namespace) ことで、そのストレージアカウントをAzure Data Lake Storage Gen2として使用できるようになる。

■参考: 「バレットキー」パターン

https://docs.microsoft.com/ja-jp/azure/architecture/patterns/valet-key

SASはこのパターンに該当する。

> バレー［バレット］キー◆車の鍵の一種。バレーサービス（駐車代行）の係員に渡すことを主目的としたもの。ドア解錠・エンジン始動などの、駐車に必要な最小限の機能だけを持つ。この鍵ではトランクなどを開けられないので、所持品を盗まれたり勝手に使われたりするリスクが減る。

https://eow.alc.co.jp/search?q=valet+key
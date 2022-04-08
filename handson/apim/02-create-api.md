# ハンズオン: API Management内にAPIを作成する

バックエンドとして[天気予報API](https://weather.tsukumijima.net/)を利用。

- [東京(場所コード:130010)](https://weather.tsukumijima.net/api/forecast/city/130010)
- [大阪(場所コード:270000)](https://weather.tsukumijima.net/api/forecast/city/270000)
- [場所コード（「一次細分区域」id）の一覧](https://weather.tsukumijima.net/primary_area.xml)

※「東京」などにアクセスして動作を確認。

![](images/ss-2022-04-08-08-39-08.png)

（作成したリソース）に移動。

Azure portal＞API Management＞ apim(乱数)

![](images/ss-2022-04-08-08-35-27.png)

画面左メニューの「API」をクリック

![](images/ss-2022-04-08-08-35-49.png)

Azure portalからAPI Managmentインスタンスを作成した場合「Echo API」というサンプルが登録されているが、不要なので削除する。

![](images/ss-2022-04-08-08-36-59.png)

![](images/ss-2022-04-08-08-37-20.png)

Add APIをクリック

![](images/ss-2022-04-08-08-37-47.png)

- HTTP

![](images/ss-2022-04-08-08-38-18.png)

- Display name: tenki
- Name: tenki
- Web service URL: 
  - 上記で調べた天気予報APIのURL
  - 「東京」の場合: https://weather.tsukumijima.net/api/forecast/city/130010
- Createをクリック

![](images/ss-2022-04-08-08-40-45.png)

tenkiというAPIが追加される

![](images/ss-2022-04-08-08-41-10.png)

- All APIsの下のtenkiをクリック
- Add operationをクリック
  - Display name: tokyo
  - Name: tokyo
  - URL: GET, /
  - Saveをクリック

![](images/ss-2022-04-08-08-42-27.png)

「tokyo」というオペレーションが追加される

![](images/ss-2022-04-08-08-43-05.png)

- All APIsの下のtenkiの脇の「...」をクリック
- Add Versionをクリック

![](images/ss-2022-04-08-08-43-37.png)

- Version identifier: v1
- Full API version name: tenki-v1

![](images/ss-2022-04-08-08-45-02.png)

- Products: StarterとUnlimitedを選択

![](images/ss-2022-04-08-08-45-46.png)

- Createをクリック

All API の tenki の下に、Originalと、v1が表示される

![](images/ss-2022-04-08-08-46-57.png)


# ラボ2


## `Plugins/ConvertCurrency/currencies.txt`

タブ区切りで以下のような通貨レート情報が記載されている。
```
JPY	Japanese Yen	147.2838795517749	0.0067896093112380885
```
通貨コード、通貨名、1ドルあたりのJPY、1 JPYあたりのドル

## `Plugins/ConvertCurrency/Currency.cs`

上記の通貨レート情報を記録するクラス。

クラスのオブジェクトには通貨名（Name）、1ドルあたりのJPY（UnitsPerUSD）、1 JPYあたりのドル（USDPerUnit）が記録される。

クラスの Currencies プロパティを通じて、通貨レート情報にアクセスできる。

```c#
Currency.Currencies["JPY"].Name => Japanese Yen
Currency.Currencies["JPY"].UnitsPerUSD => 147.2838795517749
Currency.Currencies["JPY"].USDPerUnit => 0.0067896093112380885
```

## `Prompts/GetIntent`

ユーザーの入力から `ConvertCurrency` といったインテント（意図）を推測する。

```
ConvertCurrency - ユーザーが 1 つの通貨の金額を別の通貨に換算したい場合
SuggestDestinations - ユーザーが目的地のおすすめを希望する場合
SuggestActivities - ユーザーが特定の目的地でのアクティビティのおすすめを希望する場合
Translate - ユーザーが特定のテキストを別の言語に翻訳したい場合
HelpfulPhrases - ユーザーが特定の言語でよく使われるフレーズを知りたい場合
Unknown - ユーザーの意図が上記のいずれにも一致しない場合
```

- input:
  - input: ユーザーの入力
- output:
  - Intent

※ skprompt.txt の中では `{{$input}}` のほかに `{{$user}}`  `{{$bot}}` といった記述もあるが、これらは input に含まれない。単に「ユーザーとボットの会話例」を示すのに使用されている。

## `Prompts/LanguageHelper/GetHelpfulPhases`

特定の言語でよく使われるフレーズ（あいさつなど）のリストを推奨する。

- input: 
  - history: ユーザーのバックグラウンド情報
  - language: フレーズの言語
- output:
  - list of phrases

## `Prompts/LanguageHelper/GetTranslation`

翻訳を行う

- input:
  - language
  - input
- output:
  - 翻訳された文章

## `Prompts/SuggestActivities`

Suggest activities and points of interest(POI) at a given destination
特定の目的地でのアクティビティや興味のあるポイント（POI）を提案します

- input:
  - destination: 行きたい場所
- output:
  - activities and POI

## `Prompts/SuggestDestinations`

Suggest some travel destinations
旅行先を提案する

- input:
  - input: ユーザーのバックグラウンド情報
- output:
  - travel destinations



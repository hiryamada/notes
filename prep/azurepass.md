# Azure Pass サブスクリプションの有効化

## 事前の準備

- 今回のコース用に新しく作成したMicrosoftアカウント。まだ準備していない場合は[こちらの手順](msa.md)に従ってご準備ください。
- [演習環境 - Learn on Demand LMS (LODS)](https://tsfb.learnondemand.net/)で入手したPromo Code。まだPromo Codeを入手していない場合は、[こちらの手順](lods.md)に従ってPromo Codeを入手してください。

## 手順

[画面写真付きの手順](https://www.microsoftazurepass.com/Home/HowTo)もご利用いただけます（英語）。

- InPrivate ウィンドウを開きます。
  - Edge: [InPrivate ウィンドウ](https://support.microsoft.com/ja-jp/microsoft-edge/microsoft-edge-%E3%81%A7-inprivate-%E3%83%96%E3%83%A9%E3%82%A6%E3%82%BA%E3%82%92%E4%BD%BF%E3%81%86-e6f47704-340c-7d4f-b00d-d0cf35aa1fcc)を開きます。ショートカット キー: Ctrl + Shift + N
  - Chrome: [シークレット ウィンドウ](https://support.google.com/chrome/answer/95464)を開きます。
  - Firefox: [プライベート ウィンドウ](https://support.mozilla.org/ja/kb/private-browsing-use-firefox-without-history)を開きます。
  - Safari: [プライベートブラウズ ウィンドウ](https://support.apple.com/ja-jp/guide/safari/ibrw1069/mac)を開きます。
- InPrivate ウィンドウで、[Azure Pass](https://www.microsoftazurepass.com/)にアクセスします。
- ページ内のStartボタンをクリックします。
- 今回のコース用に作成したMicrosoftアカウントでサインインします。
- 「Confirm Microsoft Account」ボタンをクリックします。
- 前の手順で入手したPromo Codeを入力し、「Claim Promo Code」（プロモーションコードの要求）をクリックします。
- 「We are processing your request」というページが出ます。**画面の指示に従い、「リロード」や「戻る」操作をせず、画面が切り替わるまで待ちます**。
- 「Azure Pass - Sponsorship」ページで、氏名などの情報を入力します。
- 「Subscription Agreement」に同意するためのチェックボックスにチェックを入れます。
- 「Sign Up」をクリックします。
- Azure Portalの画面が表示されます。
- 以上で、Microsoftアカウントに、「Azure Pass - スポンサー プラン」というAzureサブスクリプションが作られました。
- このInPrivateウィンドウ（シークレットウィンドウ、プライベートウィンドウ）は閉じてもかまいません。

これで、お作りになったMicrosoftアカウントで [Azure portal](https://portal.azure.com/) にサインインし、有効化したAzure Passサブスクリプションを使用して、ラボを実施することができます。

このサブスクリプションの有効期限や、クレジットの残高は、[Microsoft Azure Sponsorship クレジット残高](https://www.microsoftazuresponsorships.com/balance)のページで確認できます。

## 注意

Azure Passサブスクリプションの有効化は、1つのMicrosoftアカウントに対して1回だけ実行できます。トレーニング開始時に、1回だけ実施していただければOKです。

## トラブルシューティング

エラーメッセージ「Try again later - Sorry there's something templrarily wrong with this site.」

- 原因：
  - このMicrosoftアカウントで、Azure Passサブスクリプションの有効化に失敗している状態です。（失敗したけれども、すでに有効化が行なわれたと、Azure Passのシステム側で判断されてしまっています。）
  - または、このMicrosoftアカウントで、すでに有効化が行なわれています。
- 対処：
  - Microsoftアカウントをサイン アウトします。
  - 別のMicrosoftアカウントを作り直してください。
  - 作り直したアカウントで、再度、Azure Pass サブスクリプションの有効化を行ってください。

エラーメッセージ「This promo code has already been redeemed by another user. Please contact your Microsoft representative for a new Azure Pass promo code.」

- 原因：
  - このPromo Codeはすでに使用済みとなっていて、使用できません。
  - 新しいPromo Codeを作るところからやり直す必要があります。
- 対処：
  - Microsoftアカウントをサイン アウトします
  - 別のMicrosoftアカウントを作り直してください
  - 作り直したアカウントで、[演習環境 - Learn on Demand LMS (LODS)](lods.md)にサイン インし、ラボを起動して、Promo Codeを再取得してください
  - 作り直したアカウントで、Azure Pass サブスクリプションの有効化を行ってください。


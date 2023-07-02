# ラボ 01 - Azure Active Directory ID を管理する

Azure ADのテナントを作成し、ユーザー・グループを作成します。

## 動画

ラボの実施手順を記録した動画です。音声はありません。

AZ-104 ラボ01 Azure Active Directory ID を管理する(CloudSlice)
https://youtu.be/xusxWEoABOY

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_01-Manage_Azure_AD_Identities.html

英語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator/Instructions/Labs/LAB_01-Manage_Azure_AD_Identities.html

## 起動するラボの番号

ラボ1番を起動します。

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
  - 演習用の新しいテナント(test～～)を作成
- タスク1
  - ユーザーを作成
- タスク2
  - Azure AD Premium P2ライセンスを有効化
  - グループを作成
- タスク3
  - 演習用の新しいテナント(Contoso Lab)を作成
- タスク4
  - Contoso Labテナントでユーザーを作成
  - 元のテナント(test～～)に、Contoso Labテナントのユーザーを招待
  - 招待したユーザーをグループに追加
- タスク5: 省略。

```
■最初にサインインするテナント
└ラボ環境の「リソース」タブに表示されたユーザー

■演習用の新しいテナント(FirstAAD)
├ユーザー: az104-01a-aaduser1
├ユーザー: az104-01a-aaduser2
├グループ: IT クラウド管理者
├グループ: IT システム管理者
└グループ: IT ラボ管理者

■演習用の新しいテナント(Contoso Lab)
└ユーザー: az104-01b-aaduser1
```

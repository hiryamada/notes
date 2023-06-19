# ラボ 01 - Azure Active Directory ID を管理する

Azure ADのテナントを作成し、ユーザー・グループを作成します。

## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00.md)

## 手順書

https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_01-Manage_Azure_AD_Identities.html

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

■演習用の新しいテナント(test～～)
├ユーザー: az104-01a-aaduser1
├ユーザー: az104-01a-aaduser2
├グループ: IT クラウド管理者
├グループ: IT システム管理者
└グループ: IT ラボ管理者

■演習用の新しいテナント(Contoso Lab)
└ユーザー: az104-01b-aaduser1
```

## 動画

ラボの実施手順を記録した動画です。

音声はありません。

- AZ-104 ラボ1 タスク1 https://youtu.be/o7qsQM9b5XE
- AZ-104 ラボ1 タスク2 https://youtu.be/tS6hu01lsh4
- AZ-104 ラボ1 タスク3-4 https://youtu.be/BdXQDlJc6yc

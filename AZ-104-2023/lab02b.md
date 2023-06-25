# ラボ 02b - Azure Policy を介してガバナンスを管理する

Azure Policyを割り当て、その効果を確認します。

## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00.md)

## 手順書

https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_02b-Manage_Governance_via_Azure_Policy.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - Cloud Shellを起動
  - リソースグループにタグを付ける
  - リソースグループ内のリソースに、タグが継承されないことを確認
- タスク2
  - リソースグループに、タグ付けを強制するポリシーを割り当て
  - 新しいストレージアカウントを作成しようとすると、ポリシーにより、ストレージアカウントの作成が失敗することを確認
- タスク3
  - タグ付けを強制するポリシーを削除
  - リソースグループからタグを継承するポリシーを作成
  - 新しいストレージアカウントを作成
  - ストレージアカウントに、リソースグループから継承されたタグが付与されていることを確認
- タスク4
  - クリーンナップ（省略）

## 動画

ラボの実施手順を記録した動画です。

音声はありません。

- AZ-104 ラボ2b https://youtu.be/tfhnYEPWWZM
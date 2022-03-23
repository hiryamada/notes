■Datavarseとは

https://docs.microsoft.com/ja-jp/powerapps/maker/#dataverse

Dataverse は、Power Apps に付属しているデータ プラットフォームです。

ビジネス データの格納とモデリングを行うことができます。 

**Dynamics 365 アプリ (Dynamics 365 Sales、Customer Service、Field Service、Marketing、Project Service Automation など) を構築するためのプラットフォームです。 Dynamics 365 をご利用のお客様の場合、データは既に Dataverse 内にあります。**

Dataverse を使用して、一連の標準テーブルとカスタム テーブル内にデータを安全に格納し、管理できます。また、必要に応じてそれらのテーブルに列を追加できます。

https://docs.microsoft.com/ja-jp/powerapps/maker/data-platform/data-platform-intro

2020/11 Common Data Service は Microsoft Dataverse に名称が変更されました。


■テーブルのビジネス ルール

- 列の値を設定する
- 列の値をクリアする
- 列の要件レベルを設定する
- 列を表示または非表示にする
- 列を有効化または無効化する
- データを検証し、エラー メッセージを表示する
- ビジネス インテリジェンスに基づいてビジネス レコメンデーションを作成


■ロールアップ列

https://docs.microsoft.com/ja-jp/powerapps/maker/data-platform/define-rollup-fields

https://docs.microsoft.com/ja-jp/powerapps/developer/data-platform/calculated-rollup-attributes#rollup-columns

ロールアップ列はデータベースで保持されるため、通常の列と同様にフィルタリングや並べ替えに使用できます。

既定では、各列は毎時間更新されます。


■計算列（Calculated Columns）


https://docs.microsoft.com/ja-jp/powerapps/developer/data-platform/calculated-rollup-attributes#calculated-columns

計算列は、取得時にリアルタイムで計算されます。

https://docs.microsoft.com/ja-jp/powerapps/maker/data-platform/define-calculated-fields

計算列を使用して、ビジネス プロセスで使用される手動の計算を自動化することができます。

■フォームのオートセーブ（自動保存）

https://docs.microsoft.com/ja-jp/powerapps/maker/model-driven-apps/manage-auto-save#how-auto-save-works

既定で、更新されたテーブルと従来のテーブル のメイン フォームすべてで自動保存が有効です。 

行の作成 (最初の保存) の後、フォームに対する変更は変更の 30 秒後に自動的に保存されます。

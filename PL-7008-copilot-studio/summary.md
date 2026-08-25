# PL-7008: Microsoft Copilot Studioでエージェントを作成する

このコースでは以下について解説しました

## 1. 環境構築編

- Copilot Studioを利用するには、Power Platform環境に Dataverse が必要。エージェントは環境内の ソリューション に保存される。
- Power Platformの基本構成は以下の3層で理解する。 
  - 環境（Environment）
  - Dataverse
  - ソリューション（Solution）
- デフォルト環境（Contoso）にDataverseを追加し、Copilot Studioを利用可能にする。
- Copilot Studioには Classic Experience と New Experience があり、必要に応じて切り替えられる。
- 新しい開発用環境（dev-jpn-xxx）をDataverse付きで作成する。
- 開発用環境内に Lab Exercises ソリューション を作成し、優先ソリューションに設定する。
- 今後のエージェントやテーブルは開発用環境のソリューション内で管理する。


## 2. エージェント作成編

Dataverse テーブル作成

- Power Apps（make.powerapps.com）でDataverseテーブルを作成する。
- Copilotを使い自然言語からテーブルを生成できる。
- 「商品テーブル」を作成し、商品名・説明文・価格列を定義する。

エージェント作成

- Copilot Studioで「商品管理エージェント」を作成する。
- プライマリ言語を日本語に設定する（保存後は変更不可）。
- 指示（Instructions）を設定してエージェントの役割を定義する。

ツール追加

- Microsoft Dataverseツールを追加する。
- 「選択した環境の行を一覧表示する」ツールを設定し、商品一覧を取得できるようにする。
- 「選択した環境に新しい行を追加する」ツールを設定し、商品追加を可能にする。
- 認証モードは「作成者（Maker）」を利用する。

ナレッジ

- エージェントにはWord、PDF、Webサイトなどのナレッジを接続できる。
- 既定では「すべてのWebサイトを検索する」が有効。
- 特定サイトのみを検索対象に限定することもできる。


## 3. 公開編

ユーザー向け設定

- あいさつメッセージを設定する。
- 推奨プロンプト（スタータープロンプト）を設定する。
- 新しいチャット開始時に推奨プロンプトが表示される。

公開

- エージェントを公開すると、他チャネルから利用可能になる。
- ラボでは Teams + Microsoft 365 チャネルを有効化する。
- Teamsへ追加し、エージェントを利用可能にする。
- エージェントは組織内ユーザーへ共有できる。


## 4. 応用編

スキル（Agent Skills）

- 長いInstructionsの代わりに再利用可能なスキルを利用する。
- スキルは必要時のみ読み込まれるため効率的。
- ツール利用のベストプラクティスを定義できる。

例：重複登録防止スキル

- 商品登録前に商品一覧を取得する。
- 重複商品が見つかった場合は登録を中止する。
- スキルはエージェント全体に適用される。

メモリ（Memory）

- ユーザーごとの好みや指示を記憶する機能。
- 新しいチャットでも過去の指示を反映できる。
- 例：商品一覧を五十音順で表示するよう記憶。
- メモリはユーザー単位で保持される。

Connected Agents

- 親エージェントが子エージェントを呼び出す仕組み。
- 子エージェントはツールのように利用される。
- 例： 
- 商品管理エージェント（親）
- 商品説明文作成エージェント（子）
- 商品説明文生成を子エージェントへ委譲し、その結果をDataverseへ更新できる。


## 全体のまとめ

- Power Platform環境、Dataverse、ソリューションを準備する。
- Dataverseテーブルを作成する。
- Copilot Studioでエージェントを作成する。
- Dataverseツールを追加してデータ参照・登録を実現する。
- ナレッジを追加してWeb・ファイル検索を可能にする。
- Teamsへ公開して利用者に提供する。
- スキルで業務ルールを共通化する。
- メモリでユーザーごとの好みを保持する。
- Connected Agentsで複数エージェントを連携させる。


ラボ環境は半年後まで利用できますので、ぜひ練習・復習にご活用ください。

### 参考情報

- Microsoft Copilot Studio ドキュメント
  - [Microsoft Copilot Studio の概要](https://learn.microsoft.com/ja-jp/power-platform/copilot-studio/overview)
  - [Microsoft Copilot Studio の使用を開始する](https://learn.microsoft.com/ja-jp/power-platform/copilot-studio/get-started)
  - [Microsoft Copilot Studio のエージェントの作成](https://learn.microsoft.com/ja-jp/power-platform/copilot-studio/create-agent)
  - [Microsoft Copilot Studio のエージェントの公開](https://learn.microsoft.com/ja-jp/power-platform/copilot-studio/publish-agent)
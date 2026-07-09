# Work IQ

https://learn.microsoft.com/ja-jp/microsoft-365/copilot/extensibility/work-iq/

https://www.microsoft.com/ja-JP/microsoft-365-copilot#WorkIQ

## Work IQとは？

「Copilotやエージェントが、組織のデータ、コンテキスト、ツールにアクセスして推論できるようにする職場インテリジェンス レイヤー」。

各ユーザーのMicrosoft 365 の利用パターンや業務データを理解し、各プロンプトに最適な情報を検索・提供する仕組み。

単なるキーワード検索を超え、作業コンテンツやアプリから最適な結果を抽出する。

## いつ登場？

2025年11月に開催された年次イベント「Microsoft Ignite 2025」で発表された。
https://news.microsoft.com/source/asia/features/from-idea-to-deployment-the-complete-lifecycle-of-ai-on-display-at-ignite-2025/?lang=ja

## わかりやすい解説動画

動画(YouTube): 【Microsoft社員が解説】Copilotの精度を劇的に上げる「Work IQ」とは？
https://www.youtube.com/watch?v=sDz8-opSCi8

## 利用条件・課金

Microsoft 365 Copilotライセンスとは独立して提供され、使用量ベースで課金される。

## 導入方法

組織のMicrosoft 365管理者が、「Microsoft 365 管理センター」または「Azure CLI」を利用して、Work IQを有効化する必要がある。
https://learn.microsoft.com/ja-jp/microsoft-365/copilot/extensibility/work-iq/enable-work-iq?tabs=entra-admin

## Copilotライセンスとの関係

ユーザーにMicrosoft 365 Copilotライセンスが割り当てされていない場合は、Work IQは表示されない。
https://chrismenardtraining.com/post/m365-copilot-work-iq-explained-free-powerpoint-download/

## 「職場/Web」切り替えスイッチとの関係

Work IQが有効化されると、「職場/Web」切り替えスイッチがなくなり、代わりに画面左上に「Work IQ」ボタンが出現。

各ユーザーはMicrosoft 365 Copilot Chatの画面で「New Copilot」スイッチをON・OFFでき、ONの場合はWork IQボタン、OFFの場合は「職場（Work）・Web」切り替えスイッチが表示される。
https://www.youtube.com/watch?v=F_i8e7oe69I

## Microsoft 365 Copilot Chatで利用方法

Microsoft 365 Copilot Chatに統合されている。画面左上に「Work IQ」ボタンが出現。クリックでON・OFFできる。

## Power BI / Dataverseとの関係

Work IQはPower BIやDataverseのデータを検索できる。
https://techcommunity.microsoft.com/blog/microsoft365copilotblog/what%E2%80%99s-new-in-microsoft-365-copilot--june-2026/4529572

## Copilot Coworkとの関係

Copilot CoworkはWork IQを利用する。
https://techcommunity.microsoft.com/blog/microsoft365copilotblog/what%E2%80%99s-new-in-microsoft-365-copilot--june-2026/4529572

## セキュリティ・参照範囲

Work IQが情報を参照する際、Microsoft Purviewの機密ラベル（秘密、社外秘など）が付与されているドキュメントに対して、Copilotはラベルに基づいて検索を実行。例えば、ラベルによって抽出が制限されている内容は回答に含めないといった制御が可能。
https://aurant-technologies.com/blog/copilot-implementation-14811/

## Work IQ / Fabric IQ / Foundry IQ / Web IQ の違い
https://qiita.com/lowgain/items/ffc7dc2722defa63e14f

## 開発者向けの情報

エージェントからは、A2AやMCP経由でWork IQに接続が可能。

「WorkIQ CLI」（「workiq」コマンド）や、GitHub Copilot CLI からも利用可能。
https://learn.microsoft.com/ja-jp/microsoft-365/copilot/extensibility/work-iq/cli

Work IQ REST APIも利用可能
https://learn.microsoft.com/ja-jp/microsoft-365/copilot/extensibility/work-iq/rest/overview

## Work IQ APIs

エージェントがMicrosoft 365のデータやアプリとアクセスするためのAPI。
June 16, 2026より一般提供開始される。
https://www.microsoft.com/en-us/microsoft-365/blog/2026/06/02/announcing-the-new-work-iq-apis/

## Work IQ MCPサーバー

たとえば「Work IQ Mail」を使用すると、メールの送信なども実行できる。
https://learn.microsoft.com/ja-jp/microsoft-copilot-studio/use-work-iq

## Work IQ MCPサーバーのエージェントからの利用

Microsoft Copilot Studioのエージェントから、Work IQ MCPで、Work IQを利用できる。
https://learn.microsoft.com/ja-jp/microsoft-copilot-studio/use-work-iq

Microsoft Copilot StudioでのWork IQ有効化
https://learn.microsoft.com/ja-jp/microsoft-copilot-studio/knowledge-copilot-studio#turn-on-work-iq

YouTube動画: Work IQ MCP Server で Word 出力するエージェントを作る
https://www.youtube.com/watch?v=cIPmHsUFoew

Microsoft Foundryのエージェントから、WorkIQ MCPサーバーを利用して、Work IQを利用できる。
https://learn.microsoft.com/ja-jp/microsoft-agent-365/tooling-servers-overview#get-started-in-microsoft-foundry

GitHub Copilot CLI、Claude Code、VS Code から Work IQ MCP サーバーを利用できる。
https://learn.microsoft.com/ja-jp/microsoft-agent-365/tooling-servers-overview#set-up-work-iq-mcp-servers-for-coding-agents


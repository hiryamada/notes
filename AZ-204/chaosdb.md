
■ChaosDB脆弱性(2020/8/12)

概要:

- Cosmos DBに統合されている「Jupyter Notebook」を悪用して、別の顧客が所有するCosmos DBアカウントのプライマリーキーを取得できるという脆弱性(ChaosDB)が発見された。
- プライマリキーにより、Cosmos DBアカウントに対する完全なアクセス権が得られる。
- この脆弱性は[Wiz](https://www.wiz.io)の研究者が発見し、8月9日に脆弱性の影響を確認し、8月12日にマイクロソフトに報告した。
- マイクロソフトでは、報告を受けてから48時間以内に、脆弱性を修正した。
- 影響を受ける顧客にはマイクロソフトから対策方法を連絡済み。
- 技術的な詳細については今後発表予定。

ソース:

- https://www.wiz.io/blog/protecting-your-environment-from-chaosdb
- https://msrc-blog.microsoft.com/2021/08/27/update-on-vulnerability-in-the-azure-cosmos-db-jupyter-notebook-feature/

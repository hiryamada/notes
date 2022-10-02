# Azure Quantum

Azure のクラウド量子コンピューティング サービス

公式サイト https://azure.microsoft.com/ja-jp/products/quantum/

ドキュメント https://learn.microsoft.com/ja-jp/azure/quantum/overview-azure-quantum

価格 https://azure.microsoft.com/ja-jp/pricing/details/azure-quantum/

用語集 https://learn.microsoft.com/ja-jp/azure/quantum/azure-quantum-glossary

■歴史

2021/2/1 パブリックプレビュー
https://news.microsoft.com/ja-jp/2021/02/05/210205-azure-quantum-preview/

■Azure Quantum

https://learn.microsoft.com/ja-jp/azure/quantum/overview-azure-quantum

- Azure Quantum が提供する最適な開発環境を使用すると、複数のプラットフォームのための量子アルゴリズムを一度に作成でき、一方で同じアルゴリズムを特定のシステム用に調整する柔軟性を維持できます
- オープンなエコシステム: Microsoft およびそのパートナー製のさまざまな量子ソフトウェア、ハードウェア、ソリューションにアクセスできます
- 初めてのユーザーは、ワークスペースの作成時に、参加している各量子ハードウェア プロバイダーで使用できる無料の 500 ドル (米国ドル)Azure Quantum クレジットを自動的に取得します。 クレジットをすべて消費し、不足した場合は、Azure Quantum クレジット プログラムにお申し込みいただけます。
- 開発者は、使い慣れたプログラミング ツールを使用して量子アプリケーションを作成します。 Qiskit、Cirq Python パッケージなど、最も使い慣れた言語と SDK を使用して作業を開始でき、その一方で、すべての機能を備えた組み込みの量子言語 Q# を探索して学習できます。
- Quantum Development Kit を使用すると、Q# プログラムを Python および .NET と統合できます。

https://learn.microsoft.com/ja-jp/azure/quantum/concepts-overview

- オープンかつ柔軟で、将来も使用できるよう設計された量子コンピューティング用のクラウド エコシステム
- 無料の Azure Quantum クレジットで開発が推進されます。
- 無料のホスト型 Jupyter Notebook によって数分で使い始めることができます。
- 最も一般的な量子言語と SDK がサポートされています (Q#、Qiskit、Cirq)。
- 1 回作成するだけで、複数のハードウェア アーキテクチャで実行できます

■量子プログラミング言語

https://ja.wikipedia.org/wiki/%E9%87%8F%E5%AD%90%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0%E8%A8%80%E8%AA%9E

- 命令型量子プログラミング言語
  - QCL
  - LanQ
- 関数型量子プログラミング言語
  - Selinger's QPL
  - QML


■量子シミュレーター

https://learn.microsoft.com/ja-jp/azure/quantum/machines/

量子シミュレーターは従来型コンピューターで実行され、Q# プログラムの "ターゲット マシン" として動作するソフトウェア プログラムであり、量子プログラムをある環境で実行して、さまざまな演算に量子ビットがどのように反応するかを予測するためのテストを行えるようにします。

LIQ𝑈𝑖⏐〉(liquid): The Language Integrated Quantum Operations Simulator http://stationq.github.io/Liquid/
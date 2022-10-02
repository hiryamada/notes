# 量子コンピューティング

Quantum Native Dojo(量子コンピュータについて勉強したいと思っている方のために作られた自習教材 by [QunaSys](https://qunasys.com/))
https://dojo.qulacs.org/ja/latest/index.html


■量子コンピューティング

- [量子コンピューティングとは？(Microsoft)](https://azure.microsoft.com/ja-jp/resources/cloud-computing-dictionary/what-is-quantum-computing/)
- [量子コンピューティングについて(Microsoft Docs)](https://learn.microsoft.com/ja-jp/azure/quantum/overview-understanding-quantum-computing)
- [量子コンピューティングを使用する理由(Microsoft Docs)](https://learn.microsoft.com/ja-jp/azure/quantum/overview-azure-quantum#why-use-quantum-computing)
- [量子コンピューティングとは？(IBM)](https://www.ibm.com/jp-ja/topics/quantum-computing)
- [量子コンピュータ(wikipedia)](https://ja.wikipedia.org/wiki/%E9%87%8F%E5%AD%90%E3%82%B3%E3%83%B3%E3%83%94%E3%83%A5%E3%83%BC%E3%82%BF)
- [量子コンピュータ(NEDO)](https://nedo-quantum.aist.go.jp/quantum-computer.html)
- [量子コンピューティング基礎知識(NEC)](https://jpn.nec.com/quantum_annealing/basic.html)

https://dojo.qulacs.org/ja/latest/notebooks/0_prologue.html

- 量子コンピュータは、量子ビットを用いて多数の計算を同時に行い、その結果をうまく処理することで、古典コンピュータと比べて飛躍的に高速に計算を行える場合がある。
- 現実にある全ての問題(タスク)を、量子コンピュータが高速に計算できるわけではない
- 一部の問題については量子コンピュータの方が現状の古典コンピュータのアルゴリズムよりも高速であることが証明されている



■量子コンピュータの種類

https://jpn.nec.com/quantum_annealing/basic.html

- 量子コンピュータは、ゲート型とアニーリング型の2つに大別されます
- ゲート型
  - 現在の計算機の処理単位である”bit”を”量子bit”で置き換えた計算機であり、従来は”量子コンピュータ”と言えばゲート型を指していました。
  - 1994年に量子計算機を使って大きな数の素因数分解を高速に実行するショアのアルゴリズムが発明されると暗号解読に使えるのではないかとして一躍注目を浴びました。
  - しかし、実現に向けては様々な課題があり、実用化されるとしても数十年先と言われています。
- アニーリング型
  - 東工大の西森教授が1998年に理論を提唱しカナダのD-Wave社が2010年ごろ世界で初めて実装した量子計算機で、金属の焼きなまし処理とよく似た処理を量子を使って行う、いわば自然の法則を活用して最小エネルギー状態を探索する量子計算機です。
  - 量子アニーリングでは最適な組み合わせを探す「試行」の回数を、量子重ね合わせの原理によって圧倒的に増やせるので、組み合わせ最適化問題に適しているといわれています。
  - また、実用化が見える段階まできており、世界中の研究機関や企業が開発にしのぎを削っています。

■量子ゲート


■コヒーレンス時間

https://news.mynavi.jp/techplus/article/20170804-a165/

量子重ね合わせ状態が持続する時間の長さは「コヒーレンス時間」と呼ばれ、これを伸ばすことは量子コンピュータ実現の上で非常に重要な技術となる。今回報告された1秒というコヒーレンス時間は、量子コンピュータに実用的な計算を行わせるために必要な条件に近い長さであるとしている。

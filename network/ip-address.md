# IPアドレス

■パブリックIPアドレス

https://learn.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-addresses

- パブリックIPアドレス
  - Basic SKU
    - （Standard SKU導入以前から使われていたもの）
    - デフォルトで受信に対して開いている
    - 割り当て: 静的 または 動的
    - 可用性ゾーンをサポートしない
  - Standard SKU
    - デフォルトで受信に対して閉じている
    - ネットワークセキュリティグループで明示的に受信を許可
    - 割り当て: 静的のみ
    - 可用性ゾーンをサポート

■プライベートIPアドレス

https://learn.microsoft.com/ja-jp/azure/virtual-network/ip-services/private-ip-addresses



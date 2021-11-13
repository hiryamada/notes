# Qualys 脆弱性スキャナー


■VMの脆弱性スキャン

https://docs.microsoft.com/ja-jp/azure/defender-for-cloud/deploy-vulnerability-assessment-vm

https://qiita.com/hisnakad/items/e8cb3687b964d71e93b9

Azure Defender for Cloud (Azure Security Center) には、マシンの脆弱性スキャナ（Qualys脆弱性スキャナー）が組み込まれている。

Qualysライセンスやアカウントは必要ない。

■ACRのコンテナーイメージの脆弱性スキャン

https://azure.microsoft.com/ja-jp/updates/scan-container-images-for-vulnerabilities-in-azure-security-center/

Qualys を利用

新しいコンテナー イメージを Azure Container Registry にプッシュすると自動的にトリガーされる

検出された脆弱性は Security Center の推奨事項として表示され、それらに修正プログラムを適用して許容されている攻撃対象領域を削減する方法に関する情報が得られる。


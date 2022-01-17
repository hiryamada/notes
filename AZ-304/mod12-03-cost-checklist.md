# コスト最適化のためのチェックリスト

■チェックリスト - コストを考慮した設計

https://docs.microsoft.com/ja-jp/azure/architecture/framework/cost/design-checklist

- さまざまな Azure リージョンのリソースのコストを確認する
- 可能な場合はマネージドのサービスを選択する
  - 運用の手間（＝人件費）を節約できる

■チェックリスト - コストの最適化

https://docs.microsoft.com/ja-jp/azure/architecture/framework/cost/optimize-checklist

- 使用率が低いリソースを確認する
  - 停止、サイズ変更、シャットダウンを検討する
- コストのレビューを行う
  - Cost Management + Billing
  - Azure Advisorの推奨事項
- [Azureの予約](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations)を使用する
- [Azureハイブリッド特典](https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/)を利用する
- 自動スケーリングを行う
  - VMスケールセット
  - App Serviceプラン
- [適切なストレージ層（ホット、クール、アーカイブ）を選択する()](mod07-01-blob-access-tiers.md)
- [適切なデータストアを選択する](mod08-01-data-platform.md)
- [Azure CDN](https://docs.microsoft.com/ja-jp/azure/cdn/cdn-overview)などのグローバルキャッシュを使用して、オリジンサーバーの負荷を削減する
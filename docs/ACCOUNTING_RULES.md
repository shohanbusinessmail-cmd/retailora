# Accounting and financial rules — proposed

Use a single journal for reporting. Journal debits must equal credits in each posted transaction; invalid journals are rejected before commit. Signed reversals reference originals and never silently edit finalized history. Values shown below exclude tax for clarity; configured tax postings need jurisdictional review and separate tax account lines.

| Event | Debit | Credit |
| --- | --- | --- |
| Cash sale | cash | revenue |
| Credit sale | customer receivable | revenue |
| Sale COGS | COGS | inventory |
| Customer collection | cash/bank | customer receivable (or customer advance liability) |
| Credit purchase | inventory | supplier payable |
| Supplier payment | supplier payable | cash/bank |
| Operating expense | expense | cash/bank or payable |
| Sale return | sales returns | cash/receivable/credit liability as applicable |
| Resalable returned stock | inventory at original allocated cost | COGS |
| Purchase return | payable/cash | inventory, with cost difference posted to an explicitly defined variance account |

Opening balances require balancing owner capital/opening equity and supporting subledger opening items. Inventory purchases are assets, not operating expenses. Free goods and purchase-related costs need allocation into inventory cost; prohibit ambiguous postings until tested. Payment method is a manual record, not a payment-provider integration.

Net sales = gross sales − discounts − sales returns (separate tax from revenue). Gross profit = net sales − net COGS. Operating profit = gross profit − operating expenses; net profit additionally reflects separately classified other income/expenses and taxes. Revenue is earned on sale, not collection; receivables = posted customer charges − allocations/credits, including opening balances and advances separately. Do not double-count cash settlements as sales. Reconcile journal, receivable/payable subledgers, inventory projection and reports per transaction and period.

Currency: BDT, 1 taka = 100 paisa. Round decimal line amounts to paisa using midpoint away from zero; all posted balances are integral paisa. Document invoice discount and tax allocation including deterministic residual distribution before implementing POS. Current `Money` helper only defines conversion; it is not a full pricing engine. Tax, rounding and Bangladesh compliance must be reviewed with qualified professionals before release.

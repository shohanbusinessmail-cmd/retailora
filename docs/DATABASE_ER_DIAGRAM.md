# Proposed relationships

```mermaid
erDiagram
  USERS ||--o{ SALES : creates
  CUSTOMERS o|--o{ SALES : billed
  SALES ||--|{ SALE_LINES : contains
  PRODUCTS ||--o{ SALE_LINES : referenced
  SUPPLIERS ||--o{ PURCHASES : supplies
  PURCHASES ||--|{ PURCHASE_LINES : contains
  PRODUCTS ||--o{ PURCHASE_LINES : referenced
  SALE_LINES ||--o{ SALES_RETURN_LINES : returned
  PURCHASE_LINES ||--o{ PURCHASE_RETURN_LINES : returned
  PRODUCTS ||--o{ STOCK_MOVEMENTS : tracks
  PRODUCTS ||--o| STOCK_BALANCES : projects
  ACCOUNTS ||--o{ JOURNAL_LINES : contains
  JOURNALS ||--|{ JOURNAL_LINES : posts
  CUSTOMERS ||--o{ PAYMENTS : pays
  SUPPLIERS ||--o{ PAYMENTS : receives
  PAYMENTS ||--o{ PAYMENT_ALLOCATIONS : allocates
  SALES ||--o{ PAYMENT_ALLOCATIONS : settles
```

Conceptual only; allocation also covers supplier purchase obligations, opening balances and reversals. Actual cardinality and polymorphic reference integrity require concrete schema design; this diagram is not executable DDL.

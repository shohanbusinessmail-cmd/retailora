# Roadmap and gates

This is a multi-session project, not a release plan with estimated dates. Each phase needs implementation, automated tests, Windows workflow verification, documentation and a checkpoint. A critical data-integrity, accounting, security, backup or licensing failure blocks release.

0. Planning: preliminary naming, architecture, ER, financial, license and UX design. Complete detailed schema/requirements review and legal brand review.
1. Foundation: Windows build, MVVM, DI, logging, localization, database connection and versioned migrations with safe failure/recovery. Current window is only a development warning.
2. Local administrator onboarding, authentication, authorization and business setup.
3. Product/category/unit/barcode and transactional inventory with moving average.
4. POS, atomic sales, invoice and printing.
5. Customer, payments and receivables.
6. Supplier, purchase, payables and purchase return.
7. Sales returns/refunds and expenses.
8. Balanced journals, reconciled reports, export and cash management.
9. Online SQLite backup, integrity checks, safe restore and migration.
10. Separate private license generator, offline activation, key security and transfer.
11. Polish Bengali UX, actual font/PDF/printing, accessibility and keyboard navigation.
12. Full scenario, failure, performance, security and offline tests on Windows.
13. Installer, signed/unsigned disclosure, isolated owner generator, gated Windows release automation.
14. Independent commercial readiness review against all requested acceptance criteria.

Dependencies may necessitate earlier vertical slices (e.g. journal rules must accompany the first posted transaction); no phase permits temporarily incorrect accounting. CI builds do not constitute product acceptance. No tag release or public distribution before gates pass.

# Architecture (design; mostly not implemented)

## Scope and boundaries
Single Windows x64 machine, local SQLite database, offline by default. A single local database is not a network/multi-terminal database. No mandatory network calls, telemetry, third-party account, online validation or subscription. This design is not evidence of implementation.

- **Desktop**: WPF views, Bengali copy, accessibility, navigation, MVVM; no SQL or business calculations in views.
- **Application**: authorized commands/queries, validation, unit-of-work orchestration and idempotency. Authorization enforced here, not only by hiding navigation.
- **Domain**: amounts, quantity, cost, journal and transaction invariants; no WPF or SQLite dependencies. Two isolated primitives exist, not a full accounting engine.
- **Persistence/infrastructure**: SQLite repositories, migrations, backup, local file storage, platform services, secure credentials, logging. All pending.
- **Reporting**: query-only projections based on posted records and ledger; printing/export adapters; preserve historical snapshots.
- **Licensing**: verification-only library in customer application. Separate owner executable signs with external protected keys, never bundled with customer installer. Neither exists yet.

WPF/.NET 10 is the chosen baseline: Microsoft's [.NET support guidance](https://learn.microsoft.com/en-us/dotnet/core/releases-and-support) lists .NET 10 as LTS supported through November 2028. Plan servicing and a later runtime upgrade. SQLite is planned with parameterized SQL, foreign keys enabled **on every connection**, WAL on local storage only, FULL synchronous durability by default, bounded busy timeout and short write transactions. SQLite's [WAL documentation](https://www.sqlite.org/wal.html) explains why the WAL is persistent state and must not be separated from a live database. Take consistent snapshots with the [online backup API](https://www.sqlite.org/backup.html). Verify filesystem and Windows durability behavior under failure; no network shares for the live DB.

## State and workflows
Activation gates protected operations before first administrator setup. Every use case requires a session and permission, validates inputs and entity status, and commits all side effects together. A unique idempotency key binds one request to one result; duplicate requests with different payloads are rejected. Invoices use a database-enforced unique reference, allocated inside the transaction. A print/export failure never retries a sale; reprinting reads the existing immutable invoice.

On startup, resolve a writable per-user or explicitly chosen business data location independent of install directory; do not silently create a fresh database if an expected database fails to open. Inspect schema version, obtain verified online backup before upgrades, apply forward migrations transactionally where possible, fail closed on newer or failed schemas, and provide explicit recovery. The actual path, single-instance behavior, migration and restore protocol still need implementation and testing.

## Dependency policy
Current code uses only .NET SDK/framework; planned SQLite provider, test framework, PDF/Excel/barcode/font/installer libraries need version, transitive license, support, vulnerability and redistribution review before adoption. EF Core 10 is a candidate, not yet selected; [Microsoft's EF lifecycle](https://learn.microsoft.com/en-us/ef/core/what-is-new/) aligns its support with .NET. A PDF stack must demonstrate Bengali shaping and embedding before selection. Do not include unreviewed font assets. No claim of signed binaries or legal VAT compliance.

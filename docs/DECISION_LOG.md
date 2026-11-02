# Decisions

- 2026-11-02: provisional Dokanora identity; known similar market names mean legal/trademark and domain checks are required before sale. See naming research.
- 2026-11-02: choose .NET 10 LTS / WPF and local SQLite as intended stack. SDK and Windows unavailable locally; compatibility is not yet verified. Other packages not yet selected or cleared for redistribution.
- 2026-11-02: use BDT minor units for posted money and moving weighted average inventory as planned; journal and transaction rules must be reviewed before posting data.
- 2026-11-02: customer and owner generator must be separate, signing key offline and absent from source/CI. Public repo creates owner-tool visibility risk; owner controls privacy setting.
- 2026-11-02: no tag release workflow until critical acceptance gates exist. Prevents automatic distribution of incomplete builds.

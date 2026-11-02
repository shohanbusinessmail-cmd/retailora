# দোকানোরা (Dokanora)

**Development only — not suitable for business use or distribution.** Dokanora is the working name for a planned offline Windows retail application for Bangladesh. The repository currently contains a small WPF development window, two domain validation primitives, a dependency-free smoke-test executable, and design documents. It does **not** implement sales, inventory, authentication, accounting, backups, activation or an installer. No business data should be entered into this build.

The name is provisional pending a fuller brand and legal review; see [naming research](docs/NAMING_RESEARCH.md). The repository is currently **public**. Never commit customer data, activation records, passwords, signing keys, certificates or backups.

## Development

Windows 10/11 x64 and a supported .NET 10 SDK are required for the WPF application. From the repository root:

```powershell
dotnet build src/Dokanora.Desktop/Dokanora.Desktop.csproj -c Release
dotnet run --project tests/Dokanora.Domain.Tests/Dokanora.Domain.Tests.csproj -c Release
dotnet run --project src/Dokanora.Desktop/Dokanora.Desktop.csproj
```

The smoke-test executable exits nonzero on failure; it is not a substitute for the full automated test suite. CI builds on Windows; no installer or release workflow is provided yet. Follow [current work](docs/CURRENT_WORK.md), [status](docs/PROJECT_STATUS.md), and [roadmap](docs/DEVELOPMENT_ROADMAP.md).

Design documents describe intended behavior, **not implemented functionality**. No license for this repository has been selected; all rights remain with the copyright holder unless otherwise explicitly licensed. Third-party components require individual license review before distribution.

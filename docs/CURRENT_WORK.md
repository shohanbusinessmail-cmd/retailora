# Current work / next session

Read status, task tracker and git history, check working tree, then run applicable tests before changes. Next: investigate why no GitHub Actions run was visible after the foundation push (Actions permissions API returned 403), then obtain a Windows .NET 10 build result (CI or local), fix actual failures, validate icon/Bengali rendering and replace dependency-free smoke tests with a reviewed test framework. Finalize schema with transaction invariants and tests before enabling database writes; implement safe connection/migration/backup foundations. Do not enable real business operations, distribute builds or label this product ready yet.

Current environment: Linux, no `dotnet`; remote repository public. Avoid checking in real customer data, private keys or private activation histories. Naming is provisional pending conflict/legal review.

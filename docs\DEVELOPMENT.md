# Development plan

This repository currently publishes an implementation-ready design, not a runnable binary. The first code contribution should bootstrap a Windows-first Tauri 2, React, TypeScript, and Rust workspace with strict TypeScript and an offline SQLite database.

Before merging the first executable slice, provide `dev`, `typecheck`, `test`, and `build` scripts; a local smoke-test procedure; and tests for permission denial, empty context, provider unavailability, and persistence after restart.

# Architecture

Atelier is designed as a local-first Tauri desktop application. The renderer never receives unrestricted filesystem, shell, network, or secret access.

## Boundaries

```text
React renderer → validated IPC → Rust core → SQLite / OS credential store / provider adapters
```

- **Renderer:** workspace UI, patch review, and approval prompts.
- **Rust core:** policy decisions, audit records, SQLite persistence, and filesystem mediation.
- **Provider adapters:** explicit, replaceable integrations for local models, compatible hosted APIs, and opted-in MCP servers.

## Core domain contracts

`Workspace` owns a folder grant. `ContextSelection` is a deliberate set of files or excerpts. `ActionRequest` declares a capability and rationale. `Approval` is scoped, time-bounded, and audit-recorded. `PatchProposal` is reviewed hunk-by-hunk before application.

## Persistence

Store workspace metadata, provider configuration excluding secrets, approvals, and audit events in SQLite. Keep credentials in the operating-system credential store. No telemetry is required for normal operation.

## First implementation slice

1. Open a local folder through an OS picker.
2. Persist a workspace record and an audit event.
3. Select files as context without auto-uploading them.
4. Render a proposed unified diff.
5. Apply only selected hunks after explicit approval.

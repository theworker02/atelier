# Clean-room design

## Product concept

Atelier is a local-first desktop workspace for collaborating with AI on folders, notes, and structured tasks. Users choose a hosted or local provider; local workflows do not require an account.

## Information architecture

```text
Atelier
├── Home
├── Workspace
│   ├── Conversation
│   ├── Files
│   ├── Tasks
│   └── Context
├── Library
└── Settings
    ├── Providers
    ├── Permissions
    ├── Privacy
    └── Appearance
```

## Key flow: assisted change

1. The user requests an outcome.
2. Atelier proposes a compact plan and requested capabilities.
3. The user explicitly approves sensitive actions.
4. Proposed edits appear as a unified diff.
5. The user applies individual hunks or rejects them. Every action is logged locally.

## Architecture

```text
Tauri shell
├── React + TypeScript renderer
├── Rust core: SQLite, policy engine, audit ledger, provider bridge
└── Optional adapters: local models, compatible APIs, explicitly enabled MCP servers
```

## Security model

- Read-only workspace access by default.
- Privileged work stays outside the renderer behind validated IPC.
- Approval is required for destructive edits, commands, network access, and secret reads.
- Secrets live in the OS credential store, not project metadata.
- Telemetry is off by default.

## MVP acceptance criteria

- Reopen a local workspace without an account.
- Attach an explicit file-context list to a conversation.
- Review and selectively apply a generated patch.
- Keep sensitive actions behind approval.
- Persist a local, secret-free audit log.

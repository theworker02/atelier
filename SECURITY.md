# Security policy

## Reporting

Do not open public issues for a suspected vulnerability. Until a private reporting channel is established, report only a minimal, non-sensitive description through the repository owner's GitHub profile and wait for a response before disclosing details.

## Product security baseline

- Read-only workspace access by default.
- User approval before writes, commands, network access, or secret reads.
- No arbitrary shell IPC from the renderer.
- Secrets belong in OS-managed storage, never project files or logs.
- Telemetry is opt-in and must disclose its payload and destination.

## Non-goals

Atelier does not claim to sandbox untrusted code. Any future execution feature must use an explicit, separately documented isolation boundary.

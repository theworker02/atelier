# Atelier

**Atelier is a local-first Windows desktop workspace that makes sensitive AI-assisted work explicit and reviewable.** It is an original clean-room Magnexis project: no third-party source, branding, assets, protocols, or recovered implementation material is included.

## What v1.2.0 does

- Selects and restores a local workspace reference.
- Saves a local workspace note across restarts.
- Records explicit write/network review choices in a local audit log.
- Lets the user clear that local audit log.

It intentionally does **not** read workspace contents automatically, modify files, call an AI provider, upload data, or collect telemetry.

## Install and run

Download the Windows x64 ZIP from [Releases](../../releases), extract it, and run `Atelier.exe`. The .NET 10 Desktop Runtime is required. Developers can instead follow [RUNNING.md](RUNNING.md).

## Product promises

| Area | Current behavior |
|---|---|
| Data | Stored locally under `%LOCALAPPDATA%\\Magnexis\\Atelier` |
| Network | No network behavior in v1.2.0 |
| Permissions | Review decisions are explicit and locally audited |
| Telemetry | None |

## Documentation

- [Architecture](ARCHITECTURE.md)
- [Security policy](SECURITY.md)
- [Roadmap](ROADMAP.md)
- [Release notes](docs/releases/1.2.0.md)
- [Media-capture checklist](docs/MEDIA.md)
- [Contributing](CONTRIBUTING.md)

## Media

We publish only authentic captures from a runnable build. The current capture checklist is tracked in [docs/MEDIA.md](docs/MEDIA.md); no conceptual mockups are presented as product footage.


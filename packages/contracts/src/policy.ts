/** Stable, provider-neutral permission vocabulary for the first desktop slice. */
export type Capability = "read_workspace" | "write_workspace" | "run_command" | "network" | "read_secret";

export interface ActionRequest {
  id: string;
  capability: Capability;
  rationale: string;
  workspaceId: string;
}

export interface Approval {
  actionId: string;
  approvedAt: string;
  expiresAt?: string;
}

export function permits(request: ActionRequest, approval: Approval | undefined, now: Date): boolean {
  if (!approval || approval.actionId !== request.id) return false;
  return !approval.expiresAt || new Date(approval.expiresAt) > now;
}

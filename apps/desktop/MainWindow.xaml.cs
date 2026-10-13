using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
namespace Atelier;
public partial class MainWindow : Window {
  private readonly string auditFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Magnexis", "Atelier", "audit.log");
  private readonly string workspaceFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Magnexis", "Atelier", "workspace.txt");
  private readonly string noteFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Magnexis", "Atelier", "note.txt");
  public MainWindow() { InitializeComponent(); Directory.CreateDirectory(Path.GetDirectoryName(auditFile)!); AuditLog.Text = File.Exists(auditFile) ? File.ReadAllText(auditFile) : "No local audit events yet."; if (File.Exists(workspaceFile)) { WorkspacePath.Text = File.ReadAllText(workspaceFile); Status.Text = "Restored local workspace reference. Files have not been read or sent anywhere."; } if (File.Exists(noteFile)) WorkspaceNote.Text = File.ReadAllText(noteFile); }
  private void ChooseFolder_Click(object sender, RoutedEventArgs e) { var dialog = new OpenFolderDialog(); if (dialog.ShowDialog() == true) { WorkspacePath.Text = dialog.FolderName; File.WriteAllText(workspaceFile, dialog.FolderName); Append($"Workspace granted: {dialog.FolderName}"); Status.Text = "Workspace selected. Files have not been read or sent anywhere."; } }
  private void RecordReview_Click(object sender, RoutedEventArgs e) { if (string.IsNullOrWhiteSpace(WorkspacePath.Text)) { Status.Text = "Select a workspace first."; return; } Append($"Review: write={WriteApproval.IsChecked == true}; network={NetworkApproval.IsChecked == true}"); Status.Text = "Review recorded locally."; }
  private void SaveNote_Click(object sender, RoutedEventArgs e) { File.WriteAllText(noteFile, WorkspaceNote.Text); Append("Workspace note saved locally."); Status.Text = "Note saved locally."; }
  private void ClearAudit_Click(object sender, RoutedEventArgs e) { File.WriteAllText(auditFile, ""); AuditLog.Text = "No local audit events yet."; Status.Text = "Local audit cleared."; }
  private void Append(string message) { var line = $"{DateTimeOffset.Now:O} {message}"; File.AppendAllText(auditFile, line + Environment.NewLine); AuditLog.Text = File.ReadAllText(auditFile); AuditLog.ScrollToEnd(); }
}

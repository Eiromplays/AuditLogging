// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/Default/DefaultAuditAction.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Events.Interfaces;

namespace Eiromplays.AuditLogging.Events.Default;

public class DefaultAuditAction : IAuditAction
{
    public object? Action { get; set; }
}
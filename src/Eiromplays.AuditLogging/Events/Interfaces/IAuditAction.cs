// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/IAuditAction.cs
// Modified by Eirik Sjøløkken

namespace Eiromplays.AuditLogging.Events.Interfaces;

public interface IAuditAction
{
    object? Action { get; set; }
}
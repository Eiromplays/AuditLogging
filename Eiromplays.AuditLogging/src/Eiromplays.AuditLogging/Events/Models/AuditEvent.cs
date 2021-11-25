// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/AuditEvent.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Helpers.Common;

namespace Eiromplays.AuditLogging.Events.Models;

public class AuditEvent
{
    private AuditEvent()
    {
        Event = GetType().GetNameWithoutGenericParams();
    }

    public string? Event { get; set; }

    public string? Source { get; set; }

    public string? Category { get; set; }

    public string? SubjectIdentifier { get; set; }

    public string? SubjectName { get; set; }

    public string? SubjectType { get; set; }

    public object? SubjectAdditionalData { get; set; }

    public object? Action { get; set; }
}
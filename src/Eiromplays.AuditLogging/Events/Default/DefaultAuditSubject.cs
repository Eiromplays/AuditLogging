// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/Default/DefaultAuditSubject.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Events.Interfaces;

namespace Eiromplays.AuditLogging.Events.Default;

public class DefaultAuditSubject : IAuditSubject
{
    public string? SubjectIdentifier { get; set; }

    public string? SubjectName { get; set; }

    public string? SubjectType { get; set; }

    public object? SubjectAdditionalData { get; set; }
}
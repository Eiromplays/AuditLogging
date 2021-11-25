// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/IAuditSubject.cs
// Modified by Eirik Sjøløkken

namespace Eiromplays.AuditLogging.Events.Interfaces;

public interface IAuditSubject
{
    string? SubjectIdentifier { get; set; }

    string? SubjectName { get; set; }

    string? SubjectType { get; set; }

    object? SubjectAdditionalData { get; set; }
}
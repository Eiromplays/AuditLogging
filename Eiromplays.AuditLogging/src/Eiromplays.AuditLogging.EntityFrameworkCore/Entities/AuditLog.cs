// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Entities/AuditLog.cs
// Modified by Eirik Sjøløkken

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Entities;

public class AuditLog
{
    public string? Id { get; set; }

    public string? Event { get; set; }

    public string? Source { get; set; }

    public string? Category { get; set; }

    public string? SubjectIdentifier { get; set; }

    public string? SubjectName { get; set; }

    public string? SubjectType { get; set; }

    public string? SubjectAdditionalData { get; set; }

    public string? Action { get; set; }

    public string? Data { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;
}
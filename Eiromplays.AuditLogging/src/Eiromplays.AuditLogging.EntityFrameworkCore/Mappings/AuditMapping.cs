// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Mapping/AuditMapping.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Eiromplays.AuditLogging.Events.Models;
using Eiromplays.AuditLogging.Helpers.Json;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Mappings;

public static class AuditMapping
{
    public static TAuditLog MapToEntity<TAuditLog>(this AuditEvent auditEvent)
        where TAuditLog : AuditLog, new()
    {
        var auditLog = new TAuditLog
        {
            Event = auditEvent.Event,
            Source = auditEvent.Source,
            SubjectIdentifier = auditEvent.SubjectIdentifier,
            SubjectName = auditEvent.SubjectName,
            SubjectType = auditEvent.SubjectType,
            Category = auditEvent.Category,
            Data = AuditLoggingSerializer.Serialize(auditEvent),
            Action = auditEvent.Action == null ? null : AuditLoggingSerializer.Serialize(auditEvent.Action),
            SubjectAdditionalData = auditEvent.SubjectAdditionalData == null ? null : AuditLoggingSerializer.Serialize(auditEvent.SubjectAdditionalData)
        };

        return auditLog;
    }
}
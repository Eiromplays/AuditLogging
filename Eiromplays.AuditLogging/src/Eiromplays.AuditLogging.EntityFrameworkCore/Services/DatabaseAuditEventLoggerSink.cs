// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Services/DatabaseAuditEventLoggerSink.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Eiromplays.AuditLogging.EntityFrameworkCore.Mappings;
using Eiromplays.AuditLogging.EntityFrameworkCore.Repositories.Interfaces;
using Eiromplays.AuditLogging.Events.Models;
using Eiromplays.AuditLogging.Services.Interfaces;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Services;

public class DatabaseAuditEventLoggerSink<TAuditLog> : IAuditLoggerSink
    where TAuditLog : AuditLog, new()
{
    private readonly IAuditLoggingRepository<TAuditLog> _auditLoggingRepository;

    public DatabaseAuditEventLoggerSink(IAuditLoggingRepository<TAuditLog> auditLoggingRepository)
    {
        _auditLoggingRepository = auditLoggingRepository;
    }

    public async Task PersistAsync(AuditEvent auditEvent)
    {
        if (auditEvent == null) throw new ArgumentNullException(nameof(auditEvent));

        var auditLog = auditEvent.MapToEntity<TAuditLog>();

        await _auditLoggingRepository.SaveAsync(auditLog);
    }
}
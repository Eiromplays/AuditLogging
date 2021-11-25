// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Services/IAuditEventLogger.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Configuration.Options;
using Eiromplays.AuditLogging.Events.Models;

namespace Eiromplays.AuditLogging.Services.Interfaces;

public interface IAuditLogger : IAuditLogger<AuditLoggerOptions> { }

public interface IAuditLogger<out TAuditLoggerOptions>
    where TAuditLoggerOptions : AuditLoggerOptions
{
    /// <summary>
    /// Log an event
    /// </summary>
    /// <param name="auditEvent">The specific audit event</param>
    /// <param name="loggerOptions"></param>
    /// <returns></returns>
    Task LogEventAsync(AuditEvent auditEvent, Action<TAuditLoggerOptions>? loggerOptions = default);
}
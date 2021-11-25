// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

// Original file: https://github.com/IdentityServer/IdentityServer4/src/Services/Default/DefaultEventService.cs
// Jan Škoruba file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Services/AuditEventLogger.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Configuration.Options;
using Eiromplays.AuditLogging.Events.Interfaces;
using Eiromplays.AuditLogging.Events.Models;
using Eiromplays.AuditLogging.Services.Interfaces;

namespace Eiromplays.AuditLogging.Services;

public class AuditLogger : IAuditLogger
{
    private readonly IEnumerable<IAuditLoggerSink> _sinks;
    private readonly IAuditSubject _auditSubject;
    private readonly IAuditAction _auditAction;
    private readonly AuditLoggerOptions _auditLoggerOptions;

    public AuditLogger(IEnumerable<IAuditLoggerSink> sinks, IAuditSubject auditSubject, IAuditAction auditAction,
        AuditLoggerOptions auditLoggerOptions)
    {
        _sinks = sinks;
        _auditSubject = auditSubject;
        _auditAction = auditAction;
        _auditLoggerOptions = auditLoggerOptions;
    }

    private Task PrepareEventAsync(AuditEvent auditEvent, Action<AuditLoggerOptions>? loggerOptions)
    {
        if (loggerOptions == default)
        {
            PrepareDefaultValues(auditEvent, _auditLoggerOptions);
            return Task.CompletedTask;
        }

        var auditLoggerOptions = new AuditLoggerOptions();
        loggerOptions.Invoke(auditLoggerOptions);
        PrepareDefaultValues(auditEvent, auditLoggerOptions);

        return Task.CompletedTask;
    }

    private void PrepareDefaultValues(AuditEvent auditEvent, AuditLoggerOptions loggerOptions)
    {
        if (loggerOptions.UseDefaultSubject)
        {
            PrepareDefaultSubject(auditEvent);
        }

        if (loggerOptions.UseDefaultAction)
        {
            PrepareDefaultAction(auditEvent);
        }

        PrepareDefaultConfiguration(auditEvent, loggerOptions);
    }

    private static void PrepareDefaultConfiguration(AuditEvent auditEvent, AuditLoggerOptions loggerOptions)
    {
        auditEvent.Source = loggerOptions.Source;
    }

    private void PrepareDefaultAction(AuditEvent auditEvent)
    {
        auditEvent.Action = _auditAction.Action;
    }

    private void PrepareDefaultSubject(AuditEvent auditEvent)
    {
        auditEvent.SubjectName = _auditSubject.SubjectName;
        auditEvent.SubjectIdentifier = _auditSubject.SubjectIdentifier;
        auditEvent.SubjectType = _auditSubject.SubjectType;
        auditEvent.SubjectAdditionalData = _auditSubject.SubjectAdditionalData;
    }

    public virtual async Task LogEventAsync(AuditEvent auditEvent, Action<AuditLoggerOptions>? loggerOptions = default)
    {
        await PrepareEventAsync(auditEvent, loggerOptions);

        foreach (var sink in _sinks)
        {
            await sink.PersistAsync(auditEvent);
        }
    }
}
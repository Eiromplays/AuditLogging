// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

// Original file: https://github.com/IdentityServer/IdentityServer4/src/Services/IEventSink.cs
// Jan Škoruba file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Services/IAuditEventLoggerSink.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Events.Models;

namespace Eiromplays.AuditLogging.Services.Interfaces;

public interface IAuditLoggerSink
{
    Task PersistAsync(AuditEvent auditEvent);
}
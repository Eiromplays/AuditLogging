// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

// Original file: https://github.com/IdentityServer/IdentityServer4/blob/master/src/IdentityServer4/src/Logging/LogSerializer.cs
// Jan Škoruba file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Helpers/JsonHelpers/AuditLogSerializer.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.JsonContexts;
using System.Text.Json;

namespace Eiromplays.AuditLogging.Helpers.Json;

/// <summary>
/// Helper to JSON serialize object data for audit logging.
/// </summary>
public static class AuditLoggingSerializer
{
    /// <summary>
    /// Serializes the audit event object.
    /// </summary>
    /// <param name="logObject">The object.</param>
    /// <returns></returns>
    public static string Serialize(object logObject)
    {
        return JsonSerializer.Serialize(logObject, ObjectJsonContext.Default.Object);
    }

    /// <summary>
    /// Serializes the audit event object.
    /// </summary>
    /// <param name="logObject">The object.</param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string Serialize(object logObject, JsonSerializerOptions options)
    {
        return JsonSerializer.Serialize(logObject, options);
    }
}
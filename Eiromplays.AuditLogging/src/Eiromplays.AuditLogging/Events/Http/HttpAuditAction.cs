// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/Http/HttpAuditAction.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Configuration.Options;
using Eiromplays.AuditLogging.Events.Interfaces;
using Eiromplays.AuditLogging.Helpers.HttpContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Eiromplays.AuditLogging.Events.Http;

public class HttpAuditAction : IAuditAction
{
    public HttpAuditAction(IHttpContextAccessor accessor, AuditHttpActionOptions options)
    {
        Action = new
        {
            TraceIdentifier = accessor.HttpContext?.TraceIdentifier,
            RequestUrl = accessor.HttpContext?.Request.GetDisplayUrl(),
            HttpMethod = accessor.HttpContext?.Request.Method,
            FormVariables = options.IncludeFormVariables ? HttpContextHelpers.GetFormVariables(accessor.HttpContext) : null
        };
    }

    public object? Action { get; set; }
}
// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Events/Http/HttpAuditSubject.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Configuration.Options;
using Eiromplays.AuditLogging.Constants;
using Eiromplays.AuditLogging.Events.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Eiromplays.AuditLogging.Events.Http;

public class HttpAuditSubject : IAuditSubject
{
    public HttpAuditSubject(IHttpContextAccessor accessor, AuditHttpSubjectOptions options)
    {
        SubjectIdentifier = accessor.HttpContext?.User.FindFirst(options.SubjectIdentifierClaim)?.Value;
        SubjectName = accessor.HttpContext?.User.FindFirst(options.SubjectNameClaim)?.Value;
        SubjectAdditionalData = new
        {
            RemoteIpAddress = accessor.HttpContext?.Connection.RemoteIpAddress?.ToString(),
            LocalIpAddress = accessor.HttpContext?.Connection.LocalIpAddress?.ToString(),
            Claims = accessor.HttpContext?.User.Claims.Select(x=> new { x.Type, x.Value })
        };
    }

    public string? SubjectName { get; set; }

    public string? SubjectType { get; set; } = AuditSubjectTypes.User;

    public object? SubjectAdditionalData { get; set; }

    public string? SubjectIdentifier { get; set; }
}
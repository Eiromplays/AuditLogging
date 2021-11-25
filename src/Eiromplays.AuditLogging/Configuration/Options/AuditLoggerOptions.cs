// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Configuration/AuditLoggerOptions.cs
// Modified by Eirik Sjøløkken

namespace Eiromplays.AuditLogging.Configuration.Options;

public class AuditLoggerOptions
{
    public string? Source { get; set; }

    public bool UseDefaultSubject { get; set; } = true;

    public bool UseDefaultAction { get; set; } = true;
}
// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Configuration/AuditHttpActionOptions.cs
// Modified by Eirik Sjøløkken

namespace Eiromplays.AuditLogging.Configuration.Options;

public class AuditHttpActionOptions
{
    public bool IncludeFormVariables { get; set; } = true;
}
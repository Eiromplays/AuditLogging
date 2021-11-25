// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Configuration/AuditHttpSubjectOptions.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Constants;

namespace Eiromplays.AuditLogging.Configuration.Options;

public class AuditHttpSubjectOptions
{
    public string SubjectIdentifierClaim { get; set; } = ClaimConstants.Sub;

    public string SubjectNameClaim { get; set; } = ClaimConstants.Name;
}
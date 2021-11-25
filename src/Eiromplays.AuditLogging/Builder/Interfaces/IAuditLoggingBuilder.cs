// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Extensions/IAuditLoggingBuilder.cs
// Modified by Eirik Sjøløkken

using Microsoft.Extensions.DependencyInjection;

namespace Eiromplays.AuditLogging.Builder.Interfaces;

public interface IAuditLoggingBuilder
{
    IServiceCollection Services { get; }
}
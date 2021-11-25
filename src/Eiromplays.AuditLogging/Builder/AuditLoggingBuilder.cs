// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging/Extensions/AuditLoggingBuilder.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Eiromplays.AuditLogging.Builder;

public class AuditLoggingBuilder : IAuditLoggingBuilder
{
    public AuditLoggingBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}
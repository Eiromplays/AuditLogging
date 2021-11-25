// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Extensions/AuditLoggingEntityFrameworkExtensions.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.Builder.Interfaces;
using Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Default;
using Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Interfaces;
using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Eiromplays.AuditLogging.EntityFrameworkCore.Repositories;
using Eiromplays.AuditLogging.EntityFrameworkCore.Repositories.Interfaces;
using Eiromplays.AuditLogging.EntityFrameworkCore.Services;
using Eiromplays.AuditLogging.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Extensions;

public static class AuditLoggingEntityFrameworkCoreExtensions
{
    public static IAuditLoggingBuilder AddDefaultStore(this IAuditLoggingBuilder builder, Action<DbContextOptionsBuilder> dbContextOptions)
    {
        builder.AddStore<DefaultAuditLoggingDbContext, AuditLog, AuditLoggingRepository<DefaultAuditLoggingDbContext, AuditLog>>(dbContextOptions);

        return builder;
    }

    public static IAuditLoggingBuilder AddStore<TDbContext, TAuditLog, TAuditLoggingRepository>(this IAuditLoggingBuilder builder, Action<DbContextOptionsBuilder> dbContextOptions)
        where TDbContext : DbContext, IAuditLoggingDbContext<TAuditLog> where TAuditLoggingRepository : class, IAuditLoggingRepository<TAuditLog> where TAuditLog : AuditLog
    {
        builder.Services.AddDbContext<TDbContext>(dbContextOptions);
        builder.Services.AddTransient<IAuditLoggingRepository<TAuditLog>, TAuditLoggingRepository>();

        return builder;
    }

    public static IAuditLoggingBuilder AddDefaultAuditSink(this IAuditLoggingBuilder builder)
    {
        builder.AddAuditSinks<DatabaseAuditEventLoggerSink<AuditLog>>();

        return builder;
    }
}
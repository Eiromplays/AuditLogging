// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/DbContexts/AuditLoggingDbContext.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Interfaces;
using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts;

public class AuditLoggingDbContext<TAuditLog> : DbContext, IAuditLoggingDbContext<TAuditLog>
    where TAuditLog : AuditLog
{
    public AuditLoggingDbContext(DbContextOptions options) : base(options) { }

    public DbSet<TAuditLog>? AuditLogs { get; set; }
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}
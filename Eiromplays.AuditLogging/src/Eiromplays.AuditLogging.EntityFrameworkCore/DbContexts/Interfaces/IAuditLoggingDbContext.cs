// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/DbContexts/AuditLoggingDbContext.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Interfaces;

public interface IAuditLoggingDbContext<TAuditLog> where TAuditLog : AuditLog
{
    DbSet<TAuditLog>? AuditLogs { get; set; }

    Task<int> SaveChangesAsync();
}
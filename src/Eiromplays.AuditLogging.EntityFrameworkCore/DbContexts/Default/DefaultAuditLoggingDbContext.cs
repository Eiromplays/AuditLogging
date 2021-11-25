// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/DbContexts/Default/DefaultAuditLoggingDbContext.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Default;

public class DefaultAuditLoggingDbContext : AuditLoggingDbContext<AuditLog>
{
    public DefaultAuditLoggingDbContext(DbContextOptions<DefaultAuditLoggingDbContext> dbContextOptions) : base(dbContextOptions) { }
}
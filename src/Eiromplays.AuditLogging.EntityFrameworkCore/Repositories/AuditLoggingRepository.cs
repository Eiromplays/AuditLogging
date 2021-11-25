// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Repositories/AuditLoggingRepository.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.DbContexts.Interfaces;
using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Eiromplays.AuditLogging.EntityFrameworkCore.Extensions;
using Eiromplays.AuditLogging.EntityFrameworkCore.Helpers;
using Eiromplays.AuditLogging.EntityFrameworkCore.Helpers.Common;
using Eiromplays.AuditLogging.EntityFrameworkCore.Repositories.Interfaces;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Repositories;

public class AuditLoggingRepository<TDbContext, TAuditLog> : IAuditLoggingRepository<TAuditLog>
    where TDbContext : IAuditLoggingDbContext<TAuditLog>
    where TAuditLog : AuditLog
{
    protected TDbContext DbContext;

    public AuditLoggingRepository(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<PaginatedList<TAuditLog>> GetAsync(int page = 1, int pageSize = 10)
    {
        var auditLogs = await DbContext.AuditLogs!
            .PageBy(x => x.Id, page, pageSize).PaginatedListAsync(page, pageSize);

        return auditLogs;
    }

    public async Task<PaginatedList<TAuditLog>> GetAsync(string subjectIdentifier, string subjectName, string category, int page = 1, int pageSize = 10)
    {
        var auditLogs = await DbContext.AuditLogs!
            .WhereIf(!string.IsNullOrWhiteSpace(subjectIdentifier), x => x.SubjectIdentifier == subjectIdentifier)
            .WhereIf(!string.IsNullOrWhiteSpace(subjectName), x => x.SubjectName == subjectName)
            .WhereIf(!string.IsNullOrWhiteSpace(category), x => x.Category == category)
            .PageBy(x => x.Id, page, pageSize)
            .PaginatedListAsync(page, pageSize);

        return auditLogs;
    }

    public async Task<int> SaveAsync(TAuditLog auditLog)
    {
        await DbContext.AuditLogs!.AddAsync(auditLog);

        return await DbContext.SaveChangesAsync();
    }
}
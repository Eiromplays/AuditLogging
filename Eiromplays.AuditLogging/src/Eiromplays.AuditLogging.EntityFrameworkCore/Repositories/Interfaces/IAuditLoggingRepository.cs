// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Repositories/IAuditLoggingRepository.cs
// Modified by Eirik Sjøløkken

using Eiromplays.AuditLogging.EntityFrameworkCore.Entities;
using Eiromplays.AuditLogging.EntityFrameworkCore.Helpers.Common;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Repositories.Interfaces;

public interface IAuditLoggingRepository<TAuditLog>
    where TAuditLog : AuditLog
{
    Task<int> SaveAsync(TAuditLog auditLog);

    Task<PaginatedList<TAuditLog>> GetAsync(int page = 1, int pageSize = 10);

    Task<PaginatedList<TAuditLog>> GetAsync(string subjectIdentifier, string subjectName, string category, int page = 1,
        int pageSize = 10);
}
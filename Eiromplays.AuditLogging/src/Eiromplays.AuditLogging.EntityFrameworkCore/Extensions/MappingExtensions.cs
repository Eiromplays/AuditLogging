using Eiromplays.AuditLogging.EntityFrameworkCore.Helpers.Common;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Extensions
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }
}

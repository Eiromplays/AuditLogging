﻿// Original file: https://github.com/skoruba/AuditLogging/blob/master/src/Skoruba.AuditLogging.EntityFramework/Helpers/QueryableExtensions.cs
// Modified by Eirik Sjøløkken


using System.Linq.Expressions;

namespace Eiromplays.AuditLogging.EntityFrameworkCore.Helpers;

public static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }

    public static IQueryable<T> TakeIf<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, bool condition, int limit, bool orderByDescending = true)
    {
        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        return condition
            ? query.Take(limit)
            : query;
    }

    public static IQueryable<T> PageBy<T, TKey>(this IQueryable<T> query, Expression<Func<T, TKey>> orderBy, int page, int pageSize, bool orderByDescending = true)
    {
        const int defaultPageNumber = 1;

        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        if (page <= 0)
        {
            page = defaultPageNumber;
        }

        query = orderByDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}
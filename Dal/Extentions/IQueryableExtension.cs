using Microsoft.EntityFrameworkCore;

namespace Dal.Extentions;

public static class IQueryableExtension
{
    public static async Task<IEnumerable<T>> ToPaginationListAsync<T>(this IQueryable<T> queryable, int pageSize, int pageNumber)
    {
        return await queryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    public static IEnumerable<T> ToPaginationList<T>(this IQueryable<T> queryable, int pageSize, int pageNumber)
    {
        return queryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}
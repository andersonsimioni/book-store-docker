using System.Linq;

using Server.DataLayer.Repositories.BookStore.Models;

namespace Server.DataLayer.Extensions.BookStore;

public static class QueryableExtensions{

    /// <summary>
    /// This method is used to paginate a queryable object.
    /// </summary>
    /// <typeparam name="T">The type of the queryable object.</typeparam>
    /// <param name="query">The queryable object to paginate.</param>
    /// <param name="page">The page number to return.</param>
    /// <param name="pageCount">The number of items to return per page.</param>
    /// <returns>A queryable object with the paginated results.</returns>    
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, int page, int pageCount){
        if(page >= 0 && pageCount > 0) return query.Skip(page*pageCount).Take(pageCount);
        return query;
    }

}
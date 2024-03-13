using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public static class PagedBaseResponseHelper
    {
        public static async Task<TResponse> GetResponseAsync<TResponse, T>(IQueryable<T> query, PagedBaseRequest request) where TResponse : PagedBaseResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();
            response.TotalPages = (int)Math.Abs((double)count / request.Take);
            response.TotalPageRegisters = count;

            if (string.IsNullOrEmpty(request.OrderBy))
                response.Data = await query.ToListAsync();
            else
                response.Data = query.OrderByDynamic(request.OrderBy)
                    .Skip((request.Page - 1) * request.Take)
                    .Take(request.Take)
                    .ToList();

            return response;
        }
        private static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> query, string propertyName)
        {
            return query.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null));
        }
    }
}

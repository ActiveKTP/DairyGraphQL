using DairyGraphQL.Data;
using DairyGraphQL.Models;
using HotChocolate.AspNetCore.Authorization;

namespace DairyGraphQL.GraphQL.Queries
{
    [Authorize]
    public partial class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Farm?>? GetFarm([ScopedService] AppDbContext context)
        {
            return context.Farm;
        }
    }
}
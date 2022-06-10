using DairyGraphQL.Data;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Queries
{
    public partial class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 30)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Cow?>? GetCow([ScopedService] AppDbContext context)
        {
            return context.Cow;
        }
    }
}
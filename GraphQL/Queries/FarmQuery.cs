using DairyGraphQL.Data;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Queries
{
    public partial class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Farm?>? GetFarm([ScopedService] AppDbContext context)
        {
            return context.Farm;
        }
    }
}
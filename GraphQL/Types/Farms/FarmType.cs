using DairyGraphQL.Data;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Types.Farms
{
    public class FarmType : ObjectType<Farm>
    {
        protected override void Configure(IObjectTypeDescriptor<Farm> descriptor)
        {
            descriptor
                .Field(p => p.Cows)
                //.ResolveWith<Resolvers>(p => p.GetCows(default!, default!))
                //.UseDbContext<AppDbContext>()
                .Description("This is the list of cows in Farm.");
        }

        /*private class Resolvers
        {
            public IQueryable<Cow?>? GetCows(Farm farm, [ScopedService] AppDbContext context)
            {
                return context.Cow?.Where(p => p.cFarmId == farm.fFarmId);
            }
        }*/
    }
}
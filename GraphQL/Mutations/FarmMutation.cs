using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Types.Farms;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Mutations
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddFarmPayload> AddFarmAsync(AddFarmInput input, [ScopedService] AppDbContext context)
        {
            var farm = new Farm
            {
                fFarmId = input.fFarmId,
                fName = input.fName,
                fStatus = input.fStatus,
                fAmphurCode = input.fAmphurCode,
                fProvinceCode = input.fProvinceCode,
                aiZone = input.aiZone
            };
            context.Farm?.Add(farm);
            await context.SaveChangesAsync();

            return new AddFarmPayload(farm);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddFarmPayload> UpdateFarmAsync(string id, AddFarmInput input, [ScopedService] AppDbContext context)
        {
            if (id != input.fFarmId)
            {
                throw new GraphQLException(new Error("Bad Request.", "BAD_REQUEST"));
            }

            Farm? farm = context.Farm?.FirstOrDefault(x => x.fFarmId == id);

            if (farm == null)
            {
                throw new GraphQLException(new Error("Farm not found.", "FARM_NOT_FOUND"));
            }

            farm.fName = input.fName;
            farm.fStatus = input.fStatus;
            farm.fAmphurCode = input.fAmphurCode;
            farm.fProvinceCode = input.fProvinceCode;
            farm.aiZone = input.aiZone;
            //context.Entry(farm).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return new AddFarmPayload(farm);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteFarmAsync(string id, [ScopedService] AppDbContext context)
        {
            Farm? farm = context.Farm?.FirstOrDefault(x => x.fFarmId == id);

            if (farm == null)
            {
                throw new GraphQLException(new Error("Farm not found.", "FARM_NOT_FOUND"));
            }

            context.Farm?.Remove(farm);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Types.Semens;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Mutations
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddSemenPayload> AddSemenAsync(AddSemenInput input, [ScopedService] AppDbContext context)
        {
            var semen = new Semen
            {
                sSemenId = input.sSemenId,
                sSemenBatch = input.sSemenBatch,
                sSemenSource = input.sSemenSource,
                sOrgProd = input.sOrgProd,
                sCountryCode = input.sCountryCode,
                sCollectionDate = input.sCollectionDate,
                sSemenType = input.sSemenType,
                sSemenVol = input.sSemenVol,
                sBullStatus = input.sBullStatus,
                sStaffId = input.sStaffId
            };
            context.Semen?.Add(semen);
            await context.SaveChangesAsync();

            return new AddSemenPayload(semen);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddSemenPayload> UpdateSemenAsync(string id, AddSemenInput input, [ScopedService] AppDbContext context)
        {
            if (id != input.sSemenId)
            {
                throw new GraphQLException(new Error("Bad Request.", "BAD_REQUEST"));
            }

            Semen? semen = context.Semen?.FirstOrDefault(x => x.sSemenId == id);

            if (semen == null)
            {
                throw new GraphQLException(new Error("Semen not found.", "SEMEN_NOT_FOUND"));
            }

            semen.sSemenBatch = input.sSemenBatch;
            semen.sSemenSource = input.sSemenSource;
            semen.sOrgProd = input.sOrgProd;
            semen.sCountryCode = input.sCountryCode;
            semen.sCollectionDate = input.sCollectionDate;
            semen.sSemenType = input.sSemenType;
            semen.sSemenVol = input.sSemenVol;
            semen.sBullStatus = input.sBullStatus;
            semen.sStaffId = input.sStaffId;

            await context.SaveChangesAsync();

            return new AddSemenPayload(semen);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteSemenAsync(string id, [ScopedService] AppDbContext context)
        {
            Semen? semen = context.Semen?.FirstOrDefault(x => x.sSemenId == id);

            if (semen == null)
            {
                throw new GraphQLException(new Error("Semen not found.", "SEMEN_NOT_FOUND"));
            }

            context.Semen?.Remove(semen);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
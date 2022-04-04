using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Types.Cows;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Mutations
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCowPayload> AddCowAsync(AddCowInput input, [ScopedService] AppDbContext context)
        {
            var cow = new Cow
            {
                ccowId = input.ccowId,
                ccowName = input.ccowName,
                cSex = input.cSex,
                cSireId = input.cSireId,
                cDamId = input.cDamId,
                cBirthDate = input.cBirthDate,
                cStatus = input.cStatus,
                cProductionStatus = input.cProductionStatus,
                cMilkingStatus = input.cMilkingStatus,
                cFarmId = input.cFarmId,
                cActiveFlag = 1
            };

            context.Cow?.Add(cow);
            await context.SaveChangesAsync();

            return new AddCowPayload(cow);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCowPayload> UpdateCowAsync(string id, AddCowInput input, [ScopedService] AppDbContext context)
        {
            if (id != input.ccowId)
            {
                throw new GraphQLException(new Error("Bad Request.", "BAD_REQUEST"));
            }

            Cow? cow = context.Cow?.FirstOrDefault(x => x.ccowId == id);

            if (cow == null)
            {
                throw new GraphQLException(new Error("Farm not found.", "FARM_NOT_FOUND"));
            }

            cow.ccowName = input.ccowName;
            cow.cSex = input.cSex;
            cow.cSireId = input.cSireId;
            cow.cDamId = input.cDamId;
            cow.cBirthDate = input.cBirthDate;
            cow.cStatus = input.cStatus;
            cow.cProductionStatus = input.cProductionStatus;
            cow.cMilkingStatus = input.cMilkingStatus;
            cow.cFarmId = input.cFarmId;

            await context.SaveChangesAsync();

            return new AddCowPayload(cow);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteCowAsync(string id, [ScopedService] AppDbContext context)
        {
            Cow? cow = context.Cow?.FirstOrDefault(x => x.ccowId == id);

            if (cow == null)
            {
                throw new GraphQLException(new Error("Cow not found.", "COW_NOT_FOUND"));
            }

            context.Cow?.Remove(cow);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
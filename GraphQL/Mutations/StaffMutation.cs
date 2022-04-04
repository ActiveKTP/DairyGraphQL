using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Types.Staffs;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Mutations
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddStaffPayload> AddStaffAsync(AddStaffInput input, [ScopedService] AppDbContext context)
        {
            var staff = new Staff
            {
                staffId = input.staffId,
                staffPrefix = input.staffPrefix,
                staffFName = input.staffFName,
                staffLName = input.staffLName,
                staffSex = input.staffSex,
                staffMobileNo = input.staffMobileNo,
                staffEmailAddress = input.staffEmailAddress,
                staffOrgId = input.staffOrgId,
                sActiveFlag = 1
            };
            context.Staff?.Add(staff);
            await context.SaveChangesAsync();

            return new AddStaffPayload(staff);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddStaffPayload> UpdateStaffAsync(string id, AddStaffInput input, [ScopedService] AppDbContext context)
        {
            if (id != input.staffId)
            {
                throw new GraphQLException(new Error("Bad Request.", "BAD_REQUEST"));
            }

            Staff? staff = context.Staff?.FirstOrDefault(x => x.staffId == id);

            if (staff == null)
            {
                throw new GraphQLException(new Error("Staff not found.", "STAFF_NOT_FOUND"));
            }

            staff.staffPrefix = input.staffPrefix;
            staff.staffFName = input.staffFName;
            staff.staffLName = input.staffLName;
            staff.staffSex = input.staffSex;
            staff.staffMobileNo = input.staffMobileNo;
            staff.staffEmailAddress = input.staffEmailAddress;
            staff.staffOrgId = input.staffOrgId;

            await context.SaveChangesAsync();

            return new AddStaffPayload(staff);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteStaffAsync(string id, [ScopedService] AppDbContext context)
        {
            Staff? staff = context.Staff?.FirstOrDefault(x => x.staffId == id);

            if (staff == null)
            {
                throw new GraphQLException(new Error("Staff not found.", "STAFF_NOT_FOUND"));
            }

            context.Staff?.Remove(staff);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
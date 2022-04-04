using DairyGraphQL.Data;
using DairyGraphQL.GraphQL.Types.Organizations;
using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Mutations
{
    public partial class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddOrgPayload> AddOrganizationAsync(AddOrgInput input, [ScopedService] AppDbContext context)
        {
            var organization = new Organization
            {
                orgCode = input.orgCode,
                orgType = input.orgType,
                orgName = input.orgName,
                orgAddress = input.orgAddress,
                orgTumbolCode = input.orgTumbolCode,
                orgAmphurCode = input.orgAmphurCode,
                orgProvinceCode = input.orgProvinceCode,
            };
            context.Organization?.Add(organization);
            await context.SaveChangesAsync();

            return new AddOrgPayload(organization);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddOrgPayload> UpdateOrganizationAsync(string id, AddOrgInput input, [ScopedService] AppDbContext context)
        {
            if (id != input.orgCode)
            {
                throw new GraphQLException(new Error("Bad Request.", "BAD_REQUEST"));
            }

            Organization? organization = context.Organization?.FirstOrDefault(x => x.orgCode == id);

            if (organization == null)
            {
                throw new GraphQLException(new Error("Organization not found.", "ORGANIZATION_NOT_FOUND"));
            }

            organization.orgType = input.orgType;
            organization.orgName = input.orgName;
            organization.orgAddress = input.orgAddress;
            organization.orgTumbolCode = input.orgTumbolCode;
            organization.orgAmphurCode = input.orgAmphurCode;
            organization.orgProvinceCode = input.orgProvinceCode;

            await context.SaveChangesAsync();

            return new AddOrgPayload(organization);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<bool> DeleteOrganizationAsync(string id, [ScopedService] AppDbContext context)
        {
            Organization? organization = context.Organization?.FirstOrDefault(x => x.orgCode == id);

            if (organization == null)
            {
                throw new GraphQLException(new Error("Organization not found.", "ORGANIZATION_NOT_FOUND"));
            }

            context.Organization?.Remove(organization);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
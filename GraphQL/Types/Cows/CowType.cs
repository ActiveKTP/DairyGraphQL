using DairyGraphQL.Models;

namespace DairyGraphQL.GraphQL.Types.Cows
{
    public class CowType : ObjectType<Cow>
    {
        protected override void Configure(IObjectTypeDescriptor<Cow> descriptor)
        {
            /*descriptor
                .Field(p => p.ccowNo)
                .Description("ccowNo property from Cow object");*/
        }

    }
}
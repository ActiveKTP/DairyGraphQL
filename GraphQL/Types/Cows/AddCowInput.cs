namespace DairyGraphQL.GraphQL.Types.Cows
{
    public record AddCowInput(string ccowId,
        string ccowName,
        string cSex,
        string cSireId,
        string cDamId,
        DateTime cBirthDate,
        string cStatus,
        string cProductionStatus,
        string cMilkingStatus,
        string cFarmId
        );
}
using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace DairyGraphQL.GraphQL.Types.Farms
{
    /*public record AddFarmInput(
        string fFarmId,
        string fName,
        string fStatus,
        string fAmphurCode,
        string fProvinceCode,
        string aiZone);*/
    [Validatable]
    public class AddFarmInput
    {
        [Required, StringLength(10, ErrorMessage = "{0} must be 10 characters.")]
        public string? fFarmId { get; set; }

        [Required, StringLength(100, ErrorMessage = "{0} is required.")]
        public string? fName { get; set; }

        [Required, StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? fStatus { get; set; }

        [Required, StringLength(4, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 4)]
        public string? fAmphurCode { get; set; }

        [Required, StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? fProvinceCode { get; set; }

        [Required, StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? aiZone { get; set; }
    }
}
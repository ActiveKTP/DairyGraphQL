using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace DairyGraphQL.GraphQL.Types.Organizations
{
    [Validatable]
    public class AddOrgInput
    {
        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? orgCode { get; set; }

        [Required, StringLength(3, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 3)]
        public string? orgType { get; set; }

        [Required, StringLength(100, ErrorMessage = "{0} is required.")]
        public string? orgName { get; set; }

        [Required, StringLength(50, ErrorMessage = "{0} is required.")]
        public string? orgAddress { get; set; }

        [Required, StringLength(6, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 6)]
        public string? orgTumbolCode { get; set; }

        [Required, StringLength(4, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 4)]
        public string? orgAmphurCode { get; set; }

        [Required, StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? orgProvinceCode { get; set; }
    }
}
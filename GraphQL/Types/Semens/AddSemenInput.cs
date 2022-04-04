using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace DairyGraphQL.GraphQL.Types.Semens
{
    [Validatable]
    public class AddSemenInput
    {
        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? sSemenId { get; set; }

        [Required, StringLength(8, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? sSemenBatch { get; set; }

        [StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? sSemenSource { get; set; }

        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? sOrgProd { get; set; }

        [StringLength(3, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 3)]
        public string? sCountryCode { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime? sCollectionDate { get; set; }

        [StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? sSemenType { get; set; }

        public string? sSemenVol { get; set; }

        public string? sBullStatus { get; set; }

        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? sStaffId { get; set; }
    }
}
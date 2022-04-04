using System.ComponentModel.DataAnnotations;
using Graph.ArgumentValidator;

namespace DairyGraphQL.GraphQL.Types.Staffs
{
    [Validatable]
    public class AddStaffInput
    {
        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? staffId { get; set; }

        [StringLength(2, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 2)]
        public string? staffPrefix { get; set; }

        [Required, StringLength(100, ErrorMessage = "{0} is required.")]
        public string? staffFName { get; set; }

        [Required, StringLength(100, ErrorMessage = "{0} is required.")]
        public string? staffLName { get; set; }

        [StringLength(1, ErrorMessage = "{0} must be {2} characters.", MinimumLength = 1)]
        public string? staffSex { get; set; }

        [StringLength(10, ErrorMessage = "{0} must be {2} digit number", MinimumLength = 10)]
        public string? staffMobileNo { get; set; }

        [Required, EmailAddress(ErrorMessage = "{0} format is invalid.")]
        public string? staffEmailAddress { get; set; }

        [Required, StringLength(15, ErrorMessage = "{0} length can't be more than {1} characters.")]
        public string? staffOrgId { get; set; }

        //[StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    }
}
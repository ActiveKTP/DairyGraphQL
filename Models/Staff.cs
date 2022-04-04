using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DairyGraphQL.Models.Ref;

namespace DairyGraphQL.Models
{
    public class Staff
    {

        [Key]
        public string? staffId { get; set; }

        public string? staffPrefix { get; set; }
        [ForeignKey("staffPrefix")]
        public RefTitle? refTitle { get; set; }

        public string? staffFName { get; set; }

        public string? staffLName { get; set; }

        public string? staffSex { get; set; }
        [ForeignKey("staffSex")]
        public RefStaffSex? refStaffSex { get; set; }

        public string? staffMobileNo { get; set; }

        public string? staffEmailAddress { get; set; }

        public int? sActiveFlag { get; set; }

        public string? staffOrgId { get; set; }
        [ForeignKey("staffOrgId")]
        public Organization? Organization { get; set; }

    }
}
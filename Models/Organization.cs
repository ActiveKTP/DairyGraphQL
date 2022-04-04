using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DairyGraphQL.Models.Ref;

namespace DairyGraphQL.Models
{
    public class Organization
    {
        [Key]
        public string? orgCode { get; set; }
        public string? orgType { get; set; }
        public string? orgName { get; set; }
        public string? orgAddress { get; set; }

        public string? orgTumbolCode { get; set; }
        [ForeignKey("orgTumbolCode")]
        public RefTumbol? refTumbol { get; set; }

        public string? orgAmphurCode { get; set; }
        [ForeignKey("orgAmphurCode")]
        public RefAmphur? refAmphur { get; set; }

        public string? orgProvinceCode { get; set; }
        [ForeignKey("orgProvinceCode")]
        public RefProvince? refProvince { get; set; }

        [UseSorting]
        public ICollection<Staff> Staffs { get; set; } = new List<Staff>();
    }
}
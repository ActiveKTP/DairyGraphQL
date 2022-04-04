using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DairyGraphQL.Models.Ref;

namespace DairyGraphQL.Models
{
    public class Farm
    {
        [Key]
        [StringLength(10)]
        public string? fFarmId { get; set; }

        [StringLength(100)]
        public string? fName { get; set; }

        [StringLength(2)]
        public string? fStatus { get; set; }
        [ForeignKey("fStatus")]
        public RefFarmStatus? refFarmStatus { get; set; }

        public string? fAmphurCode { get; set; }
        [ForeignKey("fAmphurCode")]
        public RefAmphur? refAmphur { get; set; }

        public string? fProvinceCode { get; set; }
        [ForeignKey("fProvinceCode")]
        public RefProvince? refProvince { get; set; }

        public string? aiZone { get; set; }

        [UseSorting]
        public ICollection<Cow> Cows { get; set; } = new List<Cow>();
    }
}
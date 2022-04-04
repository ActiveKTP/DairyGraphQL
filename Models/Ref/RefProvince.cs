using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefProvince
    {
        [Key]
        public string? refProvinceId { get; set; }
        public string? refProvinceName { get; set; }
    }
}
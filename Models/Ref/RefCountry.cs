using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefCountry
    {
        [Key]
        public string? refCountryId { get; set; }
        public string? refCountryName { get; set; }
    }
}
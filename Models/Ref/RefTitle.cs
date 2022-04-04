using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefTitle
    {
        [Key]
        public string? refPrefixId { get; set; }
        public string? refPrefixName { get; set; }
    }
}
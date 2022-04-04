using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefTumbol
    {
        [Key]
        public string? refTumbolId { get; set; }
        public string? refTumbolName { get; set; }
    }
}
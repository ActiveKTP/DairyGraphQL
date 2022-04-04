using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefAmphur
    {
        [Key]
        public string? refAmphurId { get; set; }
        public string? refAmphurName { get; set; }
    }
}
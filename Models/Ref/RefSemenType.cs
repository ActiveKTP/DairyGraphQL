using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefSemenType
    {
        [Key]
        public string? refSemenTypeId { get; set; }
        public string? refSemenTypeName { get; set; }
    }
}
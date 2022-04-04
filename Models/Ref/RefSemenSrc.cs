using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefSemenSrc
    {
        [Key]
        public string? refSemenSrcId { get; set; }
        public string? refSemenSrcName { get; set; }
    }
}
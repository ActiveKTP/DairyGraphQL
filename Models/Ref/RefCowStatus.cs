using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefCowStatus
    {
        [Key]
        public string? refCStatusId { get; set; }
        public string? refCStatusName { get; set; }
    }
}
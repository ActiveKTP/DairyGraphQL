using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefMilkStatus
    {
        [Key]
        public string? refMilkStatusId { get; set; }
        public string? refMilkStatusName { get; set; }
    }
}
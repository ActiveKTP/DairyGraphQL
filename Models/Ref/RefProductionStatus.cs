using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefProductionStatus
    {
        [Key]
        public string? refProdStatusId { get; set; }
        public string? refProdStatusName { get; set; }
    }
}
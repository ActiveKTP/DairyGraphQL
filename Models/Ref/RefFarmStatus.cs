using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefFarmStatus
    {
        [Key]
        public string? refFStatusId { get; set; }
        public string? refFstatusName { get; set; }
    }
}
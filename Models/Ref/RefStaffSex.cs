using System.ComponentModel.DataAnnotations;

namespace DairyGraphQL.Models.Ref
{
    public class RefStaffSex
    {
        [Key]
        public string? refSSexId { get; set; }
        public string? refSSexName { get; set; }
    }
}
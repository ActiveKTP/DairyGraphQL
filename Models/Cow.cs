using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DairyGraphQL.Models.Ref;

namespace DairyGraphQL.Models
{
    public class Cow
    {
        [Key]
        public int? ccowNo { get; set; }
        public string? ccowId { get; set; } = String.Empty;
        public string? ccowName { get; set; } = String.Empty;
        public string? cSex { get; set; }
        public string? cSireId { get; set; }
        public string? cDamId { get; set; }
        public DateTime? cBirthDate { get; set; }

        public string? cStatus { get; set; }
        [ForeignKey("cStatus")]
        public RefCowStatus? refCowStatus { get; set; }

        public string? cProductionStatus { get; set; }
        [ForeignKey("cProductionStatus")]
        public RefProductionStatus? refProductionStatus { get; set; }

        public string? cMilkingStatus { get; set; }
        [ForeignKey("cMilkingStatus")]
        public RefMilkStatus? refMilkStatus { get; set; }

        public int? cLactation { get; set; }
        public int? cNumOfService { get; set; }
        public int? cActiveFlag { get; set; }

        public string? cFarmId { get; set; }

        public Farm? Farm { get; set; }

        public ICollection<Semen> Semens { get; set; } = new List<Semen>();
    }
}
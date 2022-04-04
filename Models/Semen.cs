using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DairyGraphQL.Models.Ref;

namespace DairyGraphQL.Models
{
    public class Semen
    {
        [Key]
        public string? sSemenId { get; set; }
        public string? sSemenBatch { get; set; }

        public string? sSemenSource { get; set; }
        [ForeignKey("sSemenSource")]
        public RefSemenSrc? refSemenSrc { get; set; }

        public string? sOrgProd { get; set; }
        [ForeignKey("sOrgProd")]
        public Organization? Organization { get; set; }

        public string? sCountryCode { get; set; }
        [ForeignKey("sCountryCode")]
        public RefCountry? refCountry { get; set; }

        public DateTime? sCollectionDate { get; set; }


        public string? sSemenType { get; set; }
        [ForeignKey("sSemenType")]
        public RefSemenType? refSemenType { get; set; }

        public string? sSemenVol { get; set; }
        public string? sBullStatus { get; set; }

        public string? sStaffId { get; set; }
        [ForeignKey("sStaffId")]
        public Staff? Staff { get; set; }

        public Cow? Cow { get; set; }
    }
}
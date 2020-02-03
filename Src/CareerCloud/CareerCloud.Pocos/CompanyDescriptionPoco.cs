using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
   public class CompanyDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; } 
        [ForeignKey("FK_Company_Descriptions_Company_Profiles")]
        public Guid Company { get; set; }
        [Column("LanguageID")][ForeignKey("FK_Company_Descriptions_System_Language_Codes")]
        public string LanguageId { get; set; }
        [Column("Company_Name")]
        public string CompanyName { get; set; }
        [Column("Company_Description")]
        public string CompanyDescription { get; set; }
        [Column("Time_Stamp")]
        [NotMapped]
        public byte[] TimeStamp { get; set; }

        public virtual CompanyProfilePoco CompanyProfile { get; set; }

        public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }

    }
}

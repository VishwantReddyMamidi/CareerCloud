using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
   public class CompanyJobEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("FK_Company_Job_Educations_Company_Jobs")]
        public Guid Job { get; set; }
        public string Major { get; set; }
        public short Importance { get; set; }
        [Column("Time_Stamp")]
        [NotMapped]
        public byte[] TimeStamp { get; set; }
        
        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}

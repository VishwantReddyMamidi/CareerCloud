using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("FK_Security_Logins_Log_Security_Logins")]
        public Guid Login { get; set; }
        [Column("Source_IP")]
        public string SourceIP { get; set; }
        [Column("Logon_Date")]
        public DateTime LogonDate { get; set; }
        [Column("Is_Succesful")]
        public bool IsSuccesful { get; set; }

        public virtual SecurityLoginPoco SecurityLogin { get; set; }
    }
}

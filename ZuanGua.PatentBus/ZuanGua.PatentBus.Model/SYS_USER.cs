namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USER
    {
        [Key]
        [StringLength(100)]
        public string USERID { get; set; }

        [StringLength(200)]
        public string USERNAME { get; set; }

        [StringLength(100)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string MOBILE { get; set; }

        public DateTime? CREATETIME { get; set; }

        public int? UserRole { get; set; }

        [StringLength(100)]
        public string InviteCode { get; set; }

        [StringLength(100)]
        public string MyInviteCode { get; set; }

        public int? Point { get; set; }
    }
}

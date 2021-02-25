namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SMS_Send
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(15)]
        public string sender { get; set; }

        [StringLength(15)]
        public string smsCode { get; set; }

        [StringLength(300)]
        public string smsNote { get; set; }

        public DateTime? createTime { get; set; }
    }
}

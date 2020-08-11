namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complaint")]
    public partial class Complaint
    {
        [StringLength(50)]
        public string ComplaintID { get; set; }

        [StringLength(50)]
        public string CommodityID { get; set; }

        [StringLength(500)]
        public string ComplaintDescription { get; set; }

        public DateTime? ComplaintTime { get; set; }

        public int? ReviewState { get; set; }

        [StringLength(50)]
        public string ReviewUser { get; set; }

        public DateTime? ReviewTime { get; set; }
    }
}

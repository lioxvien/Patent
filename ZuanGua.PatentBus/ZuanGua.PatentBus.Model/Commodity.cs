namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commodity")]
    public partial class Commodity
    {
        [StringLength(50)]
        public string CommodityID { get; set; }

        [StringLength(50)]
        public string AuthorizationNumber { get; set; }

        [StringLength(50)]
        public string CommodityType { get; set; }

        [StringLength(50)]
        public string CommodityName { get; set; }

        [StringLength(50)]
        public string CommodityField { get; set; }

        public int? SalePrice { get; set; }

        [StringLength(50)]
        public string CommodityState { get; set; }

        [StringLength(50)]
        public string LinkMobile { get; set; }

        public int? ComplaintCount { get; set; }

        public DateTime? ReviewTime { get; set; }

        public int? ReviewStatus { get; set; }

        [StringLength(50)]
        public string ReviewUser { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}

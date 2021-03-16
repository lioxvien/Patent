namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Buying")]
    public partial class Buying
    {
        [Key]
        [StringLength(50)]
        public string CommodityID { get; set; }

        [StringLength(50)]
        public string CommodityType { get; set; }

        [StringLength(50)]
        public string CommodityField { get; set; }

        public int? SalePrice { get; set; }

        [StringLength(50)]
        public string CommodityState { get; set; }

        [StringLength(50)]
        public string LinkMobile { get; set; }

        public DateTime? ReviewTime { get; set; }

        public int? ReviewStatus { get; set; }

        [StringLength(50)]
        public string ReviewUser { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUser { get; set; }
    }
}

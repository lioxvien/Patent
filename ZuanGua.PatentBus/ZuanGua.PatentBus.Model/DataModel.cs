namespace ZuanGua.PatentBus.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DataModel”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“ZuanGua.PatentBus.Model.DataModel”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DataModel”
        //连接字符串。
        public DataModel()
            : base("name=DataModel")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<SYS_USER> SYS_USER { get; set; }
        public virtual DbSet<Commodity> Commodity { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<SMS_Send> SMS_Send { get; set; }
        public virtual DbSet<SMS_Send_log> SMS_Send_log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.MOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.InviteCode)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_USER>()
                .Property(e => e.MyInviteCode)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.CommodityID)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.AuthorizationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.CommodityType)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.CommodityName)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.CommodityField)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.CommodityState)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.LinkMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Commodity>()
                .Property(e => e.ReviewUser)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.ComplaintID)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.CommodityID)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.ComplaintDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.ReviewUser)
                .IsUnicode(false);
            modelBuilder.Entity<SMS_Send>()
    .Property(e => e.smsCode)
    .IsFixedLength()
    .IsUnicode(false);

            modelBuilder.Entity<SMS_Send_log>()
                .Property(e => e.smsCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SMS_Send_log>()
                .Property(e => e.ErrorDes)
                .IsUnicode(false);
        }
    }
}
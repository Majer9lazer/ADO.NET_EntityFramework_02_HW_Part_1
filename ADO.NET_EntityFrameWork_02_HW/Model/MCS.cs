namespace ADO.NET_EntityFrameWork_02_HW.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MCS : DbContext
    {
        public MCS()
            : base("name=MCS")
        {
        }

        public virtual DbSet<newEquipment> newEquipments { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public virtual DbSet<TablesModel> TablesModels { get; set; }
        public virtual DbSet<TablesSNPrefix> TablesSNPrefixes { get; set; }
        public virtual DbSet<TablesStopReason> TablesStopReasons { get; set; }
        public virtual DbSet<TrackMeter> TrackMeters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

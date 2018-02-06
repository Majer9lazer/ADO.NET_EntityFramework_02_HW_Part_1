namespace ADO.NET_EntityFrameWork_02_HW.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesSNPrefix")]
    public partial class TablesSNPrefix
    {
        [Key]
        public int intSNPrefixID { get; set; }

        [StringLength(5)]
        public string strPrefix { get; set; }

        public int? intModelID { get; set; }

        public virtual TablesModel TablesModel { get; set; }
    }
}

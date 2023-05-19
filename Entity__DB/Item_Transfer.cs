namespace Entity__DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_Transfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int T_Id { get; set; }

        public int FromStore_Id { get; set; }

        public int ToStore_Id { get; set; }

        public int Sup_Id { get; set; }

        public int Item_count { get; set; }

        public int Item_Code { get; set; }

        [Column(TypeName = "date")]
        public DateTime Prod_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime Validity_Period { get; set; }

        public virtual Store Store { get; set; }

        public virtual Item Item { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Store Store1 { get; set; }
        [Column(TypeName = "date")]
        public virtual DateTime Transfer_Date { get; set; }
    }
}

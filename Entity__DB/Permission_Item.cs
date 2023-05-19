namespace Entity__DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permission_Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int P_Id { get; set; }

        public int Perm_Id { get; set; }

        public int Item_Code { get; set; }

        public int Item_count { get; set; }

        public virtual Item Item { get; set; }

        public virtual PermissionRequest PermissionRequest { get; set; }
    }
}

namespace Entity__DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissionRequest")]
    public partial class PermissionRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionRequest()
        {
            Permission_Item = new HashSet<Permission_Item>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Perm_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Perm_Type { get; set; }

        public int Store_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Perm_Date { get; set; }

        public int Sup_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission_Item> Permission_Item { get; set; }

        public virtual Store Store { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}

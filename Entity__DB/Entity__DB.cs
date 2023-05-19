using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Entity__DB
{
    public partial class Entity__DB : DbContext
    {
        public Entity__DB()
            : base("name=Entity__DB")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item_Transfer> Item_Transfer { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Permission_Item> Permission_Item { get; set; }
        public virtual DbSet<PermissionRequest> PermissionRequests { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Store_item> Store_item { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Customer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .Property(e => e.Item_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Item_Transfer)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Measurements)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Permission_Item)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Store_item)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Measurement>()
                .Property(e => e.measure_Name)
                .IsUnicode(false);

            modelBuilder.Entity<PermissionRequest>()
                .Property(e => e.Perm_Type)
                .IsUnicode(false);

            modelBuilder.Entity<PermissionRequest>()
                .HasMany(e => e.Permission_Item)
                .WithRequired(e => e.PermissionRequest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Store_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Store_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Manager_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Item_Transfer)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.FromStore_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Item_Transfer1)
                .WithRequired(e => e.Store1)
                .HasForeignKey(e => e.ToStore_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.PermissionRequests)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Store_item)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Supplier_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Item_Transfer)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Sup_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PermissionRequests)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Sup_Id)
                .WillCascadeOnDelete(false);
        }
    }
}

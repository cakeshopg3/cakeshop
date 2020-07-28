namespace ShopManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<size> sizes { get; set; }
        public virtual DbSet<color> colors { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<ward> wards { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<orders_item> orders_item { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orders_item>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<user>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}

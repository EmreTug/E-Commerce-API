// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prasoft.Data
{
    public partial class PrapazdbContext : DbContext
    {
        public PrapazdbContext()
        {
        }

        public PrapazdbContext(DbContextOptions<PrapazdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductVariant> ProductVariant { get; set; }
        public virtual DbSet<ProductVariantGroup> ProductVariantGroup { get; set; }
        public virtual DbSet<VariantName> VariantName { get; set; }
        public virtual DbSet<VariantPicture> VariantPicture { get; set; }
        public virtual DbSet<VariantValue> VariantValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=PraPazDB;Integrated Security=True");
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PraPazDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Order__47DBAE45");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Produ__48CFD27E");

                entity.HasOne(d => d.ProductVariantGroup)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.ProductVariantGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Produ__46E78A0C");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerMailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerTaxAdministration)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.Picture1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Picture)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Picture__Product__49C3F6B7");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Categories");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasOne(d => d.ProductVariantGroup)
                    .WithMany(p => p.ProductVariant)
                    .HasForeignKey(d => d.ProductVariantGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductVa__Produ__4BAC3F29");

                entity.HasOne(d => d.VariantName)
                    .WithMany(p => p.ProductVariant)
                    .HasForeignKey(d => d.VariantNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductVa__Varia__4CA06362");

                entity.HasOne(d => d.VariantValue)
                    .WithMany(p => p.ProductVariant)
                    .HasForeignKey(d => d.VariantValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductVa__Varia__4D94879B");
            });

            modelBuilder.Entity<ProductVariantGroup>(entity =>
            {
                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariantGroup)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductVa__Produ__4E88ABD4");
            });

            modelBuilder.Entity<VariantName>(entity =>
            {
                entity.Property(e => e.VariantName1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VariantName");
            });

            modelBuilder.Entity<VariantPicture>(entity =>
            {
                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.VariantPicture)
                    .HasForeignKey(d => d.PictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantPi__Pictu__4F7CD00D");

                entity.HasOne(d => d.ProductVariantGroup)
                    .WithMany(p => p.VariantPicture)
                    .HasForeignKey(d => d.ProductVariantGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantPi__Produ__5070F446");
            });

            modelBuilder.Entity<VariantValue>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.VariantName)
                    .WithMany(p => p.VariantValue)
                    .HasForeignKey(d => d.VariantNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VariantVa__Varia__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
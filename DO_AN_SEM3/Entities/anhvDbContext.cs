using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DO_AN_SEM3.Entities
{
    public partial class anhvDbContext : DbContext
    {
        public anhvDbContext()
            : base("name=anhvDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongTinSanPham> ThongTinSanPhams { get; set; }
        public virtual DbSet<TinhThanh> TinhThanhs { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<XaPhuong> XaPhuongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Seotitle)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Seotitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.KichThuocManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.DoPhanGiai)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.CameraTruoc)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.CameraSau)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.Ram)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.Rom)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.TrongLuong)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.KichThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.ChipSet)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinSanPham>()
                .Property(e => e.LoaiPin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}

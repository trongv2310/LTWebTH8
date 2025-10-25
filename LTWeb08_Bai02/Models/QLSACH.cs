using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTWeb08_Bai02.Models
{
    public partial class QLSACH : DbContext
    {
        public QLSACH()
            : base("name=QLSACH")
        {
        }

        public virtual DbSet<CHITIETDONDATHANG> CHITIETDONDATHANG { get; set; }
        public virtual DbSet<CHUDE> CHUDE { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANG { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBAN { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<TACGIA> TACGIA { get; set; }
        public virtual DbSet<VIETSACH> VIETSACH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONDATHANG>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.TriGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONDATHANG)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETDONDATHANG)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.VIETSACH)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.VIETSACH)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);
        }
    }
}

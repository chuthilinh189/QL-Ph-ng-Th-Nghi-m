namespace QLPhongThiNghhiem.DBContext
{
     using System;
     using System.Data.Entity;
     using System.ComponentModel.DataAnnotations.Schema;
     using System.Linq;
     using System.Runtime.InteropServices;

     public partial class DBPTNContext : DbContext
     {
          public DBPTNContext()
              : base("name=DBPTNContext")
          {
          }

          public static DBPTNContext context = new DBPTNContext();
          public virtual DbSet<BaiThiNghiem> BaiThiNghiem { get; set; }
          public virtual DbSet<BanDangKy> BanDangKy { get; set; }
          public virtual DbSet<ChiTietDangKi> ChiTietDangKi { get; set; }
          public virtual DbSet<ChiTietSuDung> ChiTietSuDung { get; set; }
          public virtual DbSet<ChiTietTTBCanDung> ChiTietTTBCanDung { get; set; }
          public virtual DbSet<GiaoVien> GiaoVien { get; set; }
          public virtual DbSet<LoaiTTB> LoaiTTB { get; set; }
          public virtual DbSet<NhanVien> NhanVien { get; set; }
          public virtual DbSet<NhaSanXuat> NhaSanXuat { get; set; }
          public virtual DbSet<PhongThiNghiem> PhongThiNghiem { get; set; }
          public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
          public virtual DbSet<TaiKhoanGV> TaiKhoanGV { get; set; }
          public virtual DbSet<TaiKhoanNV> TaiKhoanNV { get; set; }
          public virtual DbSet<TrangThietBi> TrangThietBi { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Entity<BaiThiNghiem>()
                   .Property(e => e.MaBTN)
                   .IsUnicode(false);

               modelBuilder.Entity<BaiThiNghiem>()
                   .HasMany(e => e.ChiTietDangKi)
                   .WithRequired(e => e.BaiThiNghiem)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<BaiThiNghiem>()
                   .HasMany(e => e.ChiTietTTBCanDung)
                   .WithRequired(e => e.BaiThiNghiem)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<BanDangKy>()
                   .Property(e => e.MaDangKy)
                   .IsUnicode(false);

               modelBuilder.Entity<BanDangKy>()
                   .Property(e => e.MaGV)
                   .IsUnicode(false);

               modelBuilder.Entity<BanDangKy>()
                   .HasMany(e => e.ChiTietDangKi)
                   .WithRequired(e => e.BanDangKy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.MaCTDK)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.MaNV)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.MaPTN)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.MaDangKy)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.MaBTN)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .Property(e => e.CaTrongNgay)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietDangKi>()
                   .HasMany(e => e.ChiTietSuDung)
                   .WithRequired(e => e.ChiTietDangKi)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<ChiTietSuDung>()
                   .Property(e => e.MaChiTietSD)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietSuDung>()
                   .Property(e => e.MaCTDK)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietSuDung>()
                   .Property(e => e.MaTTB)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietTTBCanDung>()
                   .Property(e => e.MaChiTiet)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietTTBCanDung>()
                   .Property(e => e.MaBTN)
                   .IsUnicode(false);

               modelBuilder.Entity<ChiTietTTBCanDung>()
                   .Property(e => e.MaLTTB)
                   .IsUnicode(false);

               modelBuilder.Entity<GiaoVien>()
                   .Property(e => e.MaGV)
                   .IsUnicode(false);

               modelBuilder.Entity<GiaoVien>()
                   .Property(e => e.MaTK)
                   .IsUnicode(false);

               modelBuilder.Entity<GiaoVien>()
                   .Property(e => e.SDT)
                   .IsUnicode(false);

               modelBuilder.Entity<GiaoVien>()
                   .Property(e => e.Email)
                   .IsUnicode(false);

               modelBuilder.Entity<GiaoVien>()
                   .HasMany(e => e.BanDangKy)
                   .WithRequired(e => e.GiaoVien)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<LoaiTTB>()
                   .Property(e => e.MaLTTB)
                   .IsUnicode(false);

               modelBuilder.Entity<LoaiTTB>()
                   .HasMany(e => e.ChiTietTTBCanDung)
                   .WithRequired(e => e.LoaiTTB)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<NhanVien>()
                   .Property(e => e.MaNV)
                   .IsUnicode(false);

               modelBuilder.Entity<NhanVien>()
                   .Property(e => e.MaTK)
                   .IsUnicode(false);

               modelBuilder.Entity<NhanVien>()
                   .Property(e => e.SDT)
                   .IsUnicode(false);

               modelBuilder.Entity<NhanVien>()
                   .Property(e => e.Email)
                   .IsUnicode(false);

               modelBuilder.Entity<NhanVien>()
                   .HasMany(e => e.ChiTietDangKi)
                   .WithRequired(e => e.NhanVien)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<NhaSanXuat>()
                   .Property(e => e.MaNSX)
                   .IsUnicode(false);

               modelBuilder.Entity<PhongThiNghiem>()
                   .Property(e => e.MaPhong)
                   .IsUnicode(false);

               modelBuilder.Entity<PhongThiNghiem>()
                   .HasMany(e => e.ChiTietDangKi)
                   .WithRequired(e => e.PhongThiNghiem)
                   .HasForeignKey(e => e.MaPTN)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<TaiKhoanGV>()
                   .Property(e => e.MaTK)
                   .IsUnicode(false);

               modelBuilder.Entity<TaiKhoanGV>()
                   .Property(e => e.MatKhau)
                   .IsUnicode(false);

               modelBuilder.Entity<TaiKhoanNV>()
                   .Property(e => e.MaTK)
                   .IsUnicode(false);

               modelBuilder.Entity<TaiKhoanNV>()
                   .Property(e => e.MatKhau)
                   .IsUnicode(false);

               modelBuilder.Entity<TrangThietBi>()
                   .Property(e => e.MaTTB)
                   .IsUnicode(false);

               modelBuilder.Entity<TrangThietBi>()
                   .Property(e => e.MaLTTB)
                   .IsUnicode(false);

               modelBuilder.Entity<TrangThietBi>()
                   .Property(e => e.MaNSX)
                   .IsUnicode(false);

               modelBuilder.Entity<TrangThietBi>()
                   .Property(e => e.MaPhong)
                   .IsUnicode(false);

               modelBuilder.Entity<TrangThietBi>()
                   .HasMany(e => e.ChiTietSuDung)
                   .WithRequired(e => e.TrangThietBi)
                   .WillCascadeOnDelete(false);
          }
     }
}

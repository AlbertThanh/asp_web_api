using Microsoft.EntityFrameworkCore;
using System.Text;

namespace My_web_API.Data
{
    public class MyDbContext :DbContext
    {
        public MyDbContext (DbContextOptions options) : base(options)
        {

        }

        #region Dbset
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });


            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaHh, e.MaDh });

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.donHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FR_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.donHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FR_DonHangCT_HangHoa");


            });
        }
    }
}

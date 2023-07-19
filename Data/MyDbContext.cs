using Microsoft.EntityFrameworkCore;

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
        #endregion
    }
}

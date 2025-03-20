using Microsoft.EntityFrameworkCore;

namespace GoodsAPI.Models
{
    public class GoodsDbContext : DbContext
    {
        public GoodsDbContext(DbContextOptions<GoodsDbContext> options) : base(options) { }

        public DbSet<HangHoa> Goods { get; set; }
    }
}
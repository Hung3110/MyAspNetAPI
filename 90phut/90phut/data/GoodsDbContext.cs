using _90phut.Models;
using Microsoft.EntityFrameworkCore;

namespace _90phut.data
{
    public class GoodsDbContext : DbContext
    {
        public GoodsDbContext(DbContextOptions<GoodsDbContext> options) : base(options) { }

        public DbSet<HangHoa> Goods { get; set; }
    }
}

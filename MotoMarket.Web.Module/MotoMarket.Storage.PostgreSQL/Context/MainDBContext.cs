using Microsoft.EntityFrameworkCore;
using MotoMarket.Storage.PostgreSQL.Entities;

namespace MotoMarket.Storage.PostgreSQL.Context
{
    public class MainDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MainDBContext(DbContextOptions<MainDBContext> options)
            : base(options)
        {
        }
    }
}

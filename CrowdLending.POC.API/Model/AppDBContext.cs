using Microsoft.EntityFrameworkCore;

namespace CrowdLending.POC.API.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<UserInvestment> UserInvestments { get; set; }
    }
}

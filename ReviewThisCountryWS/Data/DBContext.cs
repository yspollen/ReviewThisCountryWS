using ReviewThisCountryWS.Models;
using Microsoft.EntityFrameworkCore;
namespace ReviewThisCountryWS.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
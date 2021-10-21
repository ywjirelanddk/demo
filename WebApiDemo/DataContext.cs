using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiDemo.Models;

namespace WebApiDemo
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("dbConn"));
        }

        public DbSet<User> Users { get; set; }
    }
}

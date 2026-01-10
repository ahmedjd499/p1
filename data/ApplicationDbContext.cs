using Microsoft.EntityFrameworkCore;
using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
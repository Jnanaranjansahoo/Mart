using MartWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MartWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData
              (
                new Category { Id = 1001 , Name ="Action"},
                new Category { Id = 1002 , Name ="Sifi"},
                new Category { Id = 1003 , Name ="Theril"}
              );
            modelBuilder.Entity<Company>().HasData
              (
                new Company { Id = 1111, Name = " Nothing"},
                new Company { Id = 1112, Name = " Everything"},
                new Company { Id = 1113, Name = " Anything"}
              );
        }
    }
}

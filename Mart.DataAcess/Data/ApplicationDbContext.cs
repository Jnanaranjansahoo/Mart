using Mart.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Mart.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
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
            modelBuilder.Entity<Product>().HasData
              (
                new Product
                {
                    Id = 10001,
                    Name = " qwer",
                    Description = " Nothing",
                    Price = 300,
                    ImageUrl = "e"
                },
                new Product
                {
                    Id = 10002,
                    Name = " asdfr",
                    Description = " Nothing",
                    Price = 300,
                    ImageUrl = "r"
                },
                new Product
                {
                    Id = 10003,
                    Name = " €zxc",
                    Description = " Nothing",
                    Price = 300,
                    ImageUrl = "d"
                }

              );
        }
    }
}

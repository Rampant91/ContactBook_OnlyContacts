using Microsoft.EntityFrameworkCore;
using MyContactBookWithOrders.Models;

namespace MyContactBookWithOrders.DbRealization
{
    public class DataContext : DbContext
    {
        private readonly string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=myContactsWithOrdersDb;Trusted_Connection=True;";
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Contact>().HasMany<Order>().WithOne(x => x.);
        //}
        //СДЕЛАЙ ЖЕСТКУЮ ПРИВЯЗКУ!
    }
}

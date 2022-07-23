using Microsoft.EntityFrameworkCore;
using MyContactBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactBook.DbRealization
{
    public class DataContext : DbContext
    {
        private readonly string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=mycontactsdb;Trusted_Connection=True;";

        public DbSet<Contact> Contacts { get; set; } = null!;
        
        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
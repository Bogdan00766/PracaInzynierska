using Microsoft.EntityFrameworkCore;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Infrastructure
{
    public class PIDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<FinancialChange> FinancialChange { get; set; }
        public DbSet<Transfer> Transfer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=PracaInz.db");

        }
    }
}

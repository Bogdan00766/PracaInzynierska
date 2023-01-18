
using Microsoft.EntityFrameworkCore;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracaInzynierska.Infrastructure
{
    public class PIDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<FinancialChange> FinancialChange { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("connectionString");
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.EMail)
                .IsUnique();
        }
    }
}


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
        public DbSet<Transfer> Transfer { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<PIDbContext>(modelBuilder);
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}

        //MSSQLBogdan!
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlite("Data Source=C:\\Repozytoria\\PracaInzynierska\\PracaInżynierska.Api\\PracaInz.db");

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=51.137.50.51;Database=PracaInz;User Id=sa;Password=MSSQLBogdan!; Trusted_Connection=False; TrustServerCertificate=True");
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.EMail)
                .IsUnique();
        }
    }
}

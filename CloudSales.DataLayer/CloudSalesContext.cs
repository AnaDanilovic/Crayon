using CloudSales.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace CloudSales.DataLayer
{
    public class CloudSalesContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public DbSet<AccountDto> Accounts { get; set; }
        public DbSet<PurchasedSoftwareDto> PurchasedSoftwares { get; set; }
        public DbSet<LogDto> Logs { get; set; }

        public CloudSalesContext(DbContextOptions<CloudSalesContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>().ToTable("User");
            modelBuilder.Entity<AccountDto>().ToTable("Account");
            modelBuilder.Entity<PurchasedSoftwareDto>().ToTable("PurchasedSoftware");
            modelBuilder.Entity<LogDto>().ToTable("Log");
        }
    }
}
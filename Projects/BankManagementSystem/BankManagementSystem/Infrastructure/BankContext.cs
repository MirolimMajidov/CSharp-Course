using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Infrastructure
{
    public class BankContext : DbContext
    {
        //public BankContext( )
        //{ }

        public BankContext(DbContextOptions options) : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("");
        //    }
        //}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();

            var bank = new Bank();
            bank.Name = "Eskhata";
            bank.Address = "Guliston";

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasMany(p => p.Departments)
                .WithOne(s => s.Bank)
                .HasForeignKey(s => s.BankId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(bank);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            //modelBuilder.Entity<Transaction>(entity =>
            //{
            //    entity.HasKey(p => p.Id);
            //});

            var branch1 = new Branch();
            branch1.Address = "Station";
            branch1.BankId = bank.Id;

            var branch2 = new Branch();
            branch2.Address = "Guliston, Glavnoy";
            branch2.BankId = bank.Id;

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasData(branch1, branch2);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.FullName2).HasComputedColumnSql("CONCAT(FirstName, ' ', LastName)");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(20).HasDefaultValue("Nabijon");

                entity.HasData(new Client()
                {
                    FirstName = "Nabijon",
                    LastName = "Azamov",
                    BranchId = branch1.Id,
                });

                entity.HasData(new Client()
                {
                    FirstName = "Rahmatillo",
                    LastName = "Azamov",
                    BranchId = branch2.Id,
                });
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasData(new Worker()
                {
                    FirstName = "Yoqubjon",
                    LastName = "Ahmedov",
                    BranchId = branch1.Id,
                });

                entity.HasData(new Worker()
                {
                    FirstName = "Abdurasul",
                    LastName = "Abdurahmonov",
                    BranchId = branch2.Id,
                });
            });

        }
    }
}

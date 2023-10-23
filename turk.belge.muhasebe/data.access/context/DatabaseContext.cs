using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using entity.concretes.identity;
using entity.concretes.entities;
using System.Reflection.Emit;

namespace data.access.context
{
    public class DatabaseContext : IdentityDbContext<UserTable, RoleTable, int, UserClaim, UserHasRole, UserLogin, RoleClaim, UserToken>
    {
        public override DbSet<UserTable> Users { get; set; }
        public override DbSet<RoleTable> Roles { get; set; }
        public override DbSet<UserHasRole> UserRoles { get; set; }
        public DbSet<FirmUsers> FirmHasUsers { get; set; }
        public override DbSet<UserToken> UserTokens { get => base.UserTokens; set => base.UserTokens = value; }


        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CariGroup> CariGroups { get; set; }
        public DbSet<Firm> Firms { get; set; }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<FirmHasModule> FirmModules { get; set; }


        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<InvoiceSubType> InvoiceSubTypes { get; set; }
        public DbSet<InvoiceHasStock> InvoiceStocks { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockCategory> StockCategories { get; set; }
        public DbSet<TaxOffice> TaxOfficies { get; set; }
        public DbSet<UnitsOfMeasurement> UnitsOfMeasurements { get; set; }
        public DbSet<Vault> Vaults { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }


        public DatabaseContext()
        {
            if (Database.EnsureCreated()) { SeedDatabase.db = this; SeedDatabase.Seed(); }
        }



        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // ERROR : "AspNetRoles" already exists"
            /**I was calling EnsureCreated in Startup.cs which was getting conflict with migrations as working different way. 
             * Thankfully EF Core owners made it clear for me on GitHub.
             * So to summarize - if you want to use Migrations, you can't use EnsureCreated.*/
            if (Database.EnsureCreated()) { SeedDatabase.db = this; SeedDatabase.Seed(); }

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Build();


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = "database" +
                ".db",
                ForeignKeys = true

            }.ConnectionString;

            optionsBuilder.UseSqlite(connectionString, o => o.MigrationsAssembly("data.access"));
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        }

    }


}

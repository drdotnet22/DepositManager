using Microsoft.EntityFrameworkCore;

namespace DepositManager.Data
{
    public class MyDbContext : DbContext
    {
        #region Constructor
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
        #endregion

        #region Public Properties
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Check> Check { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }
        #endregion

        #region
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Check>().HasData(GetChecks());
            //modelBuilder.Entity<Deposit>().HasData(GetDeposits());
            modelBuilder.Entity<Bank>().HasData(GetBanks());
            modelBuilder.Entity<EmailSettings>().HasData(GetEmailSettings());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region GetData
        private List<Check> GetChecks()
        {
            return new List<Check>
            {
                new Check { CheckId = Guid.NewGuid(), CustomerName = "Free To Choose", ReferenceNum = 1562, Amount = 15.25m },
                new Check { CheckId = Guid.NewGuid(), CustomerName = "Humes", ReferenceNum = 125, Amount = 2560.3m }
            };
        }

        private List<EmailSettings> GetEmailSettings()
        {
            return new List<EmailSettings>
            {
                new EmailSettings { EmailSettingsId = Guid.NewGuid(), Username = "user@example.com", Password = "password", Hostname = "mail.example.com", Port = 587, Recipient = "guy@example.com"}
            };
        }

        private List<Bank> GetBanks()
        {
            return new List<Bank>
            {
                new Bank { BankId = Guid.NewGuid(), BankName = "FNB" },
                new Bank { BankId = Guid.NewGuid(), BankName = "ERIE" },
                new Bank { BankId = Guid.NewGuid(), BankName = "Unassigned" }
            };
        }
        #endregion
    }
}

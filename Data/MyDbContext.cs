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
        #endregion

        #region
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Check>().HasData(GetChecks());
            //modelBuilder.Entity<Deposit>().HasData(GetDeposits());
            modelBuilder.Entity<Bank>().HasData(GetBanks());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region
        private List<Check> GetChecks()
        {
            return new List<Check>
            {
                new Check { CheckId = Guid.NewGuid(), CustomerName = "Free To Choose", ReferenceNum = 1562, Amount = 15.25m },
                new Check { CheckId = Guid.NewGuid(), CustomerName = "Humes", ReferenceNum = 125, Amount = 2560.3m }
            };
        }

        //private List<Deposit> GetDeposits()
        //{
        //    return new List<Deposit>
        //    {
        //        new Deposit { DepositId = Guid.NewGuid(), Date = DateOnly.FromDateTime(DateTime.Now), BankName = "FNB" },
        //        new Deposit { DepositId = Guid.NewGuid(), Date = DateOnly.FromDateTime(DateTime.Now), BankName = "ERIE" }
        //    };
        //}

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

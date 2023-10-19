using Microsoft.EntityFrameworkCore;

namespace DepositManager.Data
{
    public class BankServices
    {
        #region Private members
        private MyDbContext dbContext;
        #endregion

        #region Constructor
        public BankServices(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bank>> GetBanksAsync()
        {
            return await dbContext.Banks.ToListAsync();
        }
        #endregion
    }
}

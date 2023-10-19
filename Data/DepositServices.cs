using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DepositManager.Data
{
    public class DepositServices
    {
        #region Private members
        private MyDbContext dbContext;
        #endregion

        #region Constructor
        public DepositServices(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Deposit>> GetDepositsAsync()
        {
            return await dbContext.Deposit.Include(b => b.Bank).ToListAsync();
        }

        /// <summary>
        /// This method gets a deposit by the depositID and returns it.
        /// </summary>
        /// <param name="depositId"></param>
        /// <returns></returns>
        public async Task<Deposit> GetDepositByIdAsync(string depositId)
        {
            Deposit deposit;
            try
            {
                IList<Deposit> depositList = await dbContext.Deposit.Include(b => b.Bank).ToListAsync();
                deposit = depositList.FirstOrDefault(d => d.DepositId.ToString() == depositId);
            }
            catch (Exception)
            {
                throw;
            }
            return deposit;
        }

        ///<param name="deposit"></param>
        ///<returns></returns>
        public async Task<decimal> GetDepositTotalAsync(Deposit deposit)
        {
            decimal total = 0m;
            if (deposit.Cash != null)
            {
                total = deposit.Cash.Value;
            }
            IList<Check> checksInDeposit = dbContext.Check.Where(c => c.Deposit == deposit).ToList();
            foreach (var check in checksInDeposit)
            {
                total = total + check.Amount;
            }
            return total;
        }


        /// <summary>
        /// This method add a new product to the DbContext and saves it
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        public async Task<Deposit> AddDepositAsync(Deposit deposit)
        {
            try
            {
                dbContext.Deposit.Add(deposit);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return deposit;
        }

        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        public async Task<Deposit> UpdateDepositAsync(Deposit deposit)
        {
            try
            {
                var depositExist = dbContext.Deposit.FirstOrDefault(p => p.DepositId == deposit.DepositId);
                if (depositExist != null)
                {
                    dbContext.Update(deposit);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return deposit;
        }

        /// <summary>
        /// This method removes and existing product from the DbContext and saves it
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>
        public async Task DeleteDepositAsync(Deposit deposit)
        {
            try
            {
                IList<Check> checksInDeposit = await dbContext.Check.Where(d => d.Deposit == deposit).ToListAsync();
                foreach (Check check in checksInDeposit)
                {
                    check.Deposit = null;
                    dbContext.Check.Update(check);
                    dbContext.SaveChanges();
                }
                dbContext.Deposit.Remove(deposit);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}

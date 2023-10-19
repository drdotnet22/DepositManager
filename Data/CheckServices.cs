using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DepositManager.Data
{
    public class CheckServices
    {
        #region Private members
        private MyDbContext dbContext;
        #endregion

        #region Constructor
        public CheckServices(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method returns the list of product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Check>> GetChecksAsync()
        {
            return await dbContext.Check.ToListAsync();
        }

        /// <summary>
        /// This method returns checks attached to a deposit
        /// </summary>
        /// <param name="deposit"></param>
        /// <returns></returns>

        public async Task<IEnumerable<Check>> GetChecksInDepositAsync(Deposit deposit)
        {
            IEnumerable<Check> checksInDeposit;
            try
            {
                IEnumerable<Check> checks = await dbContext.Check.ToListAsync();
                checksInDeposit = checks.Where(check => check.Deposit == deposit);
            }
            catch (Exception)
            {
                throw;
            }
            return checksInDeposit;
        }

        /// <summary>
        /// This method add a new product to the DbContext and saves it
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public async Task<Check> AddCheckAsync(Check check)
        {
            try
            {
                dbContext.Check.Add(check);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return check;
        }

        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public async Task<Check> UpdateCheckAsync(Check check)
        {
            try
            {
                var checkExists = dbContext.Check.FirstOrDefault(c => c.CheckId == check.CheckId);
                if (checkExists != null)
                {
                    dbContext.Update(check);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return check;
        }

        public void UpdateCheck(Check check)
        {
            try
            {
                var local = dbContext.Set<Check>().Local.FirstOrDefault(p => p.CheckId == check.CheckId);
                if (local != null)
                {
                    dbContext.Entry(local).State = EntityState.Detached;
                }
                dbContext.Entry(check).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// This method removes and existing product from the DbContext and saves it
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public async Task DeleteCheckAsync(Check check)
        {
            try
            {
                dbContext.Check.Remove(check);
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

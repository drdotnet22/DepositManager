using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Collections.Generic;

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
                await CalculateDepositTotalAsync(deposit);
            }
            catch (Exception)
            {
                throw;
            }
            return deposit;
        }

        public async Task CalculateDepositTotalAsync(Deposit deposit)
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
            deposit.DepositTotal = total;
            dbContext.Deposit.Update(deposit);
            dbContext.SaveChangesAsync();
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
                    await CalculateDepositTotalAsync(deposit);
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

        /// <param name="deposit"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> CreateDepositTicketAsync(Deposit deposit)
        {
            Dictionary<string, string> depositTicketDictionary = new Dictionary<string, string>();
            IList<Check> checksInDeposit = await dbContext.Check.Where(d => d.Deposit == deposit).ToListAsync();
            //date
            depositTicketDictionary.Add("date1", deposit.Date.ToString());
            depositTicketDictionary.Add("date2", deposit.Date.ToString());
            //cash info
            if (deposit.Cash != null)
            {
                depositTicketDictionary.Add("cash1", deposit.Cash?.ToString("N2"));
                depositTicketDictionary.Add("cash2", deposit.Cash?.ToString("N2"));
            }
            //check info
            int ckCount = 0;
            foreach (Check check in checksInDeposit)
            {
                ckCount++;
                //id of check
                depositTicketDictionary.Add("id1ck" + ckCount.ToString(), ckCount.ToString());
                depositTicketDictionary.Add("id2ck" + ckCount.ToString(), ckCount.ToString());
                //check amount
                depositTicketDictionary.Add("amt1ck" + ckCount.ToString(), check.Amount.ToString("N2"));
                depositTicketDictionary.Add("amt2ck" + ckCount.ToString(), check.Amount.ToString("N2"));
                //customer name
                depositTicketDictionary.Add("custname" + ckCount.ToString(), check.CustomerName);
                //reference number
                depositTicketDictionary.Add("refnum" + ckCount.ToString(), check.ReferenceNum.ToString());
            }
            depositTicketDictionary.Add("ckNum1", checksInDeposit.Count.ToString());
            //deposit total
            depositTicketDictionary.Add("Total1", deposit.DepositTotal?.ToString("N2"));
            depositTicketDictionary.Add("total2", deposit.DepositTotal?.ToString("N2"));

            depositTicketDictionary.Add("bankName", deposit.Bank.BankName);

            return depositTicketDictionary;
        }
        #endregion
    }
}

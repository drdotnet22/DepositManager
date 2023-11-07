using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace DepositManager.Data
{
    public class EmailServices
    {
        #region Private members
        private MyDbContext dbContext;
        private CheckServices checkServices;
        #endregion

        #region Constructor
        public EmailServices(MyDbContext dbContext, CheckServices checkServices)
        {
            this.dbContext = dbContext;
            this.checkServices = checkServices;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// This method update and existing product and saves the changes
        /// </summary>
        /// <param name="emailSettings"></param>
        /// <returns></returns>
        public async Task<EmailSettings> UpdateEmailSettingsAsync(EmailSettings emailSettings)
        {
            try
            {
                var emailSettingsExist = dbContext.EmailSettings.FirstOrDefault(p => p.EmailSettingsId == emailSettings.EmailSettingsId);
                if (emailSettingsExist != null)
                {
                    dbContext.Update(emailSettings);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return emailSettings;
        }

        public async Task<string> SendEmailAsync()
        {
            decimal totalChecks = await checkServices.GetTotalOfChecksInDeposit(null);
            
            EmailSettings emailSettings = await dbContext.EmailSettings.FirstOrDefaultAsync();
            SmtpClient smtpClient = new SmtpClient(emailSettings.Hostname, emailSettings.Port)
            {
                Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password),
                EnableSsl = true
            };
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailSettings.Username);
            mailMessage.To.Add(emailSettings.Recipient);
            mailMessage.Subject = ($"{totalChecks:C} to deposit.");
            await smtpClient.SendMailAsync(mailMessage);
            return emailSettings.Recipient;
        }
        #endregion
    }
}

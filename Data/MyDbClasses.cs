namespace DepositManager.Data
{
    public class Deposit
    {
        public Guid DepositId { get; set; }
        public DateOnly Date { get; set; }
        public Bank Bank { get; set; }
        public Guid BankId { get; set; }
        public bool DepositStatus { get; set; }
        public decimal? Cash { get; set; }
        public decimal? DepositTotal { get; set; }
    }

    public class Check
    {
        public Guid CheckId { get; set; }
        public double ReferenceNum { get; set; }

        public string? CustomerName { get; set; }
        public decimal Amount { get; set; }
        public Deposit? Deposit { get; set; }
        public Guid? DepositId { get; set; }
    }

    public class Bank
    {
        public Guid BankId { get; set; }
        public string BankName { get; set; }
    }

    public class EmailSettings
    {
        public Guid EmailSettingsId { get; set;}
        public string Username { get; set;}
        public string Password { get; set;}
        public string Hostname { get; set;}
        public int Port { get; set; }
        public string Recipient { get; set; }
    }
}

namespace Service
{
    public class AccountServiceImpl : AccountService
    {
        IDictionary<int, Account> accounts = new Dictionary<int, Account>();
        public void AddNewAccount(int id, string curency, double balance)
        {
            accounts.Add(id, new Account(id, curency, balance));
        }
        public List<Account> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }
        public Account GetAccountById(int id)
        {
            return accounts[id];
        }
        public List<Account> GetDebitedAccounts()
        {
            List<Account> DebitedAccounts = new List<Account>();

            foreach (Account acc in accounts.Values)
            {
                if (acc.Balance < 0)
                {
                    DebitedAccounts.Add(acc);
                }
            }
            return DebitedAccounts;
        }
        public double GetBalanceAVG()
        {
            double avg = 0;
            List<Account> listAccounts = accounts.Values.ToList();
            foreach (Account acc in listAccounts)
            {
                avg = avg + acc.Balance;
            }
            return avg / listAccounts.Count;
        }
    }
}
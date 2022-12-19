namespace Service
{
    public interface AccountService
    {
        public void AddNewAccount(int id, string curency, double balance);
        public List<Account> GetAllAccounts();
        public Account GetAccountById(int id);
        public List<Account> GetDebitedAccounts();
        public double GetBalanceAVG();



    }
}
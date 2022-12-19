﻿# Activit-Pratique-Dot-Net

## Partie 1 - Console Application :

 <strong style="color:dark">Créer une application DotNet Core de type console qui permet gérer des comptes (id, curency, balance) :
 
        1. Créer l'interface AccountService avec les opérations.
        
        2. Créer une implémentation de cette interface utilisant une collection de type Dictionary.
        
        3. Tester l'application.
        
</span>

### Les Classes:

#### Account : 

```C#
namespace Service
{
    public class Account
    {
        public int Id { get; set; }
        public string Curency { get; set; }
        public double Balance { get; set; }

        public Account()
        {

        }
        public Account(int id, string curency, double balance)
        {
            this.Balance = balance;
            this.Id = id;
            this.Curency = curency;

        }
        public override string ToString()
        {
            return base.ToString() + ": " + Id.ToString() + ": " + Curency.ToString() + ": " + Balance.ToString();
        }

    }
}

```

#### AcountService interface : 

```C#
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

```

#### AccountServiceImpl : 

```C#

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

```

### Test:

![image](https://user-images.githubusercontent.com/84138772/208531187-6082b996-efe7-4bd1-8094-9fda7d5375eb.png)


using Service;
Console.WriteLine("Hello, World!");
AccountService accS = new AccountServiceImpl();
accS.AddNewAccount(1, "MAD", 20000);
accS.AddNewAccount(2, "CAD", 2500);
accS.AddNewAccount(3, "USD", -6000);
accS.AddNewAccount(4, "MAD", -2000);

List<Account> listAccounts = accS.GetAllAccounts();
foreach (Account acc in listAccounts)
{
    Console.WriteLine(acc);
}
Console.WriteLine("*************************************************");
List<Account> DebitedAccounts = accS.GetDebitedAccounts();
foreach (Account acc in DebitedAccounts)
{
    Console.WriteLine(acc);
}
Console.WriteLine("*************************************************");
Console.WriteLine(accS.GetBalanceAVG());
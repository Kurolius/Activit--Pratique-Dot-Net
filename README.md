# Activit-Pratique-Dot-Net

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


## Partie 2 - Web API :

### Les Entitées :

#### Product :

```C#
using System.ComponentModel.DataAnnotations;
public class Product
{
    [Key]
    [Display(Name = "Product ID")]
    public int ProductId { get; set; }
    [Required, MinLength(6), MaxLength(25)]
    [StringLength(70)]
    public string? Designation { get; set; }
    [Required, Range(100, 1000000)]
    public double Price { get; set; }
    public int CategoryID { get; set; }

}

```

#### Category :

```C#
using System.ComponentModel.DataAnnotations;
public class Category
{
    [Key]
    [Required]
    public int CategoryID { get; set; }
    [Required]
    [StringLength(35)]
    public string? CategoryName { get; set; }
    public virtual ICollection<Product>? Products { get; set; }

    public Category(int Id, string Name)
    {
        this.CategoryID = Id;
        this.CategoryName = Name;
    }
}

```

### Les services :

#### ProductService :

```C#
public interface ProductService
{
    Product Save(Product p);
    IEnumerable<Product> FindAll();
    IEnumerable<Product> FindByDesignation(string mc);
    Product GetOne(int ID);
    void Update(Product p);
    void Delete(int ID);
    Category GetCategorie(Product p);
}

```

### Controller :

```C#
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class APIController : ControllerBase
{
    Dictionary<int, Category> categories = new Dictionary<int, Category>(){
        {1, new Category(1, "Pcs")},
        {2, new Category(2, "Phones")},
    };
    private readonly ILogger<APIController> _logger;
    public APIController(ILogger<APIController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            ProductId = (index),
            Designation = "Product " + index,
            Price = Random.Shared.NextInt64(index * 100),
            CategoryID = categories[index < 3 ? 1 : 2].CategoryID
        })
        .ToArray();
    }
}

```

### Test : 


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
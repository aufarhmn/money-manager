namespace MoneyManagerAPI.Model
{
    public class MoneyManager
    {
        public int custId { get; set; }
        public string userName { get; set; }
        public double userBalance { get; set; }
        public double userExpense { get; set; }

        public MoneyManager()
        {

        }

        public MoneyManager(int custId, string userName, double userBalance, double userExpense)
        {
            this.custId = custId;
            this.userName = userName;
            this.userBalance = userBalance;
            this.userExpense = userExpense;
        }
    }
}

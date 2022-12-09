using MoneyManagerAPI.Model;

namespace MoneyManagerAPI.Services
{
    public class MoneyManagerSevices
    {
        public List<MoneyManager> moneyManagerClient = new List<MoneyManager>
        {
            //TODO: Call Method GET dari DB
            new MoneyManager(1, "Yogss", 200000, 150000),
            new MoneyManager(2, "Zuxx", 500000, 3000000)
        };
        public List<MoneyManager> GetAllClient()
        {
            return moneyManagerClient;
        }
    }
}

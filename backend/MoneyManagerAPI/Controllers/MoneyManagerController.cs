using Microsoft.AspNetCore.Mvc;
using MoneyManagerAPI.Services;
using MoneyManagerAPI.Model;

namespace MoneyManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyManagerController : Controller
    {
        private readonly MoneyManagerSevices moneyManagerClient;

        public MoneyManagerController()
        {
            this.moneyManagerClient = new MoneyManagerSevices();
        }

        [HttpGet]
        public List<MoneyManager> Get()
        {
            return moneyManagerClient.GetAllClient();
        }
    }
}

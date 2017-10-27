using Microsoft.AspNetCore.Mvc;
using CryptoPortfolio.Core.Interfaces;
using CryptoPortfolio.Mvc.ViewModels;

namespace CryptoPortfolio.Mvc.Controllers
{
    public class TradesController : Controller
    {
        private readonly IUserTradesService _userTradesService;

        public TradesController(IUserTradesService userTradesService)
        {
            _userTradesService = userTradesService;
        }

        // GET: Trades
        public ActionResult Index()
        {
            return View(new IndexVM { Trades = _userTradesService.FindAll() });
        }

        // GET: Trades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
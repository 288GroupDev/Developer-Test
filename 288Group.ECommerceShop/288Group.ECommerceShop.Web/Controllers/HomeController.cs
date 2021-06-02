using _288Group.ECommerceShop.Persistance;
using _288Group.ECommerceShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _288Group.ECommerceShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersistanceService _service;

        public HomeController(IPersistanceService service)
            => _service = service;

        public IActionResult Index(long? userId = null)
        {
            bool userLoggedIn = false;
            string username = "Guest";
            if (userId != null)
            {
                userLoggedIn = true;
                username = _service.GetUsername(userId.Value);
            }
            return View(new IndexViewModel(userLoggedIn, userId ?? 0, username, _service.GetAllProducts()));
        }
    }
}

using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace Online2.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUserBLL _userBLL;
        public HomeController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        public IActionResult Index(int id)
        {
            return View();
        }
    }
}

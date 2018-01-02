namespace RestaurantSystem.Web.Areas.Cook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
    }
}
namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.ManagerArea)]
    [Authorize(Roles = WebConstants.ManagerRole)]
    public class ManagerBaseController : Controller
    {     
    }
}

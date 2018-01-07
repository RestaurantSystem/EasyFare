namespace RestaurantSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.User.Contracts;
    using RestaurantSystem.Web.Areas.Cook;
    using RestaurantSystem.Services.User.Models;
    using static WebConstants;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> AllTables(string direction, int page = 1, string search = "")
        {
            if (direction == PageForward)
            {
                page++;
            }

            if (direction == PageBackward && page > 1)
            {
                page--;
            }

            TablesPaginationAndSearchModel tables = await this.userService.GetTables(search, page);

            tables.TotalPages = (int)Math.Ceiling(((double)tables.ItemsCount / CookConstants.IngredientsPerPage));

            tables.TotalPages = tables.TotalPages == 0 ? 1 : tables.TotalPages;

            if (tables.TotalPages < tables.Page)
            {
                tables.Page = tables.TotalPages;
            }

            tables.Tables = tables.Tables
                .Skip(CookConstants.IngredientsPerPage * (tables.Page - 1))
                .Take(CookConstants.IngredientsPerPage)
                .ToList();

            return this.View(tables);
        }
    }
}

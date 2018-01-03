namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;
    using RestaurantSystem.Web.Areas.Cook;
    using static WebConstants;
    using RestaurantSystem.Web.Infrastructure.Extensions;
    using RestaurantSystem.Web.Areas.Manager.Models.Sections;

    public class SectionsController : ManagerBaseController
    {
        private readonly IManagerSectionsService sections;

        public SectionsController(IManagerSectionsService sections)
        {
            this.sections = sections;
        }

        public async Task<IActionResult> All(string direction, int page = 1, string search = "")
        {
            if (direction == PageForward)
            {
                page++;
            }

            if (direction == PageBackward && page > 1)
            {
                page--;
            }

            SectionsPaginationAndSearchModel sections = await this.sections.GetSections(search, page);

            sections.TotalPages = (int)Math.Ceiling(((double)sections.ItemsCount / CookConstants.IngredientsPerPage));

            sections.TotalPages = sections.TotalPages == 0 ? 1 : sections.TotalPages;

            if (sections.TotalPages < sections.Page)
            {
                sections.Page = sections.TotalPages;
            }

            sections.Sections = sections.Sections
                .Skip(CookConstants.IngredientsPerPage * (sections.Page - 1))
                .Take(CookConstants.IngredientsPerPage)
                .ToList();

            return this.View(sections);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSectionModel sectionModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(sectionModel);
            }

            bool found = await this.sections.AddNewSectionAsync(sectionModel.Name, sectionModel.IsForSmokers);

            if (!found)
            {
                TempData.AddErrorMessage($"The section {sectionModel.Name} already exists.");
                return this.View(sectionModel);
            }

            TempData.AddSuccessMessage($"The section {sectionModel.Name} added successfully.");
            return this.RedirectToAction(nameof(All));
        }
    }
}

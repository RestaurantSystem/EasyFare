namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Manager.Models.Tables;
    using RestaurantSystem.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;

    public class TablesController : ManagerBaseController
    {
        private readonly IManagerTableService tableService;

        public TablesController(IManagerTableService tableService)
        {
            this.tableService = tableService;
        }

        public IActionResult AddTable(int sectionId)
        {
            return this.View(new AddTableModel
            {
                SectionId = sectionId
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddTable(AddTableModel tableModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(tableModel);
            }

            var tableExist = await this.tableService.TableAlreadyExist(tableModel.Number);

            if (tableExist)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableAlreadyExist, tableModel.Number));
                return this.View(tableModel);
            }

            bool found = await this.tableService.AddNewTableAsync(tableModel.Number, tableModel.Seats, tableModel.SectionId);

            if (!found)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableExistInSection, tableModel.Number));
                return this.View(tableModel);
            }

            TempData.AddSuccessMessage(string.Format(ManagerConstants.TableAddedSuccessfully, tableModel.Number));
            return this.RedirectToAction(nameof(SectionsController.All), "Sections");
        }
    }
}

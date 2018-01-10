namespace RestaurantSystem.Web.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Web.Areas.Manager.Models.Tables;
    using RestaurantSystem.Web.Infrastructure.Extensions;

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
                return this.Ok(tableModel);
            }

            //var tableExist = await this.tableService.TableAlreadyExist(tableModel.Number);

            if (await DoesTheTableExist(tableModel.Number))
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableAlreadyExist, tableModel.Number));
                return this.Ok(tableModel);
            }

            bool found = await this.tableService.AddNewTableAsync(tableModel.Number, tableModel.Seats, tableModel.SectionId);

            if (!found)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableExistInSection, tableModel.Number));
                return this.Ok(tableModel);
            }

            TempData.AddSuccessMessage(string.Format(ManagerConstants.TableAddedSuccessfully, tableModel.Number));
            return this.RedirectToAction(nameof(SectionsController.All), "Sections");
        }

        public IActionResult RemoveTable(string tableName)
        {
            return this.View(new RemoveTableModel
            {
                Number = tableName
            });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTable(RemoveTableModel tableModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Ok(tableModel);
            }

            if (!await DoesTheTableExist(tableModel.Number))
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableDoesntExist, tableModel.Number));
                return this.Ok(tableModel);
            }

            bool found = await this.tableService.RemoveTableAsync(tableModel.Number, tableModel.SectionId);

            if (!found)
            {
                TempData.AddErrorMessage(string.Format(ManagerConstants.TableDoesntExist, tableModel.Number));
                return this.Ok(tableModel);
            }

            TempData.AddSuccessMessage(string.Format(ManagerConstants.TableRemovedSuccessfully, tableModel.Number));
            return this.RedirectToAction(nameof(SectionsController.All), "Sections");
        }

        private async Task<bool> DoesTheTableExist(string tableNumber)
        {
            var tableExist = await this.tableService.TableAlreadyExist(tableNumber);

            if (tableExist)
            {
                return true;
            }

            return false;
        }
    }
}
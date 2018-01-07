namespace RestaurantSystem.Services.User.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RestaurantSystem.Services.User.Models;

    public interface IUserService
    {
        Task<TablesPaginationAndSearchModel> GetTables(string search, int page);

        Task<TableServiceModel> GetTableAsync(string number);

        Task<bool> ReserveTableAsync(string id, DateTime date);
    }
}

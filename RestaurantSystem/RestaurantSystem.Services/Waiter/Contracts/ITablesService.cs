﻿namespace RestaurantSystem.Services.Waiter.Contracts
{
    using RestaurantSystem.Services.Waiter.Models.Tables;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITablesService
    {
        Task<IEnumerable<TablesListingServiceModel>> AllAsync();

        Task<TableOpenedServiceModel> OpenTable(string number, string waiterId, string searchWord);
    }
}
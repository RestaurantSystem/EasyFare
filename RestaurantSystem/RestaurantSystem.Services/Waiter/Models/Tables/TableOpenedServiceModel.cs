namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using System.Collections.Generic;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Models.Products;
    using RestaurantSystem.Common.Mapping;
    using AutoMapper;

    public class TableOpenedServiceModel : IMapFrom<ProductOrder>, IHaveCustomMapping
    {
        public string Number { get; set; }

        public string SearchWord { get; set; }

        public IEnumerable<ProductListModel> Products { get; set; }

        public IEnumerable<Product> ProductsOnTable { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            //throw new System.NotImplementedException();
        }
    }
}
﻿namespace RestaurantSystem.Services.Cook.Models.Orders
{
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Infrastructure.Enumerations;
    using RestaurantSystem.Data.Models;
    using System;
    using AutoMapper;

    public class ProductOrderListModel : IMapFrom<ProductOrder>, IHaveCustomMapping
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public DateTime OrderTime { get; set; }

        public string ProductName { get; set; }

        public ProductType ProductType { get; set; }

        public string WaiterName { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<ProductOrder, ProductOrderListModel>()
                .ForMember(m => m.OrderTime, cfg => cfg.MapFrom(p => p.Order.OrderTime))
                .ForMember(m => m.ProductName, cfg => cfg.MapFrom(p => p.Product.Name))
                .ForMember(m => m.ProductType, cfg => cfg.MapFrom(p => p.Product.Type))
                .ForMember(m => m.WaiterName, cfg => cfg.MapFrom(o => o.Order.Waiter.UserName));
        }
    }
}

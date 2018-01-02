namespace RestaurantSystem.Services.Waiter.Models.Tables
{
    using AutoMapper;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class TablesListingServiceModel : IMapFrom<Table>, IHaveCustomMapping
    {
        public string Number { get; set; }

        public int Seats { get; set; }

        public string Section { get; set; }

        public void ConfigureMapping(Profile mapper)
        => mapper.CreateMap<Table, TablesListingServiceModel>()
            .ForMember(t => t.Section, cfg => cfg.MapFrom(t => t.Section.Name));
    }
}
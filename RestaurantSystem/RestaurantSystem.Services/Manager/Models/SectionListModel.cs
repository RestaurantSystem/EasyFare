namespace RestaurantSystem.Services.Manager.Models
{
    using System.Collections.Generic;
    using RestaurantSystem.Common.Mapping;
    using RestaurantSystem.Data.Models;

    public class SectionListModel : IMapFrom<Section>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsForSmokers { get; set; }

        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
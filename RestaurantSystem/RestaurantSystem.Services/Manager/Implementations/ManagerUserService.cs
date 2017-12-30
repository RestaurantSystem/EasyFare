namespace RestaurantSystem.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Services.Manager.Models;

    public class ManagerUserService : IManagerUserService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerUserService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ManagerListingServiceModel>> AllAsync()
        => await this.db
            .Users
            .ProjectTo<ManagerListingServiceModel>()
            .ToListAsync();
    }
}
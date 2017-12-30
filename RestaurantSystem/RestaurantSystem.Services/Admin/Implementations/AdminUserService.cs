namespace RestaurantSystem.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Services.Admin.Contracts;
    using RestaurantSystem.Services.Admin.Models;

    public class AdminUserService : IAdminUserService
    {
        private readonly RestaurantSystemDbContext db;

        public AdminUserService(RestaurantSystemDbContext db)
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
﻿namespace RestaurantSystem.Services.Manager.Implementations
{
    using System.Threading.Tasks;
    using RestaurantSystem.Services.Manager.Contracts;
    using RestaurantSystem.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Models;

    public class ManagerTableService : IManagerTableService
    {
        private readonly RestaurantSystemDbContext db;

        public ManagerTableService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddNewTableAsync(string number, int seats, int sectionId)
        {
            if (await TableAlreadyExist(number))
            {
                return false;
            }

            var section = await this.db.Sections.FirstOrDefaultAsync(s => s.Id == sectionId);

            if (section == null)
            {
                return false;
            }

            var table = new Table()
            {
                Number = number,
                Seats = seats,
                SectionId = sectionId
            };

            await this.db.Tables.AddAsync(table);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TableAlreadyExist(string number)
        {
            var table = await this.db.Tables.FirstOrDefaultAsync(t => t.Number.ToLower() == number.ToLower());

            if (table == null)
            {
                return false;
            }

            return true;
        }
    }
}
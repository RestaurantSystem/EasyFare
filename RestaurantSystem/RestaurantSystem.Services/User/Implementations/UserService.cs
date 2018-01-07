namespace RestaurantSystem.Services.User.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Infrastructure;
    using RestaurantSystem.Services.User.Models;

    public class UserService : IUserService
    {
        private readonly RestaurantSystemDbContext db;

        public UserService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<TableServiceModel> GetTableAsync(string number)
        {
            var table = await this.db.Tables
                .ProjectTo<TableServiceModel>()
                .FirstOrDefaultAsync(a => a.Number == number);

            return table;
        }

        public async Task<TablesPaginationAndSearchModel> GetTables(string search, int page)
        {
            TablesListModel[] tables = await this.db.Tables
                .ProjectTo<TablesListModel>()
                .OrderBy(i => i.Number)
                .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                tables = tables
                    .Where(i => i.Number.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new TablesPaginationAndSearchModel
            {
                Tables = tables,
                ItemsCount = tables.Count(),
                Search = search,
                Page = page
            };
        }

        public async Task<bool> ReserveTableAsync(string id, DateTime date)
        {
            Table table = await this.db.Tables.FirstOrDefaultAsync(a => a.Number == id);
            table.Reservations = this.db.Reservations.Where(a => a.TableNumber == id).ToList();

            var reservationDate = date;
            if (table == null)
            {
                return false;
            }

            if (reservationDate <= DateTime.UtcNow)
            {
                return false;
            }

            if (table.Reservations.Any(a => a.StartTime.AddMinutes(45) > reservationDate && a.StartTime < reservationDate.AddMinutes(45)))
            {
                return false;
            }

            Reservation reservation = new Reservation()
            {
                StartTime = date,
                Table = table,
                TableNumber = table.Number
            };

            await this.db.Reservations.AddAsync(reservation);
            await this.db.SaveChangesAsync();

            return true;
        }
    }
}

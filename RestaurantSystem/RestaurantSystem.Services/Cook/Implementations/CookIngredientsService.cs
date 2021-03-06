﻿namespace RestaurantSystem.Services.Cook.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using Models.Ingredients;
    using RestaurantSystem.Data;
    using RestaurantSystem.Data.Models;
    using RestaurantSystem.Services.Cook.Infrastructure;

    public class CookIngredientsService : ICookIngredientsService
    {
        private readonly RestaurantSystemDbContext db;

        public CookIngredientsService(RestaurantSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Create(string name, float quantityInStock, float minStockQuantityThreshold)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Constants.IngredientNameErrorMessage);
            }

            if (quantityInStock < 0 || minStockQuantityThreshold < 0)
            {
                throw new ArgumentException(Constants.IngredientQuantityErrorMessage);
            }

            if (this.db.Ingredients.Any(i => i.Name == name))
            {
                return false;
            }

            await this.db.Ingredients.AddAsync(new Ingredient
            {
                Name = name,
                QuantityInStock = quantityInStock,
                MinStockQuantityThreshold = minStockQuantityThreshold
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> Edit(int id, string name, float minStockQuantityThreshold)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(Constants.IngredientNameErrorMessage);
            }

            if (minStockQuantityThreshold < 0)
            {
                throw new ArgumentException(Constants.IngredientQuantityErrorMessage);
            }

            if (!this.db.Ingredients.Any(i => i.Id == id))
            {
                return null;
            }

            if (this.db.Ingredients.Any(i => i.Id != id && i.Name == name))
            {
                return false;
            }

            Ingredient ingredient = await this.db.Ingredients.FindAsync(id);

            ingredient.Name = name;
            ingredient.MinStockQuantityThreshold = minStockQuantityThreshold;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IngredientsPaginationAndSearchModel> GetIngredients(string search, int page)
        {
            IngredientListModel[] ingredients = await this.db.Ingredients
                .ProjectTo<IngredientListModel>()
                .OrderBy(i => i.Name)
                .ToArrayAsync();

            if (!string.IsNullOrEmpty(search))
            {
                ingredients = ingredients
                    .Where(i => i.Name.ToLower().Contains(search.ToLower()))
                    .ToArray();
            }

            return new IngredientsPaginationAndSearchModel
            {
                Ingredients = ingredients,
                ItemsCount = ingredients.Count(),
                Search = search,
                Page = page
            };
        }

        public async Task<IngredientEditModel> GetIngredientToEdit(int ingredientId)
        {
            return await this.db.Ingredients
                .Where(i => i.Id == ingredientId)
                .ProjectTo<IngredientEditModel>()
                .SingleOrDefaultAsync();
        }
    }
}
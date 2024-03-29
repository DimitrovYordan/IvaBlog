﻿namespace IvaBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using IvaBlog.Web.ViewModels.Recipes;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditRecipeInputModel input);

        IEnumerable<T> GetByIngredients<T>(IEnumerable<int> ingredientsIds);

        Task DeleteAsync(int id);
    }
}

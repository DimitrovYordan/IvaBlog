namespace IvaBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using IvaBlog.Web.ViewModels.RecipeViewModel;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();

        T GetById<T>(int id);
    }
}

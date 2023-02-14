namespace IvaBlog.Services.Data
{
    using System.Threading.Tasks;

    using IvaBlog.Web.ViewModels.RecipeViewModel;

    public interface IRecipesService
    {
        Task CreateAsync(CreateRecipeInputModel input);
    }
}

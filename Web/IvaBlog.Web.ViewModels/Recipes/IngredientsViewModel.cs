namespace IvaBlog.Web.ViewModels.Recipes
{
    using IvaBlog.Data.Models;
    using IvaBlog.Services.Mapping;

    public class IngredientsViewModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}

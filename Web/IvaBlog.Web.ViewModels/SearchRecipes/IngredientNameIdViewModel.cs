namespace IvaBlog.Web.ViewModels.SearchRecipes
{
    using IvaBlog.Data.Models;
    using IvaBlog.Services.Mapping;

    public class IngredientNameIdViewModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

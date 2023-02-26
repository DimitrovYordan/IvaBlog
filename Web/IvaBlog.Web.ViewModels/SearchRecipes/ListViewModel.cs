namespace IvaBlog.Web.ViewModels.SearchRecipes
{
    using System.Collections.Generic;

    using IvaBlog.Web.ViewModels.Recipes;

    public class ListViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }
    }
}

namespace IvaBlog.Web.ViewModels.RecipeViewModel
{
    using System.Collections.Generic;

    using IvaBlog.Web.ViewModels.Recipes;

    using Microsoft.AspNetCore.Http;

    public class CreateRecipeInputModel : BaseRecipeInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }
    }
}

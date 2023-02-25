namespace IvaBlog.Web.Controllers
{
    using IvaBlog.Services.Data;
    using IvaBlog.Web.ViewModels.Recipes;
    using IvaBlog.Web.ViewModels.SearchRecipes;

    using Microsoft.AspNetCore.Mvc;

    public class SearchRecipesController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly IIngredientsService ingredientsService;

        public SearchRecipesController(
            IRecipesService recipesService,
            IIngredientsService ingredientsService)
        {
            this.recipesService = recipesService;
            this.ingredientsService = ingredientsService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Ingredients = this.ingredientsService.GetAll<IngredientNameIdViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Recipes = this.recipesService.GetByIngredients<RecipeInListViewModel>(input.Ingredients),
            };

            return this.View(viewModel);
        }
    }
}

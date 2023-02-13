namespace IvaBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using IvaBlog.Services.Data;
    using IvaBlog.Web.ViewModels.RecipeViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipesService recipesService)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View();
            }

            await this.recipesService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}

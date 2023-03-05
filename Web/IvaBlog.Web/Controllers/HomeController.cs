namespace IvaBlog.Web.Controllers
{
    using System.Diagnostics;

    using IvaBlog.Services.Data;
    using IvaBlog.Web.ViewModels;
    using IvaBlog.Web.ViewModels.Home;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IRecipesService recipesService;

        public HomeController(
            IGetCountsService countsService,
            IRecipesService recipesService)
        {
            this.countsService = countsService;
            this.recipesService = recipesService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                IngredientsCount = countsDto.IngredientsCount,
                RecipesCount = countsDto.RecipesCount,
                RandomRecipes = this.recipesService.GetRandom<IndexPageRecipeViewModel>(6),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

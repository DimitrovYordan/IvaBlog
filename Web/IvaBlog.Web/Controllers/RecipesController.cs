namespace IvaBlog.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using IvaBlog.Common;
    using IvaBlog.Data.Models;
    using IvaBlog.Services.Data;
    using IvaBlog.Web.ViewModels.Recipes;
    using IvaBlog.Web.ViewModels.RecipeViewModel;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipesService recipesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.recipesService.GetById<EditRecipeInputModel>(id);
            inputModel.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            await this.recipesService.UpdateAsync(id, input);

            // nameof will change automatically ById if we change it
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            // This will take userId from Claims, will not work DB
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            //// Will catch if image extension is not allowed or there is some error
            try
            {
                await this.recipesService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.CategoriesItem = this.categoriesService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            this.TempData["Message"] = "Recipe added successfully.";

            return this.Redirect("All");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new RecipeListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                RecipesCount = this.recipesService.GetCount(),
                Recipes = this.recipesService.GetAll<RecipeInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var recipe = this.recipesService.GetById<SingleRecipeViewModel>(id);

            return this.View(recipe);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.recipesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}

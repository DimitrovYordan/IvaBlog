namespace IvaBlog.Services.Data
{
    using System.Linq;

    using IvaBlog.Data.Common.Repositories;
    using IvaBlog.Data.Models;
    using IvaBlog.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipeRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
                RecipesCount = this.recipeRepository.All().Count(),
            };

            return data;
        }
    }
}

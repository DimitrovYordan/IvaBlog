namespace IvaBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using IvaBlog.Data.Common.Repositories;
    using IvaBlog.Data.Models;
    using IvaBlog.Services.Mapping;

    public class IngredientsService : IIngredientsService
    {
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public IngredientsService(IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.ingredientRepository.All()
                .Where(x => x.Recipes.Count() >= 20)
                .OrderByDescending(x => x.Recipes.Count())
                .To<T>().ToList();
        }
    }
}

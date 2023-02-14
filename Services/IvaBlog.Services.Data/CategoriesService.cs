namespace IvaBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using IvaBlog.Data.Common.Repositories;
    using IvaBlog.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        IEnumerable<KeyValuePair<string, string>> ICategoriesService.GetAllAsKeyValuePairs()
        {
            return this.categoriesRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}

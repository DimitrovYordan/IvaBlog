namespace IvaBlog.Web.ViewModels.Recipes
{
    using System.Linq;

    using AutoMapper;

    using IvaBlog.Data.Models;
    using IvaBlog.Services.Mapping;

    public class RecipeInListViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                x.Images.FirstOrDefault() != null ?
                x.Images.FirstOrDefault().ToString() :
                "images/recipes" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}

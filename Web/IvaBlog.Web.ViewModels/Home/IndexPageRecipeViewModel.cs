﻿namespace IvaBlog.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;

    using IvaBlog.Data.Models;
    using IvaBlog.Services.Mapping;

    public class IndexPageRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, IndexPageRecipeViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                x.Images.FirstOrDefault() != null ?
                x.Images.FirstOrDefault().ToString() :
                "images/recipes" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
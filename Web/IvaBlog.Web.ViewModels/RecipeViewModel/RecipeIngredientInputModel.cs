using System.ComponentModel.DataAnnotations;

namespace IvaBlog.Web.ViewModels.RecipeViewModel
{
    public class RecipeIngredientInputModel
    {
        [Required]
        [MinLength(3)]
        public string IngredientName { get; set; }

        [Required]
        [MinLength(3)]
        public string Quantity { get; set; }
    }
}

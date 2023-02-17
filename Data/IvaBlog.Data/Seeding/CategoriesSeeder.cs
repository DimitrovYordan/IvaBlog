namespace IvaBlog.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using IvaBlog.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Сладкиши" });
            await dbContext.Categories.AddAsync(new Category { Name = "Пилешко" });
            await dbContext.Categories.AddAsync(new Category { Name = "Свинско" });

            await dbContext.SaveChangesAsync();
        }
    }
}

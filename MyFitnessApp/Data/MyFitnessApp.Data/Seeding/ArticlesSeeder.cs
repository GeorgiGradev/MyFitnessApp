namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ArticlesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Articles.Any())
            {
                return;
            }

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Carbohydrates",
                Content = "Carbohydrates are controversial among people trying to lose weight. Because individual carbohydrate needs aren’t one-size-fits-all, we’ve put together an informational guide to help you optimize your carbohydrate consumption and choose healthier options, whether you’re trying to lose weight, train for your first half-marathon or anything in between." +
                "Carbohydrates are found in almost all foods and provide 4 calories per gram. As you can imagine, not all carbohydrates are created equal. Different carbohydrates affect your body differently. Carbohydrate-containing foods generally have a combination of two types of carbohydrates: simple and complex." +
                "Simple carbs are also known as “sugar.” It’s made of up to two sugar building blocks connected in a chain. The building blocks can be glucose, fructose and galactose. Because the chains are short, they’re easy to break down, which is why they taste sweet when they hit your tongue. They are also digested and absorbed into the bloodstream quickly. Foods high in simple carbohydrates include sweeteners(table sugar, syrup, honey), candy",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category= dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "How This Radio Host Lost 70 Pounds and Learned to Love Movement",
                Content = "After tracking her weight on MyFitnessPal since 2013, Long Island-based Jenny Hutt has finally found the sweet spot. Hutt is the talkative,charismatic host of “Just Jenny” on SiriusXM Stars 109(you can catch her weekdays 12–2 p.m.ET), but she’d be the first to tell you, “losing weight is a b * ***. To have the same pair of jeans in my closet for 10 years … that’s a miracle,” she says. Now 51, Hutt was a self - described average - to - chubby kid who always had issues with her weight and body image.After gaining the “college 20,” she spent the summer after graduation over - exercising and under - eating.She lost 23 pounds but gained it back(and more) during law school.In 1997, Hutt married her husband, Keith, then had two children in the next three years, and found her weight was out of control. I was working, I was a mom, then my mother got diagnosed with pancreatic cancer in 2007 and passed away in 2008,” she says. “That was almost 13 years ago.We were very close, and I took care of her.It’s very hard to diet while encouraging a loved one with cancer to eat.Plus, I used food to comfort me during this incredibly stressful and sad time.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}

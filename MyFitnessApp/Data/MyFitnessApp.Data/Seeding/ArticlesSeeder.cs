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

            // Recipes
            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Chocolate N’Ice Cream",
                Content = "Skip the dairy, fat and sugar — all with the magic of “nice cream.” The secret lies in the creamy sweetness of ripe bananas, frozen solid and then pureed. You’ll need a good blender and need to work quickly, so you can eat the nice cream while it has the texture of soft-serve. You can freeze the puree to eat later. Just spread it thinly in a storage tub so it softens evenly when you get it out to serve. The colder a food is, the harder it is to taste the sugar, so foods taste sweeter at room temperature than if they are frozen. That’s one of the reasons ice cream has so much sugar: It’s served cold, so it needs more sugar to taste sweet. All this to say, your “nice cream” will taste sweeter and creamier if it is lightly frozen, instead of totally frozen. Active time: 10 minutes Total time: 8 hours",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category= dbContext.ArticleCategories.Where(x => x.Name == "Recipes").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "1" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Make-Ahead Instant Oatmeal Jars",
                Content = "Instant oatmeal packets are a godsend for busy mornings, but have you considered crafting your own instant oatmeal jars? By purchasing oatmeal, dried fruit and nuts in bulk, you can make your own version of instant oatmeal, and save money at the same time. Use adorable mason jars to portion out your meal, or some light zip-lock bags will also do the trick. To make your oatmeal jar, layer the ingredients in the following order: oatmeal, salt, cinnamon, cranberries and almond slivers. Make as many jars as you’d like and store in a dry area. If you don’t have mason jars, feel free to make oatmeal packets using zip-lock bags. Remember to label with the date so you can keep track of freshness.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Recipes").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "2" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();


            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Cauliflower-Crusted Spinach Feta Pie",
                Content = "Rich, buttery spanakopita is a favorite at Greek restaurants, but a slice packs a hefty caloric punch. Luckily, the delicious combination of spinach and feta is just as alluring when lightened up and baked in a cauliflower crust. Naturally gluten-free, cauliflower makes a great alternative to flour-and-butter crusts and adds even more veggie servings to the pie. While it cools, whisk the 2 egg whites with the parmesan in a medium bowl. When the cauliflower has cooled, pull up the edges of the towel and make a bundle, and press and knead the cauliflower over the sink to remove as much water as possible. Wring and twist the towel to squeeze out all the moisture; it will take a few minutes. When nearly dry, transfer the cauliflower to the bowl with the egg whites and stir to mix. Spoon into the oiled pie pan and press down with the back of the spoon to form a crust, making a rim about half an inch above the edge of the pan. Bake for 15-20 minutes. The edge will be browned and the bottom will look dry.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Recipes").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "3" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "1-Minute Berry Peanut Butter Smoothie For Two",
                Content = "Make a delicious smoothie with just 9 grams of sugar (less than one tablespoon of sugar)? Challenge accepted! This lower-sugar berry and peanut butter smoothie is kitchen-tested and taste-approved from the folks at MyFitnessPal! Calories: 156; Total Fat: 8g; Saturated Fat: 1g; Monounsaturated Fat: 0g; Cholesterol: 1mg; Sodium: 57mg; Carbohydrate: 19g; Dietary Fiber: 7g; Sugar: 9g; Protein: 5g",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Recipes").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "4" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Peanut Butter Breakfast Cookies",
                Content = "These delicious bite-sized peanut butter cookies are sure to be a popular treat for kids and adults-alike. Their timeless sweet and nutty flavor is perfectly paired with a smear of jam and glass of milk. Add the ripe bananas and eggs into a medium mixing bowl. Mix with a spatula, mashing on the banana to get chunks as small as possible. Add the oats, peanut butter, honey, and salt, and stir until just combined. The mixture will get thick and hard to stir. Use a 1/4 cup measure to portion cookie dough into 12 balls. Take each ball and split it in half to create 24 smaller balls. Roll each ball and lightly smash it between your palms to create a mini cookie.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Recipes").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "5" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            // Fitness

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "5 Stretches to Relieve Work-From-Home Pains",
                Content = "In this age of constant connectedness and digital everything, many of us spend the bulk of our days sitting down and staring at laptops and phones. This fact only increased during the pandemic, as the world transitioned to a work-from-home setup that saw us living and working in the same space, tethered to our devices. While working from home brings convenience and freedom, it can also be a literal pain in the neck. “If you sit for an extended period of time, you’ll most likely develop terrible posture,” says Dr. Gbolahan Okubadejo, a spinal and orthopedic surgeon at the New York-area Institute for Comprehensive Spine Care. He notes that poor posture, like slumping in your chair, often leads to chronic back, shoulder and neck pain, as well as poor circulation.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Fitness").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "6" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Four Common Types of Stretches and When to do Each",
                Content = "Whether you’re an elite athlete, weekend warrior, average gym-goer or just starting to exercise for the first time, you’ve probably tried stretching to loosen muscles before a workout or to help sore muscles recover. But what most people don’t know is there are many types of stretching and different recommendations on when to perform each, so the practice goes well beyond touching your toes. Depending on who you ask, there are multiple types of stretches, but the four common movement patterns include static, active, dynamic and ballistic stretching. Some are better for warming up before workouts, while others are recommended for cooling down afterward. To learn more, we spoke with a man who moves for a living: Anthony Crouchelli, founder of the.1method and Master Trainer at GRIT BXNG. Below, he explains the four movement patterns and what to know about each one.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Fitness").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "7" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "How to Get Your Steps When it’s Too Hot to Walk Outside",
                Content = "It’s summertime in the Northern Hemisphere, which means the chance to spend more time outside. But for many people, especially those who are sensitive to the heat or too much sun, summer weather can pose a challenge when trying to meet their daily steps goal. Here, we’re looking at the different ways you can sneakily boost your steps without risking heatstroke or sunburn. As more places begin to re-open, look at what’s available around you for indoor areas where walking is easy. Of course, there’s always the treadmill at the gym, but this could also include walking around an indoor mall or indoor track. If you have kids in after-school activities, like dance or hockey, consider walking around in those buildings during their practices. You don’t need a formal walking track to increase your step count. Even if you feel self-conscious at first walking around the auditorium while your child is in ballet, that could be the only chance you have to get your steps in, so it’s worth it. You might even encourage other parents to join you!",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Fitness").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "8" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "The Benefits of an E-Bike",
                Content = "For many cycling purists, the notion of adding an assisted motor to a bicycle is a form of cheating that doesn’t offer the same type of physical and mental benefits as a traditional bike. Sure, riding an electric bike (e-bike) might not be as difficult as tackling that monster climb with only the power in your legs — but does that mean an e-bike won’t provide a good workout, and are you better off walking around the block a few times instead? Recently, researchers at the University of Zurich aimed to tackle this question by monitoring 10,000 e-bike riders over a full year. In this article, we take a look at the findings of this study and offer a few of our own reasons why e-bikes shouldn’t be discounted as a reasonable way to improve overall fitness.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Fitness").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "9" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Exercise Boosts Creativity and Brain Function",
                Content = "Some people have their best ideas in the shower. Others come to important conclusions while out for a stroll. Wherever your light bulb moments occur, research shows people who exercise may be more creative than those who don’t. Past studies have shown a correlation between exercise and short-term bursts in creativity. A 2014 Stanford University study analyzed the creative thinking of 176 participants, noting that people consistently provided more inspired responses on tests used to measure creative thinking when they were walking versus when they were sedentary. Walking’s impact also extended to immediately after exercise was completed. While participants didn’t score as high when they were seated as when they were moving, those who sat down for a second test after walking felt a residual effect, performing better on tests than those who didn’t walk at all.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Fitness").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "10" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            // Nutrition
            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Are High-Protein Ice Creams Actually Healthy?",
                Content = "High-protein ice cream, which typically contains fewer calories and sugar than traditional ice cream, has been increasing in popularity over the past couple of years. But, does a lower calorie and sugar content also mean they are “healthier” than the real stuff? Not necessarily. It may also depend on how you define health. Here’s a breakdown of nutrients and ingredients for the most popular higher protein ice creams, and some of my thoughts on just how healthy I think they are. Arctic Zero is made from water, faba (or fava) bean protein, as well as sugar, a sugar substitute called allulose, sugar cane fiber, thickeners and monk fruit (another sugar). This dessert contains about 2 grams of protein per serving, and 6 grams for the entire pint. Thus, it’s not very high in protein. Arctic Zero has no fat, and about 8 grams of fiber per pint, likely from the fava bean and sugar cane fiber. The calorie content of Arctic Zero is extremely low, with the vanilla clocking in at 160 calories per pint. Arctic Zero does not contain significant amounts of vitamins or minerals.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Nutrition").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "11" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "What 2,000 Calories Looks Like (Plant-Based Diet)",
                Content = "One of the most commonly asked questions around eating a plant-based diet is … how do I get enough protein? And the short answer is … just eat a variety of foods! All plant foods contain some protein (that’s right — anything grown from the earth) and it’s pretty easy to get what you need if you eat a variety of foods, especially nuts and seeds, whole grains, beans and legumes. Most people don’t require more than moderate amounts of protein, but if you’re looking to get additional protein in your plant-based meals, try adding nuts and seeds to your oatmeal or throwing some sauteed tofu or tempeh onto your salad or buddha bowl and opting for higher protein grains like quinoa versus brown rice. This fun, summer-inspired 2,000-calorie menu is chock full of every food group — fiber-rich whole grains, heart healthy nuts and seeds, and antioxidant-rich fruit and vegetables!",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Nutrition").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "12" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "8 Nutrient-Dense Summer Foods to Keep You Fuller Longer",
                Content = "Summer means longer days, which means more hours to soak up the sun and stay active. At the same time, more hours on the go can also translate into meals that are more spaced out than usual. Even if you keep your eating schedule the same across all seasons, there’s nothing worse than finishing a meal, only to realize you’re hungry again just an hour or two later. Luckily, summer brings with it a host of satiating fiber, protein and water-rich foods that’ll keep you feeling full from one meal to the next. Here, nutrition pros share their favorite warm-weather eats that are packed with nutrients and sure to satisfy. “It’s easy to get dehydrated in the summer, but watermelon is a water-filled fruit that helps meet your daily hydration goals,” explains Mary-Catherine LaBossiere, a registered dietitian. And while watermelon doesn’t have as much fiber as some other fresh fruit, its combination of water and fiber is highly satiating. Add to that the fact it’s a great source of vitamins A and C, lycopene and citrulline, and you’ve got a warm-weather winner. You can also boost the fruit’s filling factor by pairing it strategically with other foods. For instance, you could make a watermelon, basil and feta salad with balsamic vinegar, LaBossiere suggests. “Combining a fruit, like watermelon, with the fat in feta helps slow down how quickly your blood sugar rises after eating watermelon.” That means you won’t be left craving more food right after you eat.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Nutrition").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "13" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Healthy Habits For Life: 10 Tips For Better Nutrition and Weight Loss",
                Content = "Weight loss isn’t about a quick fix or detox, it’s about creating lasting habits that help you lead a healthier lifestyle. This can be especially challenging during the holidays, when your normal routines get altered. However, by incorporating the 10 nutrition tips below you can set yourself up for success for a lifetime — even when you feel stressed or busy. You don’t have to completely overhaul your diet to lose weight. Start by making small changes such as eating fruit instead of drinking fruit juice and adding more colorful foods to your plate. Over time these small tweaks will add up to big results. If you’re looking for more inspiration, check out these 67 science-backed weight loss strategies. A portion size is the amount of food or drink you actually consume in one sitting. This guide will help you match your portions to recommended servings sizes, or what’s on a food label. Learning to be mindful of portions can help prevent overeating. For more of a visual, here’s what 1,200, 1,500 and 2,000 calories in a day looks like.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Nutrition").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "14" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "A Dietitian’s Top Summer Grocery Store Staples",
                Content = "As a registered dietitian, visiting the grocery store is like taking a trip to Disneyland. There are always new foods, recipe ingredients and trends to try and learn about for myself and my clients. Summer at the grocery store is a special time because it’s packed full of delicious seasonal products that are unique and perfectly suited for summer activities and temperatures. Here are my top summer grocery staples that I never leave the store without, and why I love them so much. Blueberry season is the best season, and these tasty berries just so happen to be at their peak in the summertime. Blueberries contain high amounts of the antioxidant anthocyanin, which gives them their deep blue hue. They have potent anti-inflammatory properties that help protect our cells. Blueberries are also a great source of vitamin C, important for skin and immune health, and fiber, which helps promote satiety after meals. I love blueberries for breakfast on top of Greek yogurt or a bowl of oats, or on their own as a portable beach or park day snack. Try freezing fresh blueberries for a refreshingly cold treat on a hot day. To me, salsa screams summer. It’s refreshing and versatile and can add taste, flavor and texture to anything from omelets to tacos and quesadillas. Salsa also makes a perfect outdoor dinner party snack paired with some pita, tortilla chips or fresh veggies. Nutrition-wise, tomato-based salsas are high in the antioxidant lycopene, as well as vitamin C. Lycopene is a powerful antioxidant that protects the body’s cells from damage caused by free radicals, and may help reduce the risk of chronic disease and some cancers. You can’t really go wrong when choosing a salsa — a chunky tomato salsa is my favorite for tacos, eggs and chips, but I love a salsa with fruit like mango or peach for a little sweetness from time to time, too. Whole Foods and Trader Joe’s have great “house” brands for a variety of salsa flavors.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Nutrition").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "15" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            // Weight-loss

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "8 Foods That Are Surprisingly Good For Weight Loss",
                Content = "Losing weight doesn’t always have to be about deprivation and denial. In fact, it shouldn’t be. Successful, sustainable weight loss is far more attainable when you focus on the quality of food rather than the quantity. Eat wholesome, nutritious, (and even calorie-filled) foods and you’ll be far more satisfied and content on less. Many of the foods people think are off-limits when it comes to losing weight are the very foods that have the ability to actually help us reach our goal. Here are eight foods that cannot only help you reach your weight-loss goal, but help you keep it off for good. Drink skim and stay slim? Not always so when it comes to dairy. A recent study published in the American Journal of Nutrition found that more than 18,000 women who consumed more higher-fat and whole-milk dairy products had a lower risk of being overweight. How can this be? Some essential fatty acids are stripped when milk is skimmed — the very component that may help you feel fuller sooner and stay full longer with full fat products. Several studies have found that when people reduce the amount of fat in their diet, they tend to replace it with sugar and refined carbohydrates, which can have a worse effect on overall health.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Weight-loss").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "16" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "The Truth About Meal Replacement Shakes for Weight Loss",
                Content = "Imagine this: You’re sitting at your desk between meetings, and you realize you’ve only got 10 minutes for lunch. You didn’t prep anything ahead of time, and 10 minutes isn’t long enough to whip up something healthy or even run out to grab a salad. If you’re trying to stay on track with your weight-loss goal, this can be a stressful situation.Enter: the meal replacement shake. A quick, convenient solution, these pre-made drinks are usually easy to find in grocery stores — or you can order a whole case online to keep on hand for situations just like this. As for why meal replacement shakes seem to be making a comeback, there are a couple of big reasons, according to Olivia Ashton Brant, RD, Certified Specialist in Sports Dietetics. “The first is because they are easy and convenient, especially in the mornings, when most of us prioritize a few extra minutes of sleep over cooking breakfast.” The second is the idea of a shake being associated with weight loss, even if it’s not explicitly marketed that way. “I think, by default, people associate all meal replacement products to be something that will help with weight management,” Brant explains.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Weight-loss").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "17" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Are Food Sensitivities Making it Harder for You to Lose Weight?",
                Content = "Losing weight can feel like such an uphill battle. Whether you’re dealing with cravings, stress eating or hormonal imbalance, there are lots of potential roadblocks that could keep you from reaching your goal on the timeline you expected. But, is eating foods that don’t agree with you a potential contributing factor to slow weight loss? Here’s what experts had to say, plus how to deal if you suspect you have a food sensitivity. Food intolerances, on the other hand, are usually GI-related. They happen when the body has a hard time digesting a certain food. “The most common example is a lactose intolerance, which happens when someone lacks enough of the digestive enzyme lactase to digest lactose, a sugar found in cow’s milk,” McAsey explains. These reactions happen almost exclusively in the GI tract, meaning they primarily cause digestive symptoms, and don’t cause the widespread immune response seen with allergies. Food sensitivities are understudied compared to allergies and intolerances, Cureton says. They’re similar in the sense that they’re immune-mediated reactions to particular nutrients (meaning the immune system is involved), but they’re not exactly the same as food allergies, and they’re not as well-understood. “Importantly, the symptoms of the sensitivity can change, meaning that reactions don’t always happen the same way,” Cureton says. One day, eating the nutrient you’re sensitive to could result in a stomachache, the next day it could produce eczema, the next day it could result in joint pain, she explains. That can make food sensitivities tricky to pin down.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Weight-loss").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "18" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "10 Summer Foods to Boost Weight Loss",
                Content = "Whether you’re hitting the beach, tanning by the pool or just trying to look and feel your best this summer, it’s important to incorporate fresh, seasonal fruits and vegetables into your diet. With all that sunshine comes foods that are packed with antioxidants, nutrients and water to rehydrate your long summer days. Although eating certain foods can’t automatically prompt weight loss, replacing high-calorie foods with low-calorie ones can shift you toward burning more calories than you consume — the key to shedding extra weight. The best way to make these swaps is by choosing nutrient-dense foods (that are naturally lower in calories) to enhance your health and ensure you’re still getting all the necessary nutrients needed for your weight-loss journey. Whichever kind you prefer — blueberries, blackberries, raspberries or strawberries — these summer fruits contain several important nutrients and are lower in calories than other fruits such as bananas and mangoes. Berries are high in fiber (one cup of raspberries has 8 grams of dietary fiber, which is nearly a third of the recommended intake for women and 20% of what men need in a day), which helps you feel full longer and reduces the temptation to snack between meals. Berries are also rich in antioxidants and vitamins B and C.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Weight-loss").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "19" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Healthy Habits For Life: 10 Tips For Better Nutrition and Weight Loss",
                Content = "You don’t have to completely overhaul your diet to lose weight. Start by making small changes such as eating fruit instead of drinking fruit juice and adding more colorful foods to your plate. Over time these small tweaks will add up to big results. If you’re looking for more inspiration, check out these 67 science-backed weight loss strategies. A portion size is the amount of food or drink you actually consume in one sitting. This guide will help you match your portions to recommended servings sizes, or what’s on a food label. Learning to be mindful of portions can help prevent overeating. For more of a visual, here’s what 1,200, 1,500 and 2,000 calories in a day looks like. There’s no one-size fits all diet. While keto, paleo, DASH or intermittent fasting might work well for a friend or family member, that doesn’t necessarily mean it’s right for you. Rather, it’s important to focus on eating a variety of nutrient-dense foods, including fruits, veggies, grains, lean proteins and healthy fats. Ultimately, healthy eating is a lifestyle that nourishes your body, gives you energy and is sustainable long-term.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Weight-loss").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "20" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            // Inspiration
            await dbContext.Articles.AddAsync(new Article
            {
                Title = "From Wheelchair to Gym: How Cesar Lost 185 Pounds",
                Content = "Cesar Salazar was 31 years old when an injury placed him in a wheelchair. He was working in the parts department of a car dealership in Houston in 2014 when a small accident damaged his lumbar spine and pinched his sciatic nerve, leaving him nearly immobile from the waist down. “The doctor told me the injury was due to me being too heavy, not just the accident,” says Salazar. “They couldn’t operate, so I just needed to rest and heal. I ended up staying in that chair for eight months. Salazar’s immobility, paired with unhealthy eating habits, caused him to gain more weight, and he reached nearly 500 pounds at his heaviest. “I was watching ‘My 600-Lb Life’ on TV and realized I was only 100 pounds away from that point,” he says. “I knew I needed to make a decision and get out of the wheelchair.v",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "21" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "How This Radio Host Lost 70 Pounds and Learned to Love Movement",
                Content = "After tracking her weight on MyFitnessPal since 2013, Long Island-based Jenny Hutt has finally found the sweet spot. Hutt is the talkative, charismatic host of “Just Jenny” on SiriusXM Stars 109 (you can catch her weekdays 12–2 p.m. ET), but she’d be the first to tell you, “losing weight is a b****.Now 51, Hutt was a self-described average-to-chubby kid who always had issues with her weight and body image. After gaining the “college 20,” she spent the summer after graduation over-exercising and under-eating. She lost 23 pounds but gained it back (and more) during law school. In 1997, Hutt married her husband, Keith, then had two children in the next three years, and found her weight was out of control.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "22" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "This Baker Lost 143 Pounds Without Skipping the Occasional Cupcake",
                Content = "After a major weight loss, it’s normal to celebrate your success, look back on your journey, and remind yourself of how far you’ve come. Jenni Gayden took this theory a step further by turning her success into a tattoo. On her leg is the image of a chocolate-frosted cupcake wrapped in a measuring tape. The numbers 18, 19 and 20 on the tape represent the years she worked to drop down from a starting weight of 317, and at the top of the tape is 100 — representing when she hit that milestone of weight lost. Then, after a plateau, her weight went in the other direction. Not only did she gain back the 60 pounds she had lost, but ended up 50 pounds heavier than her starting weight. The setback was tough enough that she didn’t try again because she was concerned that a repeat experience would lead to even more weight gain.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "23" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "How Carmelo Lost 135 Pounds and Overcame Type 2 Diabetes",
                Content = "When Maryland-based graphic designer Carmelo Rivera heard his doctor tell him he had Type 2 diabetes in 2013, he thought it was a death sentence. His father had passed away from the same disease when Rivera was 9 years old, and after he broke 300 pounds at 28 years old, he wondered if he would meet the same fate. Rivera says his two kids, now ages 9 and 11, were his main inspiration. Not wanting them to lose their father like he had, he started slowly making lifestyle changes shortly after his diagnosis. While he didn’t set an initial goal, he felt it was more sustainable to take it day by day and set reasonable expectations for himself. “The first two months were weaning off the bad stuff, but after that, I committed 100% to the Paleo diet,” he says. “Some of my go-to choices now are grilled chicken, sweet peas and turkey burgers with no buns — but I do add tomatoes, lettuce and cheese.” “It helped me stay on track because, at the beginning, it was about how many calories I was consuming a day, whereas, toward the middle and end of my journey, I was more concerned about how many carbs I was taking in,” he says. “It displays it all right there, and it taught me what foods had carbs. I used the app for around two years until I learned how to manage my diet on my own.”",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "24" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "How Erica Lost 160 Pounds After Yo-Yo Dieting For Years",
                Content = "Eighty pounds lost, then 100 pounds gained. Twice. That was the history of 35-year-old Oregon resident Erica Kennett in her attempts at weight loss. As it turned out, her third effort, however, on that roller coaster would be the charm — and the endpoint. Kennett had struggled with her weight her entire life, with awareness of the problem beginning around age 6. At age 9, a doctor put her on her first diet and she spent years bouncing from one eating plan to another. About three months before her high school graduation, she decided to try a “crash shake diet” that reduced her calories considerably. While it worked initially, and she lost 80 pounds, eating normally once she got to college caused the weight to come back, plus 20 more pounds. A few years later, she and her husband decided to take a joint approach to weight loss. Already diagnosed with high blood pressure and diabetes at 21, Kennett wanted to do as much as she could to get healthy. Turns out, she was right. To prep for the surgery, she was asked to attend six months of appointments and classes with different medical providers. In those months leading up to surgery, she set a personal goal to lose 80 pounds — the number she was oh-so-familiar with by now. But this time, instead of drastic calorie-cutting, she decided to change her eating habits to be as healthy as possible for the surgery and recovery.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Inspiration").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "25" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            // Essentials
            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Walking and Steps",
                Content = "Walking is one of the most rewarding lifelong activities you can choose. While it may not be a huge calorie burner — the average person burns about 100 calories or so per mile — adding more mileage to your day can make a big difference in weight control. According to Harvard Health Watch, one study found the average person gains about 2.2 pounds a year during middle age. However, over 15 years of research, the study found that individuals who walked regularly gained significantly less weight than those who didn’t. Walking also offers plenty of health benefits, including lowering the risk of high blood pressure, heart disease and diabetes; reducing the risk of developing dementia and cancer and even reducing fibromyalgia pain. Plus, walking may be even more beneficial than running. Walkers have a much lower risk of exercise-related injuries than runners, whose legs absorb about 100 tons of impact force in just one mile. So, if you’re just starting your fitness journey, know that fitness walking is a seriously good place to begin. Whatever makes you feel comfortable is the easy answer. There is no need for fancy spandex or workout clothes, unless that’s what you like. As you start moving farther and faster, you may want to get dedicated fitness walking clothes that wick away sweat or allow you to layer for different weather conditions, but for a beginning fitness walker, comfort trumps everything else.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "26" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Hydration",
                Content = "Have you had enough water today? This question is often left out of the nutrition conversation but has an enormous impact on our health and day-to-day function. Our body is composed of roughly 60% water and every major system is influenced by fluid balance. Water transports nutrients to organs and cells, carries away toxins, serves as a lubricant for joints and bones, helps us regulate our body temperature and even impacts brain function. Without water, we simply cannot survive. That said, you don’t have to be on the brink of death to feel the effects of dehydration. Even a 2% decrease in body weight due to fluid losses can impact physical and mental performance. The Institute of Medicine recommends 3.7 liters/day for adult men and 2.7 liters/day for adult women; however, you may need more if you’re physically active, breastfeeding and/or during the warmer months. It’s also important to keep in mind that water losses vary from person to person, and some people naturally need more fluid than others. Yes, you can have too much water. Roughly 80% of our hydration needs come from fluids like water, milk and tea. The remaining 20% comes from high-water foods such as fruit, veggies and yogurt. Some fluid and food choices are better than others for hydration. For example, alcoholic beverages are fluids that increase water loss by blocking anti-diuretic hormones.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "27" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Strength Training",
                Content = "Whether you’re looking to sign up for a 5K or simply live a healthier life and engage in a wide range of activities with greater ease, strength training can help you achieve your goals. Strength training isn’t about body-building or bulging muscles. Strength training focuses on building functional strength, which means strengthening your muscles, connective tissues and bones to handle a variety of moves, whether it’s lifting, pushing or pulling and training your central nervous system to recruit muscles effectively. Here, we’ve rounded up some of the proven benefits of strength training, along with methods on how to get started. There’s no shortage of evidence to back up the health-related benefits of strength and resistance training. It’s been shown to decrease the risk of heart attack and stroke, lower blood pressure and improve glucose metabolism and insulin sensitivity. Strength training also has a positive influence on bone density, helping prevent osteoporosis in aging adults. Although aerobic exercise is still cited as an important component of promoting overall health, resistance exercises play a particularly vital role in building and maintaining bone mineral content and density, fortifying your bones against injuries during exercise.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "28" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Running Nutrition",
                Content = "Putting in the miles makes a person a runner, but fueling your body well can turn a middle-pack runner into a great runner. Proper nutrition provides your body with the energy to go the distance, improves body composition, aids injury prevention and reduces mid-run stomach issues. This guide provides the nutrition knowledge to fuel your running needs. As a runner, your body needs the same three macronutrients — carbohydrates, fat and protein — as anyone else, but in slightly different amounts. Each of these macros relates to runner’s needs increased needs slightly beyond the basics of the general population. Beyond macronutrients and overall calories, runners need to make sure they are getting micronutrients like vitamins, minerals and phytonutrients from a variety of whole foods to support good health functions, proper recovery and energy metabolism. Most runners are familiar with the concept of increasing carbohydrates prior to a big run or race. The purpose of this is to load the body with maximum energy stores for ultimate performance. Informing yourself on the details of a carb load can help you achieve a PR. The simple protocol is to consume 10–12 grams of carbohydrates per kilogram of body weight for 48 hours leading up to the target event.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "29" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();

            await dbContext.Articles.AddAsync(new Article
            {
                Title = "Essential Guide to Avoiding Running and Walking Injuries",
                Content = "Research suggests that anywhere from 20–80% of runners end up injured each year. This number is lower for walkers as a result of the reduced impact forces, but still, pavement pounders of every ilk deal with a host of nagging pains — from knee pain to plantar fasciitis. Many studies try to pinpoint specific risk factors in hopes of helping runners and walkers avoid injuries in the first place. For instance, one study looked at 930 new runners and found the oldest participants (ages 45–65) were more likely to sustain an injury. Those who had a BMI greater than 30 also had a higher injury rate, as did those who had a past, non-running-related injury. What’s more, they even found personality may impact injury rate: Runners with a Type B personality (as opposed to Type A), defined as “relaxed, laid-back,” experienced more running injuries. If you fall into any of these categories, it can be useful to know you may need to be more vigilant when it comes to injury prevention. Understanding the signs and symptoms of common running and walking ailments, as well as how to respond, will also help you skirt major issues that can leave you sidelined. In the vast majority of cases, arming yourself with basic injury information and listening to your body keeps you healthy and running or walking all season (or year) long. It’s important to intuit the difference between soreness and pain associated with an injury. If you’re entering a new training program after a period of inactivity, you’re likely to experience a few aches as your body adjusts. If, however, you experience sharp or intense pain anywhere, you should respond immediately.",
                AddedByUser = dbContext.Users.Where(x => x.UserName == "admin").FirstOrDefault(),
                Category = dbContext.ArticleCategories.Where(x => x.Name == "Essentials").FirstOrDefault(),
                ImageUrl = "/images/articles/" + "30" + "." + "jpg",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}

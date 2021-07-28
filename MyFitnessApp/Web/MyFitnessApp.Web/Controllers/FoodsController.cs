namespace MyFitnessApp.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyFitnessApp.Services.Data.Food;
    using MyFitnessApp.Web.ViewModels.Foods;

    public class FoodsController : Controller
    {
        private readonly IFoodsService foodsService;

        public FoodsController(IFoodsService foodsService)
        {
            this.foodsService = foodsService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateFoodInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (this.foodsService.DoesFoodExists(model.Name))
            {
                this.TempData["MessageForExistingFood"] = "Food already exists.";
                return this.View();
            }

            var userId = this.User.GetId();

            await this.foodsService.CreateFoodAsync(model, userId);

            this.TempData["Message"] = "Food created successfully.";

            return this.RedirectToAction("All", "Foods");
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            var foods = this.foodsService.GetAllFoods();
            var viewModel = new AllFoodsViewModel
            {
                Foods = foods,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyDiary()
        {
            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(AddFoodInputModel model)
        {
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(string name, AddFoodInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();

            await this.foodsService.AddFoodToDiaryAsync(model, userId, name);

            this.TempData["Message"] = "Food successfully added to food diary.";

            return this.RedirectToAction("All", "Foods");
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult ByName(string name)
        //{
        //    var viewModel = this.foodsService.GetFoodByName(name);

        //    return this.View(viewModel);
        //}
    }
}

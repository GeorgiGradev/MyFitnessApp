namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Models;

    public class FoodsController : AdministrationController
    {
        private readonly ApplicationDbContext db;

        public FoodsController(ApplicationDbContext context)
        {
            this.db = context;
        }

        // GET: Administration/Foods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.db.Foods.Include(f => f.AddedByUser);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Foods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var food = await this.db.Foods
                .Include(f => f.AddedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return this.NotFound();
            }

            return this.View(food);
        }

        // GET: Administration/Foods/Create
        public IActionResult Create()
        {
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id");
            return this.View();
        }

        // POST: Administration/Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ProteinIn100Grams,CarbohydratesIn100Grams,FatIn100Grams,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Food food)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Add(food);
                await this.db.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", food.AddedByUserId);
            return this.View(food);
        }

        // GET: Administration/Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var food = await this.db.Foods.FindAsync(id);
            if (food == null)
            {
                return this.NotFound();
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", food.AddedByUserId);
            return this.View(food);
        }

        // POST: Administration/Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ProteinIn100Grams,CarbohydratesIn100Grams,FatIn100Grams,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Food food)
        {
            if (id != food.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.db.Update(food);
                    await this.db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.FoodExists(food.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(this.Index));
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", food.AddedByUserId);
            return this.View(food);
        }

        // GET: Administration/Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var food = await this.db.Foods
                .Include(f => f.AddedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return this.NotFound();
            }

            return this.View(food);
        }

        // POST: Administration/Foods/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await this.db.Foods.FindAsync(id);
            this.db.Foods.Remove(food);
            await this.db.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool FoodExists(int id)
        {
            return this.db.Foods.Any(e => e.Id == id);
        }
    }
}

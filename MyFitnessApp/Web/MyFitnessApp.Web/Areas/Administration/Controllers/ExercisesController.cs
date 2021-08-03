namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Models;

    public class ExercisesController : AdministrationController
    {
        private readonly ApplicationDbContext db;

        public ExercisesController(ApplicationDbContext context)
        {
            this.db = context;
        }

        // GET: Administration/Exercises
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.db.Exercises.Include(e => e.AddedByUser).Include(e => e.Category).Include(e => e.Equipment);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.db.Exercises
                .Include(e => e.AddedByUser)
                .Include(e => e.Category)
                .Include(e => e.Equipment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercise == null)
            {
                return this.NotFound();
            }

            return this.View(exercise);
        }

        // GET: Administration/Exercises/Create
        public IActionResult Create()
        {
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id");
            this.ViewData["CategoryId"] = new SelectList(this.db.ExerciseCategories, "Id", "Name");
            this.ViewData["EquipmentId"] = new SelectList(this.db.ExerciseEquipments, "Id", "Name");
            return this.View();
        }

        // POST: Administration/Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Difficulty,CategoryId,EquipmentId,ImageUrl,VideoUrl,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Exercise exercise)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Add(exercise);
                await this.db.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.db.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
            return this.View(exercise);
        }

        // GET: Administration/Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return this.NotFound();
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.db.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
            return this.View(exercise);
        }

        // POST: Administration/Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Difficulty,CategoryId,EquipmentId,ImageUrl,VideoUrl,AddedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.db.Update(exercise);
                    await this.db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ExerciseExists(exercise.Id))
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
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.db.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
            return this.View(exercise);
        }

        // GET: Administration/Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.db.Exercises
                .Include(e => e.AddedByUser)
                .Include(e => e.Category)
                .Include(e => e.Equipment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercise == null)
            {
                return this.NotFound();
            }

            return this.View(exercise);
        }

        // POST: Administration/Exercises/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await this.db.Exercises.FindAsync(id);
            this.db.Exercises.Remove(exercise);
            await this.db.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ExerciseExists(int id)
        {
            return this.db.Exercises.Any(e => e.Id == id);
        }
    }
}

namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Models;

    [Area("Administration")]
    public class ExercisesController : Controller
    {
        private readonly ApplicationDbContext context;

        public ExercisesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Administration/Exercises
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Exercises.Include(e => e.AddedByUser).Include(e => e.Category).Include(e => e.Equipment);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.context.Exercises
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
            this.ViewData["AddedByUserId"] = new SelectList(this.context.Users, "Id", "Id");
            this.ViewData["CategoryId"] = new SelectList(this.context.ExerciseCategories, "Id", "Name");
            this.ViewData["EquipmentId"] = new SelectList(this.context.ExerciseEquipments, "Id", "Name");
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
                this.context.Add(exercise);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["AddedByUserId"] = new SelectList(this.context.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.context.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.context.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
            return this.View(exercise);
        }

        // GET: Administration/Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return this.NotFound();
            }

            this.ViewData["AddedByUserId"] = new SelectList(this.context.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.context.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.context.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
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
                    this.context.Update(exercise);
                    await this.context.SaveChangesAsync();
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

            this.ViewData["AddedByUserId"] = new SelectList(this.context.Users, "Id", "Id", exercise.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.context.ExerciseCategories, "Id", "Name", exercise.CategoryId);
            this.ViewData["EquipmentId"] = new SelectList(this.context.ExerciseEquipments, "Id", "Name", exercise.EquipmentId);
            return this.View(exercise);
        }

        // GET: Administration/Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exercise = await this.context.Exercises
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
            var exercise = await this.context.Exercises.FindAsync(id);
            this.context.Exercises.Remove(exercise);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ExerciseExists(int id)
        {
            return this.context.Exercises.Any(e => e.Id == id);
        }
    }
}

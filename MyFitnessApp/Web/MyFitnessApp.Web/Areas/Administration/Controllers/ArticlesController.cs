namespace MyFitnessApp.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyFitnessApp.Data;
    using MyFitnessApp.Data.Models;

    public class ArticlesController : AdministrationController
    {
        private readonly ApplicationDbContext db;

        public ArticlesController(ApplicationDbContext context)
        {
            this.db = context;
        }

        // GET: Administration/Articles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.db.Articles.Include(a => a.AddedByUser).Include(a => a.Category);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.db.Articles
                .Include(a => a.AddedByUser)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        // GET: Administration/Articles/Create
        public IActionResult Create()
        {
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id");
            this.ViewData["CategoryId"] = new SelectList(this.db.ArticleCategories, "Id", "Name");
            return this.View();
        }

        // POST: Administration/Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,ImageUrl,AddedByUserId,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Article article)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Add(article);
                await this.db.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", article.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ArticleCategories, "Id", "Name", article.CategoryId);
            return this.View(article);
        }

        // GET: Administration/Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.db.Articles.FindAsync(id);
            if (article == null)
            {
                return this.NotFound();
            }
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", article.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ArticleCategories, "Id", "Name", article.CategoryId);
            return this.View(article);
        }

        // POST: Administration/Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Content,ImageUrl,AddedByUserId,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Article article)
        {
            if (id != article.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.db.Update(article);
                    await this.db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ArticleExists(article.Id))
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
            this.ViewData["AddedByUserId"] = new SelectList(this.db.Users, "Id", "Id", article.AddedByUserId);
            this.ViewData["CategoryId"] = new SelectList(this.db.ArticleCategories, "Id", "Name", article.CategoryId);
            return this.View(article);
        }

        // GET: Administration/Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var article = await this.db.Articles
                .Include(a => a.AddedByUser)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        // POST: Administration/Articles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await this.db.Articles.FindAsync(id);
            this.db.Articles.Remove(article);
            await this.db.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ArticleExists(int id)
        {
            return this.db.Articles.Any(e => e.Id == id);
        }
    }
}

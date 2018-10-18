using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Capstone.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;
        

        public RecipesController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipes.Include(r => r.KeyIngredient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(r => r.KeyIngredient)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["RecipeMatch"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,Name,Category,Ingreients,RecipeMatch,Directions,Servings,NutritionalInfo")] Recipes recipes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeMatch"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", recipes.RecipeMatch);
            return View(recipes);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes.FindAsync(id);
            if (recipes == null)
            {
                return NotFound();
            }
            ViewData["RecipeMatch"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", recipes.RecipeMatch);
            return View(recipes);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,Name,Category,Ingreients,RecipeMatch,Directions,Servings,NutritionalInfo")] Recipes recipes)
        {
            if (id != recipes.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipesExists(recipes.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeMatch"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", recipes.RecipeMatch);
            return View(recipes);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(r => r.KeyIngredient)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipes = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }
        public IActionResult UploadImage(IFormFile pic, int RecipeID)
        {

            if (pic == null)
            {
                return View();
            }

            if (pic != null)
            {
                var fullPath = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));

                var fileName = pic.FileName;

                pic.CopyTo(new FileStream(fullPath, FileMode.Create));

                var recipe = _context.Recipes
                    .FirstOrDefault(m => m.RecipeID == RecipeID);

                recipe.Image = fileName;
                _context.Update(recipe);
                _context.SaveChangesAsync();

                ViewBag.ProfileImage = recipe.Image;

                ViewData["FileLocation"] = "/" + Path.GetFileName(pic.FileName);
            }
          
            return View();
        }
    }
}

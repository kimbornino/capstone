using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class LocalFoodRecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalFoodRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalFoodRecipes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RecipeMatch.Include(l => l.LocalFoods).Include(l => l.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LocalFoodRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoodRecipe = await _context.RecipeMatch
                .Include(l => l.LocalFoods)
                .Include(l => l.Recipe)
                .FirstOrDefaultAsync(m => m.LocalFoodRecipeID == id);
            if (localFoodRecipe == null)
            {
                return NotFound();
            }

            return View(localFoodRecipe);
        }

        // GET: LocalFoodRecipes/Create
        public IActionResult Create()
        {
            ViewData["LocalFoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID");
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            return View();
        }

        // POST: LocalFoodRecipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalFoodRecipeID,LocalFoodID,RecipeID")] LocalFoodRecipe localFoodRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localFoodRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalFoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", localFoodRecipe.LocalFoodID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", localFoodRecipe.RecipeID);
            return View(localFoodRecipe);
        }

        // GET: LocalFoodRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoodRecipe = await _context.RecipeMatch.FindAsync(id);
            if (localFoodRecipe == null)
            {
                return NotFound();
            }
            ViewData["LocalFoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", localFoodRecipe.LocalFoodID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", localFoodRecipe.RecipeID);
            return View(localFoodRecipe);
        }

        // POST: LocalFoodRecipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalFoodRecipeID,LocalFoodID,RecipeID")] LocalFoodRecipe localFoodRecipe)
        {
            if (id != localFoodRecipe.LocalFoodRecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localFoodRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalFoodRecipeExists(localFoodRecipe.LocalFoodRecipeID))
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
            ViewData["LocalFoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", localFoodRecipe.LocalFoodID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", localFoodRecipe.RecipeID);
            return View(localFoodRecipe);
        }

        // GET: LocalFoodRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoodRecipe = await _context.RecipeMatch
                .Include(l => l.LocalFoods)
                .Include(l => l.Recipe)
                .FirstOrDefaultAsync(m => m.LocalFoodRecipeID == id);
            if (localFoodRecipe == null)
            {
                return NotFound();
            }

            return View(localFoodRecipe);
        }

        // POST: LocalFoodRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localFoodRecipe = await _context.RecipeMatch.FindAsync(id);
            _context.RecipeMatch.Remove(localFoodRecipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalFoodRecipeExists(int id)
        {
            return _context.RecipeMatch.Any(e => e.LocalFoodRecipeID == id);
        }
    }
}

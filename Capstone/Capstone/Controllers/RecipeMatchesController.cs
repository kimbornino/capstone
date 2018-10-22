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
    public class RecipeMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeMatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipeMatches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RecipeMatch.Include(r => r.Food);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RecipeMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeMatch = await _context.RecipeMatch
                .Include(r => r.Food)
                .FirstOrDefaultAsync(m => m.LocalFoodRecipeID == id);
            if (recipeMatch == null)
            {
                return NotFound();
            }

            return View(recipeMatch);
        }

        // GET: RecipeMatches/Create
        public IActionResult Create()
        {
            ViewData["FoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID");
            return View();
        }

        // POST: RecipeMatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeMatchID,FoodID,FeaturedIngredient")] LocalFoodRecipe recipeMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", recipeMatch.FoodID);
            return View(recipeMatch);
        }

        // GET: RecipeMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeMatch = await _context.RecipeMatch.FindAsync(id);
            if (recipeMatch == null)
            {
                return NotFound();
            }
            ViewData["FoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", recipeMatch.FoodID);
            return View(recipeMatch);
        }

        // POST: RecipeMatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeMatchID,FoodID,FeaturedIngredient")] LocalFoodRecipe recipeMatch)
        {
            if (id != recipeMatch.LocalFoodRecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeMatchExists(recipeMatch.LocalFoodRecipeID))
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
            ViewData["FoodID"] = new SelectList(_context.LocalFoods, "FoodID", "FoodID", recipeMatch.FoodID);
            return View(recipeMatch);
        }

        // GET: RecipeMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeMatch = await _context.RecipeMatch
                .Include(r => r.Food)
                .FirstOrDefaultAsync(m => m.LocalFoodRecipeID == id);
            if (recipeMatch == null)
            {
                return NotFound();
            }

            return View(recipeMatch);
        }

        // POST: RecipeMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeMatch = await _context.RecipeMatch.FindAsync(id);
            _context.RecipeMatch.Remove(recipeMatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeMatchExists(int id)
        {
            return _context.RecipeMatch.Any(e => e.LocalFoodRecipeID == id);
        }
    }
}

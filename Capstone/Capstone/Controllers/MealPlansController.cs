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
    public class MealPlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MealPlans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MealPlans.Include(m => m.ApplicationUser).Include(m => m.Recipe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MealPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlans = await _context.MealPlans
                .Include(m => m.ApplicationUser)
                .Include(m => m.Recipe)
                .FirstOrDefaultAsync(m => m.MealPlanID == id);
            if (mealPlans == null)
            {
                return NotFound();
            }

            return View(mealPlans);
        }

        // GET: MealPlans/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["RecipeMatchID"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID");
            return View();
        }

        // POST: MealPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealPlanID,Date,DayOfWeek,RecipeMatchID,ApplicationUserId")] MealPlans mealPlans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealPlans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", mealPlans.ApplicationUserId);
            ViewData["RecipeMatchID"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", mealPlans.RecipeMatchID);
            return View(mealPlans);
        }

        // GET: MealPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlans = await _context.MealPlans.FindAsync(id);
            if (mealPlans == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", mealPlans.ApplicationUserId);
            ViewData["RecipeMatchID"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", mealPlans.RecipeMatchID);
            return View(mealPlans);
        }

        // POST: MealPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealPlanID,Date,DayOfWeek,RecipeMatchID,ApplicationUserId")] MealPlans mealPlans)
        {
            if (id != mealPlans.MealPlanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealPlans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealPlansExists(mealPlans.MealPlanID))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", mealPlans.ApplicationUserId);
            ViewData["RecipeMatchID"] = new SelectList(_context.Set<RecipeMatch>(), "RecipeMatchID", "RecipeMatchID", mealPlans.RecipeMatchID);
            return View(mealPlans);
        }

        // GET: MealPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlans = await _context.MealPlans
                .Include(m => m.ApplicationUser)
                .Include(m => m.Recipe)
                .FirstOrDefaultAsync(m => m.MealPlanID == id);
            if (mealPlans == null)
            {
                return NotFound();
            }

            return View(mealPlans);
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealPlans = await _context.MealPlans.FindAsync(id);
            _context.MealPlans.Remove(mealPlans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealPlansExists(int id)
        {
            return _context.MealPlans.Any(e => e.MealPlanID == id);
        }
    }
}

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
    public class LocalFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalFoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalFoods.ToListAsync());
        }

        // GET: LocalFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoods = await _context.LocalFoods
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (localFoods == null)
            {
                return NotFound();
            }

            return View(localFoods);
        }

        // GET: LocalFoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodID,FoodName,StartDate,EndDate,FoodImage,NutritionalInfo")] LocalFood localFoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localFoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localFoods);
        }

        // GET: LocalFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoods = await _context.LocalFoods.FindAsync(id);
            if (localFoods == null)
            {
                return NotFound();
            }
            return View(localFoods);
        }

        // POST: LocalFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,StartDate,EndDate,FoodImage,NutritionalInfo")] LocalFood localFoods)
        {
            if (id != localFoods.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localFoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalFoodsExists(localFoods.FoodID))
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
            return View(localFoods);
        }

        // GET: LocalFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFoods = await _context.LocalFoods
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (localFoods == null)
            {
                return NotFound();
            }

            return View(localFoods);
        }

        // POST: LocalFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localFoods = await _context.LocalFoods.FindAsync(id);
            _context.LocalFoods.Remove(localFoods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalFoodsExists(int id)
        {
            return _context.LocalFoods.Any(e => e.FoodID == id);
        }
    }
}

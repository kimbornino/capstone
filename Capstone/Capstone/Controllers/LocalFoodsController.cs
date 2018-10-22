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
        public IActionResult Index()
        {
            ////let user search by month
            //Search = "December";

            //if (Search != null) 
            //{
           
            //    return View();
            //}
            
            //else
            //{
                var SeasonalSelection = _context.LocalFoods.Where(m => m.EndDate > DateTime.Now && m.StartDate < DateTime.Now);
                return View(SeasonalSelection);
            //}
        }

        // GET: LocalFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFood = await _context.LocalFoods
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (localFood == null)
            {
                return NotFound();
            }

            return View(localFood);
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
        public async Task<IActionResult> Create([Bind("FoodID,FoodName,StartDate,EndDate,FoodImage,NutritionalInfo")] LocalFood localFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localFood);
        }

        // GET: LocalFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFood = await _context.LocalFoods.FindAsync(id);
            if (localFood == null)
            {
                return NotFound();
            }
            return View(localFood);
        }

        // POST: LocalFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodID,FoodName,StartDate,EndDate,FoodImage,NutritionalInfo")] LocalFood localFood)
        {
            if (id != localFood.FoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalFoodExists(localFood.FoodID))
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
            return View(localFood);
        }

        // GET: LocalFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localFood = await _context.LocalFoods
                .FirstOrDefaultAsync(m => m.FoodID == id);
            if (localFood == null)
            {
                return NotFound();
            }

            return View(localFood);
        }

        // POST: LocalFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localFood = await _context.LocalFoods.FindAsync(id);
            _context.LocalFoods.Remove(localFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult SearchByMonth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchByMonth(string month)
        {
            var selectedIds = Request.Form["months"];
            if (month != "00")
            {

                //var FoodByMonth = _context.LocalFoods.Where(m => m.StartDate.Month == month || m.EndDate.Month == month);


            return View();
            }
            //else
            //{
            //    return View("Index");

            //}
            return View();
        }


        private bool LocalFoodExists(int id)
        {
            return _context.LocalFoods.Any(e => e.FoodID == id);
        }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarMan.Data;
using CarMan.Models;

namespace CarMan.Controllers
{
    public class CarmenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carman = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carman == null)
            {
                return NotFound();
            }

            return View(carman);
        }

        // GET Create
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Manufacturer,model,colour,enginesize,CreatedDateTime")] Carman carman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carman);
        }

        // GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carman = await _context.Cars.FindAsync(id);
            if (carman == null)
            {
                return NotFound();
            }
            return View(carman);
        }

        // POST Edit
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacturer,model,colour,enginesize,CreatedDateTime")] Carman carman)
        {
            if (id != carman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarmanExists(carman.Id))
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
            return View(carman);
        }

        // GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carman = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carman == null)
            {
                return NotFound();
            }

            return View(carman);
        }

        // POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carman = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(carman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarmanExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}

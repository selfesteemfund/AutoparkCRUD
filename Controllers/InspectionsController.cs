﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using autopark.Data;
using autopark.Models;

namespace autopark.Controllers
{
    public class InspectionsController : Controller
    {
        private readonly AppDbContext _context;

        public InspectionsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Inspections.Include(c => c.Car);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(c => c.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        public IActionResult Create()
        {
            ViewBag.InspCarId = new SelectList(_context.Cars, "Id", "InspCarId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,InspNote,InspDate")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "InspCarId");
            return View(inspection);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "InspCarId");
            return View(inspection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,InspNote,InspDate")] Inspection inspection)
        {
            if (id != inspection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectionExists(inspection.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "InspCarId");
            return View(inspection);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .Include(i => i.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        // POST: Inspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inspection = await _context.Inspections.FindAsync(id);
            _context.Inspections.Remove(inspection);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cars", new { id = inspection.CarId });
        }

        private bool InspectionExists(int id)
        {
            return _context.Inspections.Any(e => e.Id == id);
        }

        public async Task<IActionResult> IndexDelete(int? id)
        {
            var inspection = await _context.Inspections.FindAsync(id);
            _context.Inspections.Remove(inspection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInspectionFromCar(int id, Inspection inspection)
        {

                if (ModelState.IsValid)
                {
                    _context.Inspections.Add(new Inspection()
                    {
                        CarId = id,
                        InspNote = inspection.InspNote,
                        InspDate = inspection.InspDate
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Cars", new { id });
                }

            return View(inspection);

        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveCenter.Data;
using ReserveCenter.Models;

namespace ReserveCenter.Controllers
{
    public class LocationSpacesController : Controller
    {
        private readonly ReserveCenterContext _context;

        public LocationSpacesController(ReserveCenterContext context)
        {
            _context = context;
        }

        // GET: LocationSpaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationSpaces.ToListAsync());
        }

        // GET: LocationSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSpaces = await _context.LocationSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationSpaces == null)
            {
                return NotFound();
            }

            return View(locationSpaces);
        }

        // GET: LocationSpaces/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MaxOccupancy,ReserveValue")] LocationSpaces locationSpaces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationSpaces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationSpaces);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSpaces = await _context.LocationSpaces.FindAsync(id);
            if (locationSpaces == null)
            {
                return NotFound();
            }
            return View(locationSpaces);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MaxOccupancy,ReserveValue")] LocationSpaces locationSpaces)
        {
            if (id != locationSpaces.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationSpaces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationSpacesExists(locationSpaces.Id))
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
            return View(locationSpaces);
        }

        // GET: LocationSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSpaces = await _context.LocationSpaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationSpaces == null)
            {
                return NotFound();
            }

            return View(locationSpaces);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationSpaces = await _context.LocationSpaces.FindAsync(id);
            if (locationSpaces != null)
            {
                _context.LocationSpaces.Remove(locationSpaces);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationSpacesExists(int id)
        {
            return _context.LocationSpaces.Any(e => e.Id == id);
        }
    }
}

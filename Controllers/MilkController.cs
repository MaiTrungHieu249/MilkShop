using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilkShop.Data;
using MilkShop.Models;

namespace MilkShop.Controllers
{
    public class MilkController : Controller
    {
        private readonly MilkShopContext _context;

        public MilkController(MilkShopContext context)
        {
            _context = context;
        }

        // GET: Milk
        public async Task<IActionResult> Index(string milkGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Milk
                                            orderby b.Genre
                                            select b.Genre;
            var milks = from b in _context.Milk
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                milks = milks.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(milkGenre))
            {
                milks = milks.Where(x => x.Genre == milkGenre);
            }
            var milkGenreVM = new MilkGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Milks = await milks.ToListAsync()
            };
            return View(milkGenreVM);
        }


        // GET: Milk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milk == null)
            {
                return NotFound();
            }

            return View(milk);
        }

        // GET: Milk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Milk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Milk milk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(milk);
        }

        // GET: Milk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk.FindAsync(id);
            if (milk == null)
            {
                return NotFound();
            }
            return View(milk);
        }

        // POST: Milk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Milk milk)
        {
            if (id != milk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilkExists(milk.Id))
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
            return View(milk);
        }

        // GET: Milk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milk = await _context.Milk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milk == null)
            {
                return NotFound();
            }

            return View(milk);
        }

        // POST: Milk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var milk = await _context.Milk.FindAsync(id);
            _context.Milk.Remove(milk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilkExists(int id)
        {
            return _context.Milk.Any(e => e.Id == id);
        }
    }
}

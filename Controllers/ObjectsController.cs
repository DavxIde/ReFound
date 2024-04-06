using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oggetti_Usati.Models;

namespace Oggetti_Usati.Controllers
{
    public class ObjectsController : Controller
    {
        private readonly dbcontext _context;

        [HttpPost]
        public ActionResult EffettuaAcquisto()
        {
            // Assuming the logic for completing the purchase is implemented here
            // For demonstration purposes, let's assume the purchase is successful
            var data = new { success = true };
            return Json(data);
        }

        public ObjectsController(dbcontext context)
        {
            _context = context;
        }
    
    public IActionResult TransferToCart(string selectedIds)
    {
        if (!string.IsNullOrEmpty(selectedIds))
        {
            // Split the string of IDs into an array of integers
            var idsArray = selectedIds.Split(',').Select(int.Parse).ToList();

            // Fetch items corresponding to the IDs from your database or wherever they are stored
            var itemsInCart = _context.Oggetti.Where(item => idsArray.Contains(item.Id)).ToList();
        
            return View("Cart", itemsInCart);
        
        }
    
        return RedirectToAction("EmptyCart");
    }


        // GET: Objects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oggetti.ToListAsync());
        }

        // GET: Objects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oggetto = await _context.Oggetti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oggetto == null)
            {
                return NotFound();
            }

            return View(oggetto);
        }

        // GET: Objects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Quantity")] Oggetto oggetto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oggetto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oggetto);
        }

        // GET: Objects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oggetto = await _context.Oggetti.FindAsync(id);
            if (oggetto == null)
            {
                return NotFound();
            }
            return View(oggetto);
        }

        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Quantity")] Oggetto oggetto)
        {
            if (id != oggetto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oggetto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OggettoExists(oggetto.Id))
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
            return View(oggetto);
        }

        // GET: Objects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oggetto = await _context.Oggetti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oggetto == null)
            {
                return NotFound();
            }

            return View(oggetto);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oggetto = await _context.Oggetti.FindAsync(id);
            if (oggetto != null)
            {
                _context.Oggetti.Remove(oggetto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OggettoExists(int id)
        {
            return _context.Oggetti.Any(e => e.Id == id);
        }
    }
}

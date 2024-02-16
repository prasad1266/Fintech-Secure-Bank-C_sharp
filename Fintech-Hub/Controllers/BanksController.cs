﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using Fintech_Hub.Data;
using Fintech_Hub.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fintech_Hub.Controllers
{

    [Authorize(Roles = "Admin")]
    public class BanksController : Controller
    {
        private readonly MyDbContext  _context;

        public BanksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Banks
        public async Task<IActionResult> Index()
        {

            var myDbContext = _context.Banks.Include(b => b.User);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Banks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Banks == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // GET: Banks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Address,UserId")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", bank.UserId);
            return View(bank);
        }


        // GET: Banks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banks == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks.FindAsync(id);
            if (bank == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", bank.UserId);
            return View(bank);
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Address,UserId")] Bank bank)
        {
            if (id != bank.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(bank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankExists(bank.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", bank.UserId);
            return View(bank);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Banks == null)
            {
                return NotFound();
            }

            var bank = await _context.Banks
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Banks == null)
            {
                return Problem("Entity set 'MyDbContext.Banks'  is null.");
            }
            var bank = await _context.Banks.FindAsync(id);
            if (bank != null)
            {
                _context.Banks.Remove(bank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankExists(int id)
        {
          return (_context.Banks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

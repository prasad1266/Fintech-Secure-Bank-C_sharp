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
    [Authorize(Roles = "Bank")]
    public class BankAccountsController : Controller
    {
        private readonly MyDbContext _context;

        public BankAccountsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: BankAccounts
        public async Task<IActionResult> Index()
        {
              return _context.BankAccounts != null ? 
                          View(await _context.BankAccounts.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.BankAccounts'  is null.");
        }

        // GET: BankAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // GET: BankAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Balance,CreationDate,IfscCode,Number,Status,Type")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccount);
        }

        // GET: BankAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return View(bankAccount);
        }

        // POST: BankAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Balance,CreationDate,IfscCode,Number,Status,Type")] BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountExists(bankAccount.Id))
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
            return View(bankAccount);
        }

        // GET: BankAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BankAccounts == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return View(bankAccount);
        }

        // POST: BankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BankAccounts == null)
            {
                return Problem("Entity set 'MyDbContext.BankAccounts'  is null.");
            }
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _context.BankAccounts.Remove(bankAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankAccountExists(int id)
        {
          return (_context.BankAccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

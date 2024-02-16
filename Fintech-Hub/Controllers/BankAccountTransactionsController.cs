using System;
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
    [Authorize(Roles = "Customer")]
    public class BankAccountTransactionsController : Controller
    {
        private readonly MyDbContext _context;

        public BankAccountTransactionsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: BankAccountTransactions
        public async Task<IActionResult> Index()
        {
              return _context.BankAccountTransactions != null ? 
                          View(await _context.BankAccountTransactions.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.BankAccountTransactions'  is null.");
        }

        // GET: BankAccountTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BankAccountTransactions == null)
            {
                return NotFound();
            }

            var bankAccountTransaction = await _context.BankAccountTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccountTransaction == null)
            {
                return NotFound();
            }

            return View(bankAccountTransaction);
        }

        // GET: BankAccountTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankAccountTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Narration,TransactionId,TransactionTime,Type,DestinationBankAccountId")] BankAccountTransaction bankAccountTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankAccountTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankAccountTransaction);
        }

        // GET: BankAccountTransactions/Edit/5
        /*  public async Task<IActionResult> Edit(int? id)
          {
              if (id == null || _context.BankAccountTransactions == null)
              {
                  return NotFound();
              }

              var bankAccountTransaction = await _context.BankAccountTransactions.FindAsync(id);
              if (bankAccountTransaction == null)
              {
                  return NotFound();
              }
              return View(bankAccountTransaction);
          }

          // POST: BankAccountTransactions/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Narration,TransactionId,TransactionTime,Type,DestinationBankAccountId")] BankAccountTransaction bankAccountTransaction)
          {
              if (id != bankAccountTransaction.Id)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(bankAccountTransaction);
                      await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!BankAccountTransactionExists(bankAccountTransaction.Id))
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
              return View(bankAccountTransaction);
          }
        

        // GET: BankAccountTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BankAccountTransactions == null)
            {
                return NotFound();
            }

            var bankAccountTransaction = await _context.BankAccountTransactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankAccountTransaction == null)
            {
                return NotFound();
            }

            return View(bankAccountTransaction);
        }

        // POST: BankAccountTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BankAccountTransactions == null)
            {
                return Problem("Entity set 'MyDbContext.BankAccountTransactions'  is null.");
            }
            var bankAccountTransaction = await _context.BankAccountTransactions.FindAsync(id);
            if (bankAccountTransaction != null)
            {
                _context.BankAccountTransactions.Remove(bankAccountTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool BankAccountTransactionExists(int id)
        {
          return (_context.BankAccountTransactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

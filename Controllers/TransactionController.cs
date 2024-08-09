using BankTranctions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankTranctions.Models;

namespace BankTranctions.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankTranctionsDbContext _context;
        public TransactionController(BankTranctionsDbContext context)
        {
            _context = context;
        }
        // GET: TranctionController
        public async Task<ActionResult> Index()
        {
             
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: TranctionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TranctionController/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Transaction());
            else
                return View(_context.Transactions.Find(id));
        }

        // POST: TranctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.TransactionId == 0)
                {
                    transaction.Date = DateTime.Now;
                    _context.Add(transaction);
                }
                else
                    _context.Update(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

       
        // GET: TranctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TranctionController/Delete/5
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var transaction =await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}

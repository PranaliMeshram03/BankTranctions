using BankTranctions.Data;
using BankTranctions.Models;
using BankTransaction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankTranctions.Controllers
{
    public class UserController : Controller
    {
        private readonly BankTranctionsDbContext _context;

        public UserController(BankTranctionsDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var data = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (data != null)
            {

                return RedirectToAction("AddOrEdit", "Transaction");
            }
            else
            {
                ViewBag.Message = "Login failed....";
                return RedirectToAction(nameof(Register));

            }
        }
        public IActionResult Register()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value = "Male" ,Text = "Male"},
                new SelectListItem {Value = "FeMale" ,Text = "FeMale"}

            };
            ViewBag.Gender = Gender;

            List<State> states = _context.States.ToList();
            List<Country> countries = _context.Countries.ToList();
            ViewBag.States = new SelectList(states, "Id", "StateName");
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully!!....";
                return RedirectToAction("Login", "User");
            }

            List<State> states = _context.States.ToList();
            List<Country> countries = _context.Countries.ToList();
            ViewBag.States = new SelectList(states, "Id", "StateName");
            ViewBag.Countries = new SelectList(countries, "Id", "Name");
            return View();
        }
    }
}

        
    


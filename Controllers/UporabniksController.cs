using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class UporabniksController : Controller
    {
        private readonly OpravilaContext _context;

        public UporabniksController(OpravilaContext context)
        {
            _context = context;
        }

        // GET: Uporabniks/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Uporabniks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,Username,Password")] Uporabnik uporabnik)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Uporabnik.Where(s => s.Username == uporabnik.Username);
                if (admin.Any())
                {
                    if (admin.Where(s => s.Password == uporabnik.Password).Any())
                    {

                        return Redirect("/Opravila/Index");
                    }
                    else
                    {
                        return View(uporabnik);
                    }
                }
                else
                {
                    return View(uporabnik);
                }
            }
            return View(uporabnik);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroProject.Data;
using SuperHeroProject.Models;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperHero
        public ActionResult Index()
        {
            var SuperHeros = _context.superHeroes;
            return View(SuperHeros);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHero = _context.superHeroes.Find(id);
            return View(superHero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")] SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    _context.superHeroes.Add(superHero);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.superHeroes.Find(id));
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                SuperHero editedHero = _context.superHeroes.Find(id);
                editedHero.Name = superHero.Name;
                editedHero.AlterEgo = superHero.AlterEgo;
                editedHero.PrimaryAbility = superHero.PrimaryAbility;
                editedHero.SecondaryAbility = superHero.SecondaryAbility;
                editedHero.Catchphrase = superHero.Catchphrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
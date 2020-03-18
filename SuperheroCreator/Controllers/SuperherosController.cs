using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroCreator.Data;
using SuperheroCreator.Models;

namespace SuperheroCreator.Controllers
{
    public class SuperherosController : Controller
    {
        public ApplicationDbContext _context;
        public SuperherosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superheros
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                //update Superheroes table with 
                var superheroInDB = _context.Superheroes.Where(v => v.Id == id).SingleOrDefault();

                //option 1 -- maybe? need to test
                //superheroInDB = superhero;

                //option 2 -- setting individual props (getting better)
                //superheroInDB.AlterEgo = superhero.AlterEgo;

                //option 3 -- best option?
                _context.Superheroes.Update(superhero);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
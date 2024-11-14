using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filmy.Models;

namespace Filmy.Controllers
{
    public class FilmController : Controller
    {
        private static List<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "Opis1", Price = 1},
            new Film(){Id = 2, Name = "Film2", Description = "Opis2", Price = 2},
            new Film(){Id = 3, Name = "Film3", Description = "Opis3", Price = 3}
        };

        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film edit = films.FirstOrDefault(x => x.Id == id);

            edit.Name = film.Name;
            edit.Description = film.Description;
            edit.Price = film.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            films.Remove(film);
            return RedirectToAction(nameof(Index));
        }
    }
}

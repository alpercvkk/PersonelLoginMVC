using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelLoginMCVPoject.Data;
using PersonelLoginMCVPoject.Data.Entities;
using PersonelLoginMCVPoject.Models;

namespace PersonelLoginMCVPoject.Controllers
{
    public class PersonelListeleController : Controller
    {
        [Authorize (AuthenticationSchemes ="FB1907")]
       [HttpGet]
        public IActionResult Index()
        {

            var db = new PersonelListeleDbContext();
            var personel = db.Personeller.ToList();
            return View(personel);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var db = new PersonelListeleDbContext();

            var aa = db.Personeller.ToList();
            var list = new List<Personel>();

            foreach (var item in aa)
            {
                var sonList = list.Where(x => x.Il == item.Il).FirstOrDefault();
                if (sonList == null)
                {
                    list.Add(item);
                }

            }
            ViewBag.Adresler = list;
            

            return View();
            
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Personel personel)

        {

            var db = new PersonelListeleDbContext();
            var aa = db.Personeller.ToList();
            var list = new List<Personel>();

            foreach (var item in aa)
            {
                var sonList = list.Where(x => x.Il == item.Il  ).FirstOrDefault();
                if (sonList == null)
                {
                    list.Add(item);
                }
            }
            ViewBag.Adresler = list;
            db.Personeller.Add(personel);
            db.SaveChanges();

            ModelState.Clear();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var db = new PersonelListeleDbContext();
            var clist = db.Personeller.Find(id);

            return View(clist); 
       
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete( Personel personel)
        {

            var db = new PersonelListeleDbContext();

            db.Personeller.Remove(personel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var db = new PersonelListeleDbContext();
            var clist = db.Personeller.Find(id);

            var aa = db.Personeller.ToList();
            var list = new List<Personel>();

            foreach (var item in aa)
            {
                var sonList = list.Where(x => x.Il == item.Il).FirstOrDefault();
                if (sonList == null)
                {
                    list.Add(item);
                }

            }
            ViewBag.Adresler = list;

            return View(clist);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(Personel personel)
        {
            var db = new PersonelListeleDbContext();

            db.Personeller.Update(personel);
            db.SaveChanges();

            return RedirectToAction("Index", "PersonelListele");
        }


    }
}

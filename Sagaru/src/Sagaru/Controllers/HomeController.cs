using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Sagaru.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sagaru.Controllers
{
    public class HomeController : Controller
    {
        private SagaruDbContext db = new SagaruDbContext();
        public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var thisProject = db.Projects.FirstOrDefault(projects => projects.ProjectId == id);
            ViewBag.Shape = db.Shapes.ToList();
            return View(thisProject);
        }

        public IActionResult Delete(int id)
        {
            var thisProject = db.Projects.FirstOrDefault(projects => projects.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProject = db.Projects.FirstOrDefault(projects => projects.ProjectId == id);
            db.Projects.Remove(thisProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var thisProject = db.Projects.FirstOrDefault(projects => projects.ProjectId == id);
            return View(thisProject);
        }

        [HttpPost]
        public IActionResult Update(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

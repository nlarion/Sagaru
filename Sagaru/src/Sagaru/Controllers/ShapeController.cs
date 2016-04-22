using Sagaru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

namespace Sagaru.Controllers
{
    public class ShapeController : Controller
    {
        private SagaruDbContext db = new SagaruDbContext();
        public IActionResult Index()
        {
            ViewBag.Project = db.Projects.ToList();
            return View(db.Shapes.ToList());
        }
        public IActionResult Details(int id)
        {
            ViewBag.Project = db.Projects.ToList();
            var people = db.Shapes.FirstOrDefault(shape => shape.ShapeId == id);
            return View(people);
        }
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shape shape)
        {
            db.Shapes.Add(shape);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var thisShape = db.Shapes.FirstOrDefault(shape => shape.ShapeId == id);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name");
            return View(thisShape);
        }
        [HttpPost]
        public ActionResult Update(Shape shape)
        {
            db.Entry(shape).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisShape = db.Shapes.FirstOrDefault(shape => shape.ShapeId == id);
            return View(thisShape);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisShape = db.Shapes.FirstOrDefault(shape => shape.ShapeId == id);
            db.Shapes.Remove(thisShape);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

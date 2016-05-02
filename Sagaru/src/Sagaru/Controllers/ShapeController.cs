using Sagaru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Sagaru.Controllers
{
    public class ShapeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShapeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Project = await _db.Projects.ToListAsync();
            return View(await _db.Shapes.ToListAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Project = await _db.Projects.ToListAsync();
            var thisShape = await _db.Shapes.FirstOrDefaultAsync(shape => shape.ShapeId == id);
            return View(thisShape);
        }
        public IActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Shape shape)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            shape.User = currentUser;
            _db.Shapes.Add(shape);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var thisShape = await _db.Shapes.FirstOrDefaultAsync(shape => shape.ShapeId == id);
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Name");
            return View(thisShape);
        }
        [HttpPost]
        public async Task<IActionResult >Update(Shape shape)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            shape.User = currentUser;
            _db.Entry(shape).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var thisShape = await _db.Shapes.FirstOrDefaultAsync(shape => shape.ShapeId == id);
            ViewBag.ProjectId = new SelectList(_db.Projects, "ProjectId", "Name");
            return View(thisShape);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thisShape = await _db.Shapes.FirstOrDefaultAsync(shape => shape.ShapeId == id);
            _db.Shapes.Remove(thisShape);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

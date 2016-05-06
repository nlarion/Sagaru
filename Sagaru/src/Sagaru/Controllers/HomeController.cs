using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Sagaru.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Sagaru.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Projects.Where(x => x.User.Id == currentUser.Id));
        }
        //ajax calls
        public IActionResult AjaxCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AjaxCreate(Project project)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            project.User = currentUser;
            _db.Projects.Add(project);
            _db.SaveChanges();
            return Json(project);
            //return RedirectToAction("Index", "Account");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            project.User = currentUser;
            _db.Projects.Add(project);
            _db.SaveChanges();
            return RedirectToAction("Index","Account");
        }
        public async Task<IActionResult> Detail(int id)
        {
            var thisProject = await _db.Projects.FirstOrDefaultAsync(projects => projects.ProjectId == id);
            ViewBag.Shape = await _db.Shapes.ToListAsync();
            return View(thisProject);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var thisProject = await _db.Projects.FirstOrDefaultAsync(projects => projects.ProjectId == id);
            return View(thisProject);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thisProject = await _db.Projects.FirstOrDefaultAsync(projects => projects.ProjectId == id);
            _db.Projects.Remove(thisProject);
            _db.SaveChanges();
            return RedirectToAction("Index","Account");
        }
        public async Task<IActionResult> Update(int id)
        {
            var thisProject = await _db.Projects.FirstOrDefaultAsync(projects => projects.ProjectId == id);
            return View(thisProject);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Project project)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            project.User = currentUser;
            _db.Entry(project).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index","Account");
        }
    }
}

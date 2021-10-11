using JMCRM.Data;
using JMCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Controllers
{
    public class StorylineController : Controller
    {
        private readonly JMCRMDbContext _db;

        public StorylineController(JMCRMDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string projectId)
        {
            IEnumerable<Project> allProjects = from projectDB in _db.Project
                                               select projectDB;
            Project currentProject = allProjects.Where(p => p.ProjectId == projectId).First();
            _db.Project.Include(stories => stories.Storylines).ToList();

            return View(currentProject);
        }

        // GET - CREATE
        public IActionResult Create(string projectId)
        {
            IEnumerable<Project> allProjects = from projectDB in _db.Project 
                                               select projectDB;

            return View(new Storyline(projectId));
        }

        // POST - CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(Storyline storyline)
        {
            if(ModelState.IsValid)
            {
                Project project = _db.Project.Find(storyline.ProjectId);
                project.Storylines.Add(storyline); 
                _db.SaveChanges();
                return RedirectToAction("Index", new { projectId = storyline.ProjectId });
            }
            return View("Index", new { projectId = storyline.ProjectId });
        }
    }
}

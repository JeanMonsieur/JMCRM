using JMCRM.Data;
using JMCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly JMCRMDbContext _db;

        public ProjectController(ILogger<ProjectController> logger, JMCRMDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index(string searchString)
        {
            IEnumerable<Project> allSelectedProjects = from projectsDB in _db.Project 
                                                       select projectsDB;
            if (!String.IsNullOrEmpty(searchString))
            {

                allSelectedProjects = allSelectedProjects.Where(
                    projectsDB => projectsDB.ProjectId.Contains(searchString));
            }

            return View(allSelectedProjects);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                this._db.Project.Add(project);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // EDIT - GET
        public IActionResult Edit(string ProjectId)
        {
            if(ProjectId != null)
            {
                IEnumerable<Project> dbProjects = from projects in _db.Project
                                                  select projects;
                Project projectToEdit = dbProjects.Where(projects => projects.ProjectId == ProjectId).First();

                return View(projectToEdit);
            }
            return View("Index");
        }

        // EDIT - POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                this._db.Project.Update(project);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

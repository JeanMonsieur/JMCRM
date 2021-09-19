using JMCRM.Data;
using JMCRM.Models;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Storyline> allStorylines = from storylinesDB in _db.Storyline
                                                   select storylinesDB;

            allStorylines = allStorylines.Where(storylinesDB => storylinesDB.ProjectId == projectId);

            return View(allStorylines);
        }

        // GET - CREATE
        public IActionResult Create(string projectId)
        {
            return View(projectId);
        }

        // POST - CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(string projectId)
        {
            return View(projectId);
        }
    }
}

using JMCRM.Data;
using JMCRM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMCRM.Controllers
{
    public class ContactController : Controller
    {
        private readonly JMCRMDbContext _db;

        public ContactController(JMCRMDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Contact> Contacts = _db.Contact;
            return View(Contacts);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                this._db.Contact.Add(contact);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}

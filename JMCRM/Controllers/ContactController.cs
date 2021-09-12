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

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
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

        // EDIT - GET
        public IActionResult Edit(int? ContactId)
        {
            if(ContactId == null)
            {
                return NotFound();
            }
            Contact contact = _db.Contact.Find(ContactId);

            if(contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // EDIT - POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                this._db.Contact.Update(contact);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // DELETE - GET
        public IActionResult Delete(int? ContactId)
        {
            if(ContactId == null)
            {
                return NotFound();
            }
            Contact contact = _db.Contact.Find(ContactId);
            if(contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // DELETE - POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? contactId)
        {
            Contact contact = this._db.Contact.Find(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            this._db.Contact.Remove(contact);
            this._db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

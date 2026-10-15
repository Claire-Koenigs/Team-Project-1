using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Team_Project_1.Models;

namespace Team_Project_1.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }
        public ContactController(ContactContext ctx) => context = ctx;

        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(context.Categories.OrderBy(c => c.Name).ToList(), "CategoryId", "Name");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            LoadCategories();
            return View("AddEdit", new Contact());
        }
        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.DateAdded = DateTime.Now;
                context.Contacts.Add(contact);
                context.SaveChanges();
                return RedirectToAction("Details", new { id = contact.ContactId, slug = contact.Slug });
            }
            ViewBag.Action = "Add";
            LoadCategories();
            return View("AddEdit", contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Action = "Edit";
                LoadCategories();
                return View("AddEdit", contact);
            }
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var existingContact = context.Contacts.Find(contact.ContactId);
                if (existingContact == null)
                {
                    return NotFound();
                }
                else
                {
                    existingContact.FirstName = contact.FirstName;
                    existingContact.LastName = contact.LastName;
                    existingContact.Phone = contact.Phone;
                    existingContact.Email = contact.Email;
                    existingContact.Organization = contact.Organization;
                    existingContact.CategoryId = contact.CategoryId;
                    context.SaveChanges();

                    return RedirectToAction("Details", new { id = existingContact.ContactId, slug = existingContact.Slug });
                }
            }
            ViewBag.Action = "Edit";
            LoadCategories();
            return View("AddEdit", contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return View(contact);
            }
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int contactId)
        {
            var contact = context.Contacts.Find(contactId);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Details(int id, string? slug)
        {
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return View(contact);

            }
        }
    }
}

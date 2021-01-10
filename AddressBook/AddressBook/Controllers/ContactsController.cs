using AddressBook.Domain.Models;
using AddressBook.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
	public class ContactsController : Controller
	{
		private IContactsRepository _contactsRepository;

		public ContactsController(IContactsRepository contactsRepository)
		{
			_contactsRepository = contactsRepository;
		}
		// GET: ContactsController
		public ViewResult Index()
		{
			ContactsListViewModel contactsListViewModel = new ContactsListViewModel()
			{
				Contacts = _contactsRepository.GetAllContacts(),
				PageTitle = "All Contacts In The System"
			};
			return View(contactsListViewModel);
		}

		[Route("[controller]/List/{userName}")]
		public ViewResult List(string userName)
		{
			ContactsListViewModel contactsListViewModel = new ContactsListViewModel()
			{
				Contacts = _contactsRepository.GetContacts(userName),
				PageTitle = $"Contacts List for the user {userName}"
			};
			return View(contactsListViewModel);

		}

		// GET: ContactsController/Details/5
		public ViewResult Details(int id)
		{
			ContactDetailsViewModel contactDetailsViewModel = new ContactDetailsViewModel()
			{
				Contact = _contactsRepository.GetContact(id),
				PageTitle = "Contact Details"
			};
			return View(contactDetailsViewModel);
		}

		// GET: ContactsController/Create
		[HttpGet]
		public ViewResult Create()
		{
			return View();
		}
		[HttpPost]
		public RedirectToActionResult Create(Contact contact)
		{
			var newContact = _contactsRepository.Add(contact);
			return RedirectToAction("details", new { id = newContact.ContactId });
		}

		// POST: ContactsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ContactsController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ContactsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ContactsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ContactsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

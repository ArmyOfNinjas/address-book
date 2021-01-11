using AddressBook.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Domain.Models
{
	public class ContactsRepository : IContactsRepository
	{
		private List<Contact> _contacts;
		private AddressBookContext _dbContext { get; set; }

		public ContactsRepository(AddressBookContext dbContext)
		{
			_dbContext = dbContext;
			_contacts = new List<Contact>()
			{
				new Contact() {ContactId=1, FirstName = "Leo2", LastName="Malanowski2", User = new User(){UserName = "LeonidM", FirstName="Leonid" } },
				new Contact() {ContactId=2, FirstName = "Leo3", LastName="Malanowski3", User = new User(){UserName = "LeonidM" ,FirstName="Leonid"} }
			};
		}

		public Contact GetContact(int id)
		{
			return _dbContext.Contacts.FirstOrDefault(x => x.ContactId == id);
		}

		public IEnumerable<Contact> GetContacts(string userName)
		{
			return _dbContext.Contacts.Where(x => x.User.UserName.Equals(userName));
		}

		public IEnumerable<Contact> GetAllContacts()
		{
			return _dbContext.Contacts;
		}

		public Contact Add(Contact contact)
		{
			_dbContext.Contacts.Add(contact);
			_dbContext.SaveChanges();

			return contact;
		}

		public Contact Update(Contact contactChanged)
		{
			var contact = _dbContext.Contacts.Attach(contactChanged);
			contact.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_dbContext.SaveChanges();

			return contactChanged;
		}

		public Contact Delete(int id)
		{
			Contact contact = _dbContext.Contacts.FirstOrDefault(x => x.ContactId == id);
			if (contact != null)
			{
				_dbContext.Contacts.Remove(contact);
				_dbContext.SaveChanges();
			}
			return contact;
		}
	}
}

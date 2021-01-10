using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Domain.Models
{
	public class ContactsRepository : IContactsRepository
	{
		private List<Contact> _contacts;

		public ContactsRepository()
		{
			_contacts = new List<Contact>()
			{
				new Contact() {ContactId=1, FirstName = "Leo2", LastName="Malanowski2", User = new User(){UserName = "LeonidM", FirstName="Leonid" } },
				new Contact() {ContactId=2, FirstName = "Leo3", LastName="Malanowski3", User = new User(){UserName = "LeonidM" ,FirstName="Leonid"} }
			};
		}

		public Contact GetContact(int id)
		{
			return _contacts.FirstOrDefault(x => x.ContactId == id);
		}

		public IEnumerable<Contact> GetContacts(string userName)
		{
			return _contacts.Where(x => x.User.UserName.Equals(userName));
		}

		public IEnumerable<Contact> GetAllContacts()
		{
			return _contacts;
		}

		public Contact Add(Contact contact)
		{
			contact.ContactId = _contacts.Max(x => x.ContactId) + 1;
			_contacts.Add(contact);
			return contact;
		}
	}
}

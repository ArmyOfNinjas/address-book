using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Models
{
	public interface IContactsRepository
	{
		Contact GetContact(int id);
		IEnumerable<Contact> GetContacts(string userName);
		IEnumerable<Contact> GetAllContacts();
		Contact Add(Contact contact);
	}
}

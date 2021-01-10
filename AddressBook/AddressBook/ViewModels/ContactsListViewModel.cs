using AddressBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.ViewModels
{
	public class ContactsListViewModel
	{
		public string PageTitle { get; set; }
		
		public IEnumerable<Contact> Contacts { get; set; }
	}
}

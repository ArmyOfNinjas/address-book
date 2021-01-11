using AddressBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.ViewModels
{
	public class ContactEditViewModel
	{
		public string PageTitle { get; set; }
		public Contact Contact { get; set; }
	}
}

using AddressBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.ViewModels
{
	public class ContactDetailsViewModel
	{
		public string PageTitle { get; set; }
		public Contact Contact { get; set; }
	}
}

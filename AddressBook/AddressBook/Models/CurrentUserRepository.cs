using AddressBook.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Domain.Models
{
	public class CurrentUserRepository : ICurrentUserRepository
	{
		public User currentUser { get; set; }
	}
}

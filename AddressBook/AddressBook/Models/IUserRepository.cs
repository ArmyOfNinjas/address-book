using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Models
{
	public interface IUserRepository
	{
		User GetUser(string userName, string password);
		User Add(User user);
	}
}

using AddressBook.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Domain.Models
{
	public class UserRepository : IUserRepository
	{
		public User currentUser { get; set; }
		private AddressBookContext _dbContext { get; set; }

		public UserRepository(AddressBookContext dbContext)
		{
			_dbContext = dbContext;
		}


		public User GetUser(string userName, string password)
		{
			User user = _dbContext.Users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
			if (user != null) currentUser = user;
			return _dbContext.Users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
		}

		public User Add(User user)
		{
			_dbContext.Users.Add(user);
			return user;
		}
	}
}

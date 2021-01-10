using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Domain.Models
{
	public class UserRepository : IUserRepository
	{
		private List<User> _users;

		public UserRepository()
		{
			var user = new User() { UserName = "LeonidM", FirstName = "Leonid" };
			user.Contacts = new List<Contact>()
				{
				new Contact() {ContactId=1, FirstName = "Leo2", LastName="Malanowski2", User = user },
				new Contact() {ContactId=2, FirstName = "Leo3", LastName="Malanowski3", User = user }
				};

			_users = new List<User>();
			_users.Add(user);
		}


		public User GetUser(string userName, string password)
		{
			return _users.FirstOrDefault(x => x.UserName.Equals(userName) && x.Password.Equals(password));
		}

		public User Add(User user)
		{
			user.UserId = _users.Max(x => x.UserId) + 1;
			_users.Add(user);
			return user;
		}
	}
}

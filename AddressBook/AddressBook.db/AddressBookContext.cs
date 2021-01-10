using AddressBook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AddressBook.db
{
	public class AddressBookContext : DbContext
	{
		public AddressBookContext(DbContextOptions options)
				: base(options)
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<User>()
			.HasMany(b => b.Contacts)
			.WithOne(i => i.User)
			.HasForeignKey(b => b.UserId);

			modelBuilder.Entity<User>()
			.HasData(
				new User
				{
					UserName = "LeonidM",
					Password = "password123",
					FirstName = "Leonid",
					LastName = "Malanowski",
					Contacts = new List<Contact>()
					{
						new Contact { FirstName = "Mike", LastName = "Smith" },
						new Contact { FirstName = "John", LastName = "White" },
					}
				});

			//modelBuilder.Entity<Contact>()
			//.HasData(
			//	new Contact { FirstName = "Leonid", LastName = "Malanowski" });

		}
	}
}

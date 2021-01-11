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
				new
				{
					UserId = 1,
					UserName = "LeonidM",
					Password = "password123",
					FirstName = "Leonid",
					LastName = "Malanowski",
				});

			modelBuilder.Entity<Contact>()
			.HasData(
				new { ContactId = 1, FirstName = "Mike", LastName = "Smith", UserId = 1 },
				new { ContactId = 2, FirstName = "John", LastName = "White", UserId = 1 });
		}
	}
}

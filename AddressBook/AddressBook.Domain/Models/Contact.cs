using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Domain.Models
{
	public class Contact
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ContactId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string StreetName { get; set; }
		public string City { get; set; }
		public string Province { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }

		public int? UserId { get; set; }
		public virtual User User { get; set; }
	}
}

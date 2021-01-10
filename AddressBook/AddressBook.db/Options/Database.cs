using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.db.Options
{
    public class Database
    {
        public string Name { get; set; }

        public string ProviderName { get; set; }

        public string ConnectionString { get; set; } 
    }
}

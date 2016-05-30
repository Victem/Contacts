using Contacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Domain.Concrete
{
    public class ContactsContext : DbContext
    {

        public ContactsContext() : base("DBConnection")
        {
           
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}

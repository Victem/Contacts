using Contacts.Domain.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Domain.Entities;
using System.Diagnostics;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Contacts.Domain.Concrete
{
    public class EFContactRepository : IContactRepository
    {
        private ContactsContext context = new ContactsContext();
        public IQueryable<Contact> Contacts
        {
            get
            {
                return context.Contacts;
            }            
        }

        public Contact Delete(int id)
        {
            Contact contact = context.Contacts.Find(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }

            return contact;
        }

        public void Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();            
        }

        public void Add(IEnumerable<Contact> contacts)
        {
            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }

        public bool Update(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }


        private bool ContactExists(int id)
        {
            return context.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}

using Contacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Domain.Absract
{
    public interface IContactRepository
    {
        IQueryable<Contact> Contacts { get; }

        void Add(Contact contact);

        void Add(IEnumerable<Contact> contacts);

        Contact Delete(int id);

        bool Update(Contact contact);        
        
    }
}

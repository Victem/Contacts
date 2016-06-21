using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Contacts.Domain.Concrete;
using Contacts.Domain.Entities;
using System.Diagnostics;
using System.Web;
using Contacts.Domain.Absract;

namespace Contacts.WebUI.Controllers
{
    public class ContactsController : ApiController
    {

        private IContactRepository repository;

        public ContactsController(IContactRepository contactsRepository)
        {
            repository = contactsRepository;
        }
        

        // GET: api/Contacts
        //public IQueryable<Contact> GetContacts()
        //{
        //    return db.Contacts.Take(25);
        //}

        // GET: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult GetContact(string searchString)
        {
            IQueryable<Contact> contacts;
            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = repository.Contacts.Where(c => (c.FirstName + " " + c.LastName).ToLower()
                                                          .Contains(searchString.ToLower()))
                                              .Take(25);
            }
            else
            {
                contacts = repository.Contacts.Take(25);
            }

            if (contacts == null)
            {
                return NotFound();
            }


            return Ok(contacts);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (!repository.Update(contact))
            {
                return NotFound();
            }

            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts

        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                       
            repository.Add(contact);
            

            return CreatedAtRoute("DefaultApi", new { id = contact.Id }, contact);

        }


     

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = repository.Delete(id);
            if (contact == null)
            {
                return NotFound();
            }
            
            return Ok(contact);
        }

       

        
    }
}
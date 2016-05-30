using Contacts.Domain.Absract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using Contacts.Domain.Entities;

namespace Contacts.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IContactRepository repository;
        public HomeController(IContactRepository contactRepository)
        {
            repository = contactRepository;
        }
        public ActionResult Index()
        {
            /*Убогий код, которого здесь быть не должно, но все же присутствует, для загрузки тестовых данных*/
            if (repository.Contacts.Count()==0)
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Contact>));
                List<Contact> contactList;

                using (FileStream stream = new FileStream(Server.MapPath("/Mocks/MOCK_DATA.json"), FileMode.Open))
                {
                    contactList = (List<Contact>)jsonFormatter.ReadObject(stream);
                }

                repository.Add(contactList);
            }             
            /*Конец убогого кода*/

            return View();
        }
             
    }
}
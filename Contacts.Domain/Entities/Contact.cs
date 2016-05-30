using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Domain.Entities
{
    [DataContract]
    public class Contact
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "first_name")]        
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "company_name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "job_title")]
        public string JobTitle { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "avatar")]
        public string Avatar { get; set; }     
    }
}

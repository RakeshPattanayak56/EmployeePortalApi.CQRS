using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediator.Models
{
    public class AddEmplyeeDetails
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone no cannot be longer than 12 characters and less than 10 characters")]
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Registration.Models.Domain
{
    public class Employee
    { 
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SSN { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        //Join Email Table
        public int? EmailId { get; set; }
        [ForeignKey("EmailId")]
        public Emails Emails { get; set; }

        public int? MobileId { get; set; }
        [ForeignKey("MobileId")]
        public Mobile Mobile { get; set; }

        public int? AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}

using Employee_Registration.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Employee_Registration.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SSN { get; set; }
        //Join Email Table
        public Emails Emails { get; set; }
        public Mobile Mobile { get; set; }
        public Address Address { get; set; }
    }
}

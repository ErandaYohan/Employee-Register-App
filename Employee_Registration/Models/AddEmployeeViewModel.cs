using Employee_Registration.Models.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Registration.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int SSN { get; set; }
        [Required]
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        [Required]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        //Join Email Table
        [Required]
        public Emails Emails { get; set; }
        [Required]
        public Mobile Mobile { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}

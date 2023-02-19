using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Registration.Models.Domain
{
    public class Emails
    {
        [Key]
        public int EmailId { get; set; }
        public string Email { get; set; }
    }
}

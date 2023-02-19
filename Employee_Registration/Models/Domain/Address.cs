using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Registration.Models.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set;}
        public string State { get; set;}
        public int PostalCode { get; set;}
    }
}

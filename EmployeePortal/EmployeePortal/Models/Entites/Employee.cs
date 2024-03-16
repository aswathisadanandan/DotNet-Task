using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models.Entites
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //[Required(ErrorMessage ="Name Required")]
        //public string Email { get; set; }
        public string Phone { get; set; }
        //[Required(ErrorMessage = "Phone number Required")]
        //[RegularExpression(@"^\+(?:[0-9]?){6,14}[0-9]$", ErrorMessage ="Invalid phone number")]
        public bool Subscribed { get; set; }
    }
}

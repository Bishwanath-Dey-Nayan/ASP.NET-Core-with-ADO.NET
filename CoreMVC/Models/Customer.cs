using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter Your Name")]
        [StringLength(15,ErrorMessage ="Name should be less than or equal to fifteen character.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter your Address")]
        [StringLength(50, ErrorMessage="Name should be less than or equal to fifteen character.")]
        public string Address { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Your must provide a Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Enter Your Mail ID")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}

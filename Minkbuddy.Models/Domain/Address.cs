//Ajay

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Address
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Telephone")]
        [Required(ErrorMessage = "The telephone number is required")]
        [Phone(ErrorMessage = "Invalid Telephone Number")]
        [RegularExpression("^\\+?[1-9]\\d{1,14}$", ErrorMessage = "Invalid Telephone Number")]
        public string Telephone { get; set; }

        [MinLength(2,ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100,ErrorMessage = "Maximum 100 characters allowed")]
        public string Line1 { get; set; }

        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string Line2 { get; set; }

        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 50 characters allowed")]
        public string City { get; set; }

        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 50 characters allowed")]
        public string Region { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 2 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 2 characters allowed")]
        public string Country { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimum 3 characters required")]
        [MaxLength(100, ErrorMessage = "Maximum 20 characters allowed")]
        public int Postcode { get; set; }

        public bool BillToThis { get; set; } = true;
    }
}

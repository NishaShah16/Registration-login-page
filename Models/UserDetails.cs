using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NDProject.Models
{

    public class DropdownList
    {
        public List<string> programmes { get; set; }

        public int ProgrammeId { get; set; }

        [Required(ErrorMessage = "Programme is required.")]
        public string programme { get; set; }
    }
    public class UserDetails
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Programme is required.")]
        public string programme { get; set; }

        [Required(ErrorMessage = "NEET Roll Number is required.")]
        public string NeetRollNo { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*(),.\?""':{}|<>]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one number and one special character.")]
        public string Password { get; set; }

        // New fields
        [Required(ErrorMessage = "Father's name is required.")]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "Mother's name is required.")]
        public string MothersName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        public string Name { get; set; }

    }

}

using AcademyCRM.MVC.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyCRM.MVC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [BirthDate(18, ErrorMessage = "Must be older 18")]
        public DateTime? BirthDate { get; set; }
        
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Length must be 3-100")]
        public string Email { get; set; }
    }
}
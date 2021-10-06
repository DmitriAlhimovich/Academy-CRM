using AcademyCRM.MVC.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AcademyCRM.MVC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Length must be 3-100")]
        public string Email { get; set; }

        public byte[] Photo { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
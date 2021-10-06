using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyCRM.Core.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public byte[] Photo { get; set; }

        public string FullName => $"{LastName} {FirstName}";
    }
}
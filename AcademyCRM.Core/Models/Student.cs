using System;

namespace AcademyCRM.Core.Models
{
    public class Student : Person
    {
        public DateTime StartDate { get; set; }

        public StudentType Type { get; set; }

        public int? GroupId { get; set; }
        public StudentGroup Group { get; set; }

        public Student EnsureNotNull()
        {
            if (this is null)
                throw new ArgumentNullException(nameof(Student));
            return this;
        }
    }
}
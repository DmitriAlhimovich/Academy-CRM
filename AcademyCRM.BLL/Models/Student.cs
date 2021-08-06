using System;

namespace AcademyCRM.BLL.Models
{
    public class Student : Person
    {
        public DateTime StartDate { get; set; }

        public StudentType Type { get; set; }

        public int GroupId { get; set; }
        public StudentGroup Group { get; set; }
    }
}
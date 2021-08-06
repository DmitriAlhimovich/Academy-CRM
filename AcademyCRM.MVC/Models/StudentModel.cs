using System;

namespace AcademyCRM.MVC.Models
{
    public class StudentModel : PersonModel
    {
        public int GroupId { get; set; }
        public StudentGroupModel Group { get; set; }
    }
}
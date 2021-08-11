namespace AcademyCRM.Web.Mvc.Models
{
    public class StudentGroupModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }

        public string StartDate { get; set; }

        public string Status { get; set; }
    }
}

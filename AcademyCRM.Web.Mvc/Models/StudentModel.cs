namespace AcademyCRM.Web.Mvc.Models
{
    public class StudentModel : PersonModel
    {
        public int GroupId { get; set; }
        public StudentGroupModel Group { get; set; }
    }
}
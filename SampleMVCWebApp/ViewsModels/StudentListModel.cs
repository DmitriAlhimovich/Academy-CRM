using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCWebApp.Models
{
    public class StudentListModel
    {
        public StudentListModel(IEnumerable<Student> students)
        {
            Students = students.Select(s => new StudentModel()
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                StartDate = s.StartDate
            });
        }

        public IEnumerable<StudentModel> Students { get; set; }

    }
}

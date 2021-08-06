using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyCRM.BLL.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public DateTime? StartDate { get; set; }

        public GroupStatus Status { get; set; }
    }

    public enum GroupStatus
    {
        NotStarted,
        Started,
        Finished,
        Cancelled
    }
}
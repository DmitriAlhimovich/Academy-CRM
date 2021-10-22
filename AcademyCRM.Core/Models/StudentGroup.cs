using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AcademyCRM.Core.Interfaces;

namespace AcademyCRM.Core.Models
{
    public class StudentGroup : IIdProperty
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime? StartDate { get; set; }

        public GroupStatus Status { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int? ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

        public IList<Lesson> Lessons { get; set; }
    }

    public class Lesson : IIdProperty
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public StudentGroup Group { get; set; }

        public int ScheduledLessonId { get; set; }

        public ScheduledWeeklyLesson ScheduledLesson { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime? EndedAt { get; set; }

        public string Notes { get; set; }

        public IEnumerable<StudentVisit> Visits { get; set; }
    }

    public class StudentVisit : IIdProperty
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public byte? Mark { get; set; }

        public string Notes { get; set; }
    }

    public class Schedule : IIdProperty
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public StudentGroup Group { get; set; }

        public IEnumerable<ScheduledWeeklyLesson> WeeklyLessons { get; set; }
    }

    public class ScheduledWeeklyLesson : IIdProperty
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public byte Hour { get; set; }

        public byte Minute { get; set; }

        public int Duration { get; set; }
    }

    public class StudentToGroupAssignment : IIdProperty
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int GroupId { get; set; }

        public StudentGroup Group { get; set; }

        public DateTime AssignedAt { get; set; }

        public DateTime? DismissedAt { get; set; }
    }

    public enum GroupStatus
    {
        NotStarted,
        Started,
        Finished,
        Cancelled
    }
}
namespace AcademyCRM.Core.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public Topic Parent { get; set; }
    }
}

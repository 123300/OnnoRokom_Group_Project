namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? TempId { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}

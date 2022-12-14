namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? AuthorName { get; set; }
        public int QuestionId { get; set; }
        public Guid? TempId { get; set; }
        public int CountVote { get; set; }
        public Question? Question { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}

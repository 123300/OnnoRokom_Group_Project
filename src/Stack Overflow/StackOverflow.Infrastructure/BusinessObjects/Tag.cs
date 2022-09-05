﻿namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}

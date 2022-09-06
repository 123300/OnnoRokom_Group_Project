using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using QuestionEO = StackOverflow.Infrastructure.Entities.Question;
using AnswerEO = StackOverflow.Infrastructure.Entities.Answer;
using CommentEO = StackOverflow.Infrastructure.Entities.Comment;

namespace StackOverflow.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<Question, QuestionEO>().ReverseMap();
            CreateMap<Answer, AnswerEO>().ReverseMap();
            CreateMap<Comment, CommentEO>().ReverseMap();
        }
    }
}

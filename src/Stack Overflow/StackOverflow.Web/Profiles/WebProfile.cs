using AutoMapper;
using StackOverflow.Membership.BusinessObjects;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Membership.DTOs;
using StackOverflow.Web.Areas.Explorer.Models;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserBasicInfoDto>().ReverseMap();
            CreateMap<Question, QuestionCreateModel>().ReverseMap();
            CreateMap<Question, QuestionEditModel>().ReverseMap();

        }
    }
}

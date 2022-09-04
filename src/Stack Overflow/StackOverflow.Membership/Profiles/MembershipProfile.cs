using ApplicationUserEO = StackOverflow.Infrastructure.Entities.Membership.ApplicationUser;
using StackOverflow.Membership.BusinessObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPos.Membership.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserEO>().ReverseMap();
        }
    }
}

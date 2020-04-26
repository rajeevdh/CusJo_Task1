using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CusJoTask.Models;
using CusJoTask.Dtos;
using AutoMapper;

namespace CusJoTask.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>()
                .ForMember(c => c.UserId, opt => opt.Ignore());
        }
    }
}
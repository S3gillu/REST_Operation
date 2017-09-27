using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using REST_Operation.Dtos;
using REST_Operation.Models;

namespace REST_Operation.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Api.Configs
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();
                cfg.CreateMap<UserDTO, ApplicationUser>()
                    .ForMember("UserName", opt => opt.MapFrom(f => f.Email));
            });
        }
    }
}
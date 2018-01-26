using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MiniSocialNetwork.Api.Models;
using MiniSocialNetwork.Bll.DTO;
using MiniSocialNetwork.Dal.Entities;

namespace MiniSocialNetwork.Shared
{
    public static class AutomapperConfig
    {
        public static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, UserDTO>();
                cfg.CreateMap<UserDTO, UserProfile>();
                cfg.CreateMap<UserDTO, ApplicationUser>()
                    .ForMember();
            });
        }
    }
}

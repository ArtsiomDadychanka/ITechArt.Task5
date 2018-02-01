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
                CreateMapApiBlLayer(cfg);
                CreateMapBlDaLayer(cfg);
            });
        }

        private static void CreateMapApiBlLayer(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<LoginViewModel, UserDTO>();
            cfg.CreateMap<RegisterViewModel, UserDTO>();

            cfg.CreateMap<CreatedPostViewModel, PostDTO>();
            cfg.CreateMap<PostDTO, DisplayedPostViewModel>();

            cfg.CreateMap<CreatedCommentViewModel, CommentDTO>();
            cfg.CreateMap<CommentDTO, DisplayedCommentViewModel>();

        }

        private static void CreateMapBlDaLayer(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PostDTO, Post>();
            cfg.CreateMap<Post, PostDTO>()
                .ForMember("AuthorName",
                    opt => opt.MapFrom(f => $"{f.UserProfile.Firstname} {f.UserProfile.Lastname}"))
                .ForMember("AuthorId", opt => opt.MapFrom(f => f.UserProfile.ApplicationUser.Id));

            cfg.CreateMap<CommentDTO, Post>();
            cfg.CreateMap<Post, CommentDTO>()
                .ForMember("AuthorName",
                    opt => opt.MapFrom(f => $"{f.UserProfile.Firstname} {f.UserProfile.Lastname}"))
                .ForMember("AuthorId", opt => opt.MapFrom(f => f.UserProfile.ApplicationUser.Id));

            cfg.CreateMap<UserDTO, UserProfile>();
            cfg.CreateMap<UserDTO, ApplicationUser>()
                .ForMember("UserName", opt => opt.MapFrom(f => f.Email));
        }
    }
}
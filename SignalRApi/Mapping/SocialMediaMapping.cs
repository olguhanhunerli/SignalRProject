﻿using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping: Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia,ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia,UpdateSocialMedia>().ReverseMap();
            CreateMap<SocialMedia,CreateSocialMediaDto>().ReverseMap();
        }
    }
}

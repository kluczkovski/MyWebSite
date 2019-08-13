using System;
using AutoMapper;
using MyWebSite.Models;
using MyWebSite.ViewModels;

namespace MyWebSite.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Project, ProjectViewModel>().ReverseMap();

            CreateMap<ProjectImage, ProjectImageViewModel>().ReverseMap();
        }
    }
}

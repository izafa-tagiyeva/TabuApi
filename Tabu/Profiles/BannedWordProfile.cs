using AutoMapper;
using Tabu.DTOs.BannerWords;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class BannedWordProfile : Profile
    {
        public BannedWordProfile()
        {
          
            CreateMap< BannedWordUpdateDto, BannedWord>().ReverseMap();
        }
    }
}

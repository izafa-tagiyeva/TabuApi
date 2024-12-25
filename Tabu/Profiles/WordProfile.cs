using AutoMapper;
using Tabu.DTOs.Words;
using Tabu.Entities;

namespace Tabu.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>();
            CreateMap<Word, WordForGameDto>()
                .ForMember(x=>x.BanendWords , opt=>opt.MapFrom(x=>x.BannedWords.Select(x=>x.Text).ToList()))
                .ReverseMap();
        }
    }
}

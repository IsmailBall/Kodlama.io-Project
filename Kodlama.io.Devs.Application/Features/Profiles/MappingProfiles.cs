using AutoMapper;
using Kodlama.io.Devs.Application.Features.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, LanguageCreateDto>().ReverseMap();
            CreateMap<Language, LanguageListDto>().ReverseMap();
            CreateMap<Language, LanguageUpdateDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Features.Rules;
using Kodlama.io.Devs.Application.Services.Repositoreis;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<LanguageCreateDto>
    {
        public string Name { get; set; }

        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, LanguageCreateDto>
        {

            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
            {
                _mapper = mapper;
                _languageRepository = languageRepository;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<LanguageCreateDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                var mappedLanguage = _mapper.Map<Language>(request.Name);
                var createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
                var createdLanguageDto = _mapper.Map<LanguageCreateDto>(createdLanguage);

                return createdLanguageDto;
            }
        }
    }
}

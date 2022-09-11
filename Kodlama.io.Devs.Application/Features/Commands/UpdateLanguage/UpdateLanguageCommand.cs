using AutoMapper;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Services.Repositoreis;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<LanguageUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, LanguageUpdateDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public UpdateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository)
            {
                _mapper = mapper;
                _languageRepository = languageRepository;
            }

            public async Task<LanguageUpdateDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {
                var mappedEntity = _mapper.Map<Language>(request);
                var updatedEntity =  await _languageRepository.UpdateAsync(mappedEntity);
                var result = _mapper.Map<LanguageUpdateDto>(updatedEntity);

                return result;
            }
        }
    }
}

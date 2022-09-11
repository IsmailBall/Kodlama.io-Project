using AutoMapper;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Services.Repositoreis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<LanguageListDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, LanguageListDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public DeleteLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository)
            {
                _mapper = mapper;
                _languageRepository = languageRepository;
            }

            public async Task<LanguageListDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                var entity = await _languageRepository.GetAsync(l => l.Id == request.Id);
                if (entity != null)  await _languageRepository.DeleteAsync(entity);

                var listedEntity = _mapper.Map<LanguageListDto>(entity);

                return listedEntity;
            }
        }
    }
}

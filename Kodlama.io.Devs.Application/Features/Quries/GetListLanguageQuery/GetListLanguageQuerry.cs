using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Features.Models;
using Kodlama.io.Devs.Application.Services.Repositoreis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Quries.GetListLanguageQuery
{
    public class GetListLanguageQuerry : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageQuerryHandler : IRequestHandler<GetListLanguageQuerry, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQuerryHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetListLanguageQuerry request, CancellationToken cancellationToken)
            {
                var list = await _languageRepository.GetListAsync(size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                var mappedModel = _mapper.Map<LanguageListModel>(list);

                return mappedModel;
            }

        }
    }
}

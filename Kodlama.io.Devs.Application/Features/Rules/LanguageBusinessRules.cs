using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.Dtos;
using Kodlama.io.Devs.Application.Services.Repositoreis;

namespace Kodlama.io.Devs.Application.Features.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async void LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _languageRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any()) throw new BusinessException("There exist same name with language intendet to insert"); 
        }
    }
}
